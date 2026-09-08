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


  /* ==========================================
     PROFILE DATA
  ========================================== */

  profile: Profile = {

    name: 'Your Name',

    email: '',

    phone: '',

    bio: ''

  };


  constructor(

    private profileService: ProfileService,

    private router: Router

  ) {}


  /* ==========================================
     INIT
  ========================================== */

  ngOnInit(): void {

    this.loadProfile();

  }


  /* ==========================================
     LOAD PROFILE
  ========================================== */

  private loadProfile(): void {

    console.log(
      'USER PROFILE → API CALL STARTED'
    );


    this.profileService
      .getallProfiles()
      .subscribe({

        /* ====================================
           API SUCCESS
        ==================================== */

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


        /* ====================================
           API ERROR
        ==================================== */

        error: (error) => {

          console.error(
            'USER PROFILE → API ERROR:',
            error
          );


          /*
           * Even if API fails, tell parent
           * that this component has finished
           * loading.
           */

          this.loaded.emit();

        },


        /* ====================================
           API COMPLETED
        ==================================== */

        complete: () => {

          console.log(
            'USER PROFILE → LOADING COMPLETED'
          );


          /*
           * Tell UserPortfolioComponent
           * that Profile component is ready.
           */

          this.loaded.emit();

        }

      });

  }


  /* ==========================================
     BIO POINTS
  ========================================== */

  getBioPoints(
    bio: string | undefined
  ): string[] {

    if (!bio) {

      return [];

    }


    return bio
      .split('||')
      .map(
        point => point.trim()
      )
      .filter(
        point => point.length > 0
      );

  }


  /* ==========================================
     EMAIL
  ========================================== */

  openMail(
    email: string | undefined
  ): void {

    if (!email) {

      return;

    }


    window.location.href =
      'mailto:' + email;

  }


  /* ==========================================
     ADMIN SHORTCUT
     CTRL + SHIFT + A
  ========================================== */

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