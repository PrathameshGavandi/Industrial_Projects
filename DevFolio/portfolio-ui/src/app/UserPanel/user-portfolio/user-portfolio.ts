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


  /* Loader initially visible */
  isLoading = true;


  /* Button initially disabled */
  showContinueButton = false;


  /* EXACTLY 9 SECONDS */
  private readonly LOADING_TIME = 9000;


  private loadingTimer?: ReturnType<typeof setTimeout>;


  constructor(
    private cdr: ChangeDetectorRef
  ) {}


  ngOnInit(): void {

    this.startLoader();

  }


  private startLoader(): void {

    this.isLoading = true;

    this.showContinueButton = false;


    this.loadingTimer = setTimeout(() => {

      /* 9 seconds completed */

      this.showContinueButton = true;


      /*
       * IMPORTANT:
       * Force Angular UI refresh immediately
       *
       * त्यामुळे click करण्याची गरज पडणार नाही
       */
      this.cdr.detectChanges();


    }, this.LOADING_TIME);

  }


  goToContent(): void {

    /*
     * सुरक्षा:
     * 9 sec आधी click झालं तरी काही होणार नाही
     */
    if (!this.showContinueButton) {

      return;

    }


    /* Remove loader */
    this.isLoading = false;


    /* Refresh UI */
    this.cdr.detectChanges();


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


  ngOnDestroy(): void {

    if (this.loadingTimer) {

      clearTimeout(this.loadingTimer);

    }

  }

}