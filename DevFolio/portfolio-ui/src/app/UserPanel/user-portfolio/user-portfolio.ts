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
   * Loader visible initially
   */
  isLoading = true;


  /*
   * Continue button hidden initially
   */
  showContinueButton = false;


  /*
   * EXACT 9 SECONDS
   *
   * 9000 milliseconds = 9 seconds
   */
  private readonly LOADING_TIME = 9000;


  private loadingTimer?: ReturnType<typeof setTimeout>;


  ngAfterViewInit(): void {

    /*
     * Start 9 second timer
     *
     * IMPORTANT:
     * Loader will NOT disappear automatically.
     *
     * After 9 seconds only the button will appear.
     */
    this.loadingTimer = setTimeout(() => {

      this.showContinueButton = true;

    }, this.LOADING_TIME);

  }


  /*
   * Called when user clicks:
   * "Click Here to Explore"
   */
  goToContent(): void {

    /*
     * Remove loader immediately
     */
    this.isLoading = false;


    /*
     * Allow portfolio interaction
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


  ngOnDestroy(): void {

    if (this.loadingTimer) {

      clearTimeout(this.loadingTimer);

    }

  }

}