import {
  Component,
  OnDestroy,
  OnInit,
  ChangeDetectorRef
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


  /* ==========================================
     LOADER STATE
  ========================================== */

  isLoading = true;


  /* ==========================================
     BUTTON STATE
  ========================================== */

  showContinueButton = false;


  /* ==========================================
     PROGRESS
     0 → 100
  ========================================== */

  progressValue = 0;


  /* ==========================================
     LOADING TIME
     EXACTLY 9 SECONDS
  ========================================== */

  private readonly LOADING_TIME = 9000;


  /* ==========================================
     TIMERS
  ========================================== */

  private loadingTimer?: ReturnType<typeof setTimeout>;

  private progressTimer?: ReturnType<typeof setInterval>;


  constructor(
    private cdr: ChangeDetectorRef
  ) {}


  /* ==========================================
     COMPONENT START
  ========================================== */

  ngOnInit(): void {

    this.startLoader();

  }


  /* ==========================================
     START LOADER
  ========================================== */

  private startLoader(): void {


    /* Reset */

    this.isLoading = true;

    this.showContinueButton = false;

    this.progressValue = 0;


    /* ==========================================
       PROGRESS TIMER

       100 steps in 9000ms

       9000 / 100 = 90ms
    ========================================== */

    const progressInterval =
      this.LOADING_TIME / 100;


    this.progressTimer = setInterval(() => {


      if (this.progressValue < 100) {

        this.progressValue++;

        this.cdr.detectChanges();

      }


      /* Stop at 100 */

      if (this.progressValue >= 100) {

        this.progressValue = 100;


        if (this.progressTimer) {

          clearInterval(this.progressTimer);

          this.progressTimer = undefined;

        }


        this.cdr.detectChanges();

      }


    }, progressInterval);


    /* ==========================================
       EXACTLY AFTER 9 SECONDS
       ENABLE BUTTON
    ========================================== */

    this.loadingTimer = setTimeout(() => {


      /* Ensure exactly 100 */

      this.progressValue = 100;


      /* Enable Explore Button */

      this.showContinueButton = true;


      /* Clear progress timer */

      if (this.progressTimer) {

        clearInterval(this.progressTimer);

        this.progressTimer = undefined;

      }


      /* Refresh Angular UI */

      this.cdr.detectChanges();


    }, this.LOADING_TIME);

  }


  /* ==========================================
     EXPLORE PORTFOLIO
  ========================================== */

  goToContent(): void {


    /* सुरक्षा */

    if (!this.showContinueButton) {

      return;

    }


    /* Hide loader */

    this.isLoading = false;


    this.cdr.detectChanges();


    /* Scroll to profile */

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


  /* ==========================================
     CLEANUP
  ========================================== */

  ngOnDestroy(): void {


    if (this.loadingTimer) {

      clearTimeout(this.loadingTimer);

    }


    if (this.progressTimer) {

      clearInterval(this.progressTimer);

    }

  }

}