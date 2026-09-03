import { Component, EventEmitter, HostListener, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileService, Profile } from '../../Services/ProfileService';
import { map, Observable, catchError, of, tap } from 'rxjs';
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

  @Output() loaded = new EventEmitter<void>();

  profile$!: Observable<Profile>;

  constructor(
    private profileService: ProfileService,
    private router: Router
  ) {
    this.loadProfile();
  }

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

        }),

        tap(() => {
          this.loaded.emit();
        }),

        catchError((error) => {

          console.error('Profile API Error:', error);

          this.loaded.emit();

          return of({
            name: 'Your Name',
            email: '',
            phone: '',
            bio: ''
          } as Profile);

        })

      );

  }

  getBioPoints(bio: string | undefined): string[] {

    if (!bio) {
      return [];
    }

    return bio
      .split('||')
      .map((point: string) => point.trim())
      .filter((point: string) => point.length > 0);

  }

  openMail(email: string | undefined): void {

    if (!email) {
      return;
    }

    window.location.href = 'mailto:' + email;

  }

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