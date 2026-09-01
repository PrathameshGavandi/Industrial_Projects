import { Component, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileService, Profile } from '../../Services/ProfileService';
import { map, Observable } from 'rxjs';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
selector: 'app-user-profile',
standalone: true,
imports: [CommonModule],
templateUrl: './user-profile.html',
styleUrls: ['./user-profile.scss'],
})

export class UserProfileComponent {

profile$!: Observable<Profile>;

constructor(
private profileService: ProfileService,
private router: Router
) {
this.loadProfile();
}

/* ===============================
LOAD PROFILE
================================ */

loadProfile(): void {

 
this.profile$ = this.profileService
  .getallProfiles()
  .pipe(

    map((res: any[]) => {

      const p = res?.[0];

      return {

        ...p,

        name: p?.Name ?? p?.name ?? 'Your Name',

        email: p?.Email ?? p?.email ?? '',

        phone: p?.Phone ?? p?.phone ?? '',

        bio: p?.Bio ?? p?.bio ?? ''

      } as Profile;

    })

  );
 

}

/* ===============================
BIO BULLET POINTS
================================ */

getBioPoints(bio: string | undefined): string[] {

 
if (!bio) {
  return [];
}

return bio
  .split('||')
  .map((point: string) => point.trim())
  .filter((point: string) => point.length > 0);
 

}

/* ===============================
OPEN MAIL
================================ */

openMail(email: string | undefined): void {

 
if (!email) {
  return;
}

window.location.href = 'mailto:' + email;
 

}

/* ===============================
ADMIN SHORTCUT
CTRL + SHIFT + A
================================ */

@HostListener('document:keydown', ['$event'])

handleAdminShortcut(event: KeyboardEvent): void {

 
if (
  event.ctrlKey &&
  event.shiftKey &&
  event.key.toLowerCase() === 'a'
) {

  event.preventDefault();

  Swal.fire({

    icon: 'info',

    title: 'Admin Access',

    text: 'Redirecting to Admin Login...',

    timer: 1200,

    showConfirmButton: false,

    background: '#0b1c2d',

    color: '#ffffff'

  }).then(() => {

    this.router.navigate(['/login']);

  });

}
 

}

}
