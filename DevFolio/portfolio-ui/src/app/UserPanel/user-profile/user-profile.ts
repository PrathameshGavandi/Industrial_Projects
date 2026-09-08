import {
  Component,
  HostListener,
  OnInit
} from '@angular/core';

import { CommonModule } from '@angular/common';

import {
  ProfileService,
  Profile
} from '../../Services/ProfileService';

import { Router }
  from '@angular/router';

import Swal
  from 'sweetalert2';


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


  /* =====================================================
     PROFILE DATA
  ===================================================== */

  profile: Profile = {

    name: 'Your Name',

    email: '',

    phone: '',

    bio: ''

  };


  constructor(

    private profileService:
      ProfileService,

    private router:
      Router

  ) {}


  /* =====================================================
     INIT
  ===================================================== */

  ngOnInit(): void {

    /*
     * API call starts immediately
     * when Profile component initializes.
     *
     * It does NOT wait for portfolio loader.
     */

    this.loadProfile();

  }


  /* =====================================================
     LOAD PROFILE
  ===================================================== */

  private loadProfile(): void {

    console.log(
      'USER PROFILE → API CALL STARTED'
    );


    this.profileService
      .getallProfiles()
      .subscribe({

        /* ================================================
           API SUCCESS
        ================================================ */

        next: (res: any[]) => {

          console.log(
            'USER PROFILE → API RESPONSE:',
            res
          );


          const p = res?.[0];


          this.profile = {

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

        },


        /* ================================================
           API ERROR
        ================================================ */

        error: (error) => {

          console.error(
            'USER PROFILE → API ERROR:',
            error
          );

          /*
           * No parent notification.
           *
           * Profile handles its own error.
           */

        },


        /* ================================================
           API COMPLETED
        ================================================ */

        complete: () => {

          console.log(
            'USER PROFILE → LOADING COMPLETED'
          );

        }

      });

  }


  /* =====================================================
     BIO POINTS
  ===================================================== */

  getBioPoints(
    bio: string | undefined
  ): string[] {

    if (!bio) {

      return [];

    }


    return bio

      .split('||')

      .map(
        point =>
          point.trim()
      )

      .filter(
        point =>
          point.length > 0
      );

  }


  /* =====================================================
     EMAIL
  ===================================================== */

  openMail(
    email: string | undefined
  ): void {

    if (!email) {

      return;

    }


    window.location.href =
      'mailto:' + email;

  }


  /* =====================================================
     ADMIN SHORTCUT
     CTRL + SHIFT + A
  ===================================================== */

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