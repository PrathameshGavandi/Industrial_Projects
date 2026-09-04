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
     LOADER
  ========================================== */

  isLoading = true;

  showContinueButton = false;

  progressValue = 0;


  /* ==========================================
     CHILD COMPONENT STATUS
  ========================================== */

  private componentStatus: Record<string, boolean> = {

    profile: false,

    skills: false,

    experience: false,

    projects: false,

    education: false

  };


  /* ==========================================
     MAX LOADING TIME
  ========================================== */

  private readonly MAX_LOADING_TIME = 10000;

  private fallbackTimer?: ReturnType<typeof setTimeout>;


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

      clearTimeout(
        this.rippleTimer
      );

    }


    /*
     * Small timeout allows Angular
     * to recreate the ripple element
     */

    setTimeout(() => {

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
     START LOADER
  ========================================== */

  private startLoader(): void {


    this.isLoading = true;

    this.showContinueButton = false;

    this.progressValue = 0;


    this.componentStatus = {

      profile: false,

      skills: false,

      experience: false,

      projects: false,

      education: false

    };


    /*
     * Maximum 10 seconds fallback
     */

    this.fallbackTimer = setTimeout(() => {


      if (!this.showContinueButton) {

        console.warn(
          'Maximum loading time reached.'
        );

        this.finishLoading();

      }

    }, this.MAX_LOADING_TIME);

  }


  /* ==========================================
     CHILD LOADED
  ========================================== */

  onComponentLoaded(
    componentName: string
  ): void {


    if (
      this.componentStatus[componentName]
    ) {

      return;

    }


    this.componentStatus[componentName] = true;


    const totalComponents =
      Object.keys(
        this.componentStatus
      ).length;


    const loadedComponents =
      Object.values(
        this.componentStatus
      ).filter(Boolean)
      .length;


    this.progressValue = Math.round(

      (
        loadedComponents /
        totalComponents
      ) * 100

    );


    console.log(

      `Loaded: ${componentName}`,

      `${loadedComponents}/${totalComponents}`

    );


    if (
      loadedComponents === totalComponents
    ) {

      this.finishLoading();

    }


    this.cdr.detectChanges();

  }


  /* ==========================================
     FINISH LOADING
  ========================================== */

  private finishLoading(): void {


    if (
      this.showContinueButton
    ) {

      return;

    }


    this.progressValue = 100;

    this.showContinueButton = true;


    if (
      this.fallbackTimer
    ) {

      clearTimeout(
        this.fallbackTimer
      );

      this.fallbackTimer = undefined;

    }


    console.log(
      '🚀 Portfolio loading completed!'
    );


    this.cdr.detectChanges();

  }


  /* ==========================================
     GO TO PORTFOLIO
  ========================================== */

  goToContent(): void {


    if (
      !this.showContinueButton
    ) {

      return;

    }


    this.isLoading = false;


    this.cdr.detectChanges();


    setTimeout(() => {


      const profileSection =
        document.getElementById(
          'profile'
        );


      if (
        profileSection
      ) {

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


    if (
      this.fallbackTimer
    ) {

      clearTimeout(
        this.fallbackTimer
      );

    }


    if (
      this.rippleTimer
    ) {

      clearTimeout(
        this.rippleTimer
      );

    }

  }

}