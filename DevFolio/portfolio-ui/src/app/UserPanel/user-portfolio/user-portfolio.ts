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


  /* ==========================================
     VISUAL LOADER ONLY

     IMPORTANT:
     This loader has NO dependency on APIs.

     All child components are already present
     in the DOM, so their ngOnInit() methods
     start their own API calls independently.
  ========================================== */

  isLoading = true;

  showContinueButton = false;

  /*
   * This is ONLY visual progress.
   * It does NOT represent API progress.
   */
  progressValue = 0;

  /*
   * Loader will stay visible for 3 seconds.
   *
   * Change this value if you want:
   * 3000 = 3 seconds
   * 4000 = 4 seconds
   * 5000 = 5 seconds
   */
  private readonly LOADER_DURATION = 3000;

  private loaderTimer?: ReturnType<typeof setTimeout>;
  private progressTimer?: ReturnType<typeof setInterval>;


  /* ==========================================
     CUSTOM CURSOR
  ========================================== */

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


  /* ==========================================
     INIT
  ========================================== */

  ngOnInit(): void {

    /*
     * Start ONLY visual loader.
     *
     * No API is called here.
     * No child component is awaited.
     */
    this.startLoader();
  }


  /* ==========================================
     CUSTOM CURSOR MOVEMENT
  ========================================== */

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


  /* ==========================================
     MOUSE DOWN
  ========================================== */

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
      clearTimeout(this.rippleTimer);
    }

    /*
     * Small timeout allows Angular
     * to recreate ripple element.
     */
    this.rippleTimer = setTimeout(() => {

      this.showCursorRipple = true;

      this.cdr.detectChanges();

    }, 10);


    this.rippleTimer = setTimeout(() => {

      this.showCursorRipple = false;

      this.cdr.detectChanges();

    }, 550);
  }


  /* ==========================================
     MOUSE UP
  ========================================== */

  @HostListener(
    'document:mouseup'
  )
  onMouseUp(): void {

    this.cursorClicking = false;
  }


  /* ==========================================
     START VISUAL LOADER
  ========================================== */

  private startLoader(): void {

    this.isLoading = true;
    this.showContinueButton = false;
    this.progressValue = 0;


    /*
     * Clear previous timers if any.
     */
    if (this.loaderTimer) {
      clearTimeout(this.loaderTimer);
    }

    if (this.progressTimer) {
      clearInterval(this.progressTimer);
    }


    /*
     * VISUAL PROGRESS ONLY
     *
     * This progress has absolutely
     * nothing to do with API loading.
     */
    const startTime = Date.now();


    this.progressTimer = setInterval(() => {

      const elapsed = Date.now() - startTime;

      this.progressValue = Math.min(
        100,
        Math.round(
          (elapsed / this.LOADER_DURATION) * 100
        )
      );


      this.cdr.detectChanges();


      /*
       * Stop progress at 100%.
       */
      if (this.progressValue >= 100) {

        if (this.progressTimer) {

          clearInterval(
            this.progressTimer
          );

          this.progressTimer = undefined;
        }
      }

    }, 50);


    /*
     * After fixed visual duration,
     * simply enable Continue button.
     *
     * API status is NOT checked.
     */
    this.loaderTimer = setTimeout(() => {

      this.progressValue = 100;

      this.showContinueButton = true;

      if (this.progressTimer) {

        clearInterval(
          this.progressTimer
        );

        this.progressTimer = undefined;
      }

      this.cdr.detectChanges();

    }, this.LOADER_DURATION);
  }


  /* ==========================================
     GO TO PORTFOLIO
  ========================================== */

  goToContent(): void {

    /*
     * Button works only after visual loader
     * is completed.
     */
    if (!this.showContinueButton) {
      return;
    }


    /*
     * ONLY hide loader.
     *
     * This does NOT start/stop/wait for APIs.
     */
    this.isLoading = false;

    this.cdr.detectChanges();


    /*
     * Scroll to profile section.
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


  /* ==========================================
     CLEANUP
  ========================================== */

  ngOnDestroy(): void {

    if (this.loaderTimer) {
      clearTimeout(this.loaderTimer);
    }

    if (this.progressTimer) {
      clearInterval(this.progressTimer);
    }

    if (this.rippleTimer) {
      clearTimeout(this.rippleTimer);
    }
  }

}