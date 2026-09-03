import {
  Component,
  OnDestroy,
  OnInit
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { UserNav }
  from '../user-nav/user-nav';

import { UserProfileComponent }
  from '../user-profile/user-profile';

import { UserSkillsComponent }
  from '../user-skills/user-skills';

import { UserExperienceComponent }
  from '../user-experience/user-experience';

import { UserProjectsComponent }
  from '../user-projects/user-projects';

import { UserEducationComponent }
  from '../user-education/user-education';


@Component({
  selector: 'app-user-portfolio',

  standalone: true,

  imports: [
    CommonModule,
    UserNav,
    UserProfileComponent,
    UserSkillsComponent,
    UserExperienceComponent,
    UserProjectsComponent,
    UserEducationComponent
  ],

  templateUrl: './user-portfolio.html',

  styleUrls: ['./user-portfolio.scss']
})


export class UserPortfolioComponent
  implements OnInit, OnDestroy {


  /* =====================================================
     LOADER STATE
  ===================================================== */

  isLoading = true;


  /* =====================================================
     BUTTON / SYSTEM READY STATE
  ===================================================== */

  showContinueButton = false;


  /* =====================================================
     EXACT LOADING TIME

     9000 milliseconds = 9 seconds
  ===================================================== */

  private readonly LOADING_TIME = 9000;


  private loadingTimer?: ReturnType<typeof setTimeout>;


  /* =====================================================
     COMPONENT START
  ===================================================== */

  ngOnInit(): void {

    this.startLoader();

  }


  /* =====================================================
     START LOADER AUTOMATICALLY
  ===================================================== */

  private startLoader(): void {

    this.isLoading = true;

    this.showContinueButton = false;


    /*
     * Button is already visible.
     *
     * But it remains DISABLED for 9 seconds.
     *
     * After 9 seconds:
     *
     * - Progress completes
     * - SYSTEM READY appears
     * - Button becomes ENABLED automatically
     */

    this.loadingTimer = setTimeout(() => {

      this.showContinueButton = true;

    }, this.LOADING_TIME);

  }


  /* =====================================================
     GO TO PORTFOLIO CONTENT
  ===================================================== */

  goToContent(): void {


    /*
     * Extra safety:
     * Do nothing until system is ready
     */

    if (!this.showContinueButton) {

      return;

    }


    /*
     * Remove loader
     */

    this.isLoading = false;


    /*
     * Scroll to profile section
     */

    setTimeout(() => {

      const profileSection =
        document.getElementById('profile');


      if (profileSection) {

        profileSection.scrollIntoView({
          behavior: 'smooth',
          block: 'start'
        });

      }

    }, 100);

  }


  /* =====================================================
     CLEANUP
  ===================================================== */

  ngOnDestroy(): void {

    if (this.loadingTimer) {

      clearTimeout(this.loadingTimer);

    }

  }

}