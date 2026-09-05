import {
  Component,
  EventEmitter,
  HostListener,
  Output,
  OnInit
} from '@angular/core';

import { CommonModule } from '@angular/common';

import {
  ProfileService,
  Profile
} from '../../Services/ProfileService';

import {
  Observable,
  map,
  catchError,
  of,
  finalize,
  shareReplay
} from 'rxjs';

import { Router } from '@angular/router';

import Swal from 'sweetalert2';


@Component({

  selector: 'app-user-profile',

  standalone: true,

  imports: [
    CommonModule
  ],

  templateUrl: './user-profile.html',

  styleUrls: ['./user-profile.scss']

})


export class UserProfileComponent
  implements OnInit {


  @Output()
  loaded = new EventEmitter<void>();


  profile$!: Observable<Profile>;


  constructor(

    private profileService: ProfileService,

    private router: Router

  ) {}


  ngOnInit(): void {

    this.loadProfile();

  }


  private loadProfile(): void {

    this.profile$ =

      this.profileService
        .getallProfiles()
        .pipe(

          map((res: any[]) => {

            const p = res?.[0];

            return {

              ...p,

              name:
                p?.Name ??
                p?.name ??
                'Your Name',

              email:
                p?.Email ??
                p?.email ??
                '',

              phone:
                p?.Phone ??
                p?.phone ??
                '',

              bio:
                p?.Bio ??
                p?.bio ??
                ''

            } as Profile;

          }),


          catchError((error) => {

            console.error(
              'Profile API Error:',
              error
            );

            return of({

              name: 'Your Name',

              email: '',

              phone: '',

              bio: ''

            } as Profile);

          }),


          finalize(() => {

            this.loaded.emit();

          }),


          shareReplay(1)

        );

  }


  getBioPoints(
    bio: string | undefined
  ): string[] {

    if (!bio) {

      return [];

    }


    return bio
      .split('||')
      .map(point => point.trim())
      .filter(point => point.length > 0);

  }


  openMail(
    email: string | undefined
  ): void {

    if (!email) {

      return;

    }


    window.location.href =
      'mailto:' + email;

  }


  @HostListener(
    'document:keydown',
    ['$event']
  )

  handleAdminShortcut(
    event: KeyboardEvent
  ): void {

    if (

      event.ctrlKey &&

      event.shiftKey &&

      event.key.toLowerCase() === 'a'

    ) {

      event.preventDefault();


      Swal.fire({

        icon: 'info',

        title: 'Admin Access',

        text:
          'Redirecting to Admin Login...',

        timer: 1200,

        showConfirmButton: false,

        background: '#0b1c2d',

        color: '#ffffff'

      })

      .then(() => {

        this.router.navigate([
          '/login'
        ]);

      });

    }

  }

}