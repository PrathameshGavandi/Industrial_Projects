import {
  AfterViewInit,
  Component,
  OnDestroy
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
  implements AfterViewInit, OnDestroy {


  /*
   * Loading screen is visible initially
   */
  isLoading = true;


  /*
   * Button will appear after 8 seconds
   */
  showContinueButton = false;


  /*
   * 8 seconds loading time
   */
  private readonly LOADING_TIME = 8000;


  private loadingTimer?: ReturnType<typeof setTimeout>;


  ngAfterViewInit(): void {

    /*
     * Keep loading screen for exactly 8 seconds
     */
    this.loadingTimer = setTimeout(() => {

      this.showContinueButton = true;

    }, this.LOADING_TIME);

  }


  /*
   * User clicks:
   *
   * Explore My Portfolio →
   */
  goToContent(): void {

    /*
     * Hide loading screen
     */
    this.isLoading = false;


    /*
     * Wait for loader DOM to disappear
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

    }, 150);

  }


  ngOnDestroy(): void {

    if (this.loadingTimer) {

      clearTimeout(this.loadingTimer);

    }

  }

}