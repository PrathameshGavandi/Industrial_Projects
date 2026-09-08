import {
  Component,
  OnInit,
  OnDestroy,
  ChangeDetectorRef,
  HostListener
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
     PORTFOLIO LOADER
     ===================================================== */

  isLoading = true;

  showContinueButton = false;

  progressValue = 0;


  /*
   * IMPORTANT
   *
   * Loader is completely independent
   * from all child components and APIs.
   *
   * Change this value if you want the
   * loader to be faster/slower.
   */

  private readonly LOADER_DURATION = 5000;

  private loaderTimer?: ReturnType<typeof setInterval>;

  private readyTimer?: ReturnType<typeof setTimeout>;


  /* =====================================================
     CUSTOM CURSOR
     ===================================================== */

  cursorX = -100;

  cursorY = -100;

  cursorClicking = false;


  rippleX = -100;

  rippleY = -100;

  showCursorRipple = false;


  private rippleTimer?: ReturnType<typeof setTimeout>;


  constructor(
    private cdr: ChangeDetectorRef
  ) {}


  /* =====================================================
     INIT
     ===================================================== */

  ngOnInit(): void {

    /*
     * Start ONLY the visual loader.
     *
     * No API is checked here.
     * No child component is checked here.
     */

    this.startLoader();

  }


  /* =====================================================
     CUSTOM CURSOR MOVEMENT
     ===================================================== */

  @HostListener(
    'document:mousemove',
    ['$event']
  )

  onMouseMove(
    event: MouseEvent
  ): void {

    this.cursorX = event.clientX;

    this.cursorY = event.clientY;

  }


  /* =====================================================
     MOUSE DOWN
     ===================================================== */

  @HostListener(
    'document:mousedown',
    ['$event']
  )

  onMouseDown(
    event: MouseEvent
  ): void {

    this.cursorClicking = true;


    this.rippleX = event.clientX;

    this.rippleY = event.clientY;


    this.showCursorRipple = false;


    if (this.rippleTimer) {

      clearTimeout(
        this.rippleTimer
      );

    }


    setTimeout(() => {

      this.showCursorRipple = true;

      this.cdr.detectChanges();

    }, 10);


    this.rippleTimer = setTimeout(() => {

      this.showCursorRipple = false;

      this.cdr.detectChanges();

    }, 550);

  }


  /* =====================================================
     MOUSE UP
     ===================================================== */

  @HostListener(
    'document:mouseup'
  )

  onMouseUp(): void {

    this.cursorClicking = false;

  }


  /* =====================================================
     START LOADER
     ===================================================== */

  private startLoader(): void {

    /*
     * Reset loader state.
     */

    this.isLoading = true;

    this.showContinueButton = false;

    this.progressValue = 0;


    /*
     * Clear previous timers if any.
     */

    this.clearLoaderTimers();


    /*
     * Loader progress is purely visual.
     *
     * It has absolutely NO connection
     * with Profile / Skills / Experience /
     * Projects / Education APIs.
     */

    const intervalTime = 50;

    const totalSteps =
      this.LOADER_DURATION / intervalTime;

    const progressStep =
      100 / totalSteps;


    this.loaderTimer = setInterval(() => {

      if (this.progressValue < 100) {

        this.progressValue = Math.min(
          100,
          Math.round(
            this.progressValue + progressStep
          )
        );

        this.cdr.detectChanges();

      }


      /*
       * Loader reached 100%.
       */

      if (this.progressValue >= 100) {

        this.stopProgressTimer();


        /*
         * Small delay only for visual
         * READY transition.
         */

        this.readyTimer = setTimeout(() => {

          this.finishLoading();

        }, 300);

      }

    }, intervalTime);

  }


  /* =====================================================
     FINISH LOADING
     ===================================================== */

  private finishLoading(): void {

    if (this.showContinueButton) {

      return;

    }


    this.progressValue = 100;

    this.showContinueButton = true;


    console.log(
      '🚀 Portfolio visual loader completed.'
    );


    this.cdr.detectChanges();

  }


  /* =====================================================
     GO TO PORTFOLIO
     ===================================================== */

  goToContent(): void {

    if (!this.showContinueButton) {

      return;

    }


    this.isLoading = false;


    this.cdr.detectChanges();


    /*
     * Scroll to profile after loader disappears.
     */

    setTimeout(() => {

      const profileSection =
        document.getElementById(
          'profile'
        );


      if (profileSection) {

        profileSection.scrollIntoView({

          behavior: 'smooth',

          block: 'start'

        });

      }

    }, 100);

  }


  /* =====================================================
     STOP PROGRESS TIMER
     ===================================================== */

  private stopProgressTimer(): void {

    if (this.loaderTimer) {

      clearInterval(
        this.loaderTimer
      );

      this.loaderTimer = undefined;

    }

  }


  /* =====================================================
     CLEAR LOADER TIMERS
     ===================================================== */

  private clearLoaderTimers(): void {

    this.stopProgressTimer();


    if (this.readyTimer) {

      clearTimeout(
        this.readyTimer
      );

      this.readyTimer = undefined;

    }

  }


  /* =====================================================
     CLEANUP
     ===================================================== */

  ngOnDestroy(): void {

    this.clearLoaderTimers();


    if (this.rippleTimer) {

      clearTimeout(
        this.rippleTimer
      );

      this.rippleTimer = undefined;

    }

  }

}