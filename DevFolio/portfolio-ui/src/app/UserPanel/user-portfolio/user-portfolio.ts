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


  /*
   * Loader visible initially
   */
  isLoading = true;


  /*
   * Continue button hidden initially
   */
  showContinueButton = false;


  /*
   * EXACTLY 9 SECONDS
   */
  private readonly LOADING_TIME = 9000;


  private loadingTimer?: ReturnType<typeof setTimeout>;


  /*
   * Component starts
   */
  ngOnInit(): void {

    this.startLoader();

  }


  /*
   * Start loader automatically
   */
  private startLoader(): void {

    this.isLoading = true;

    this.showContinueButton = false;


    /*
     * After EXACTLY 9 seconds
     *
     * Button appears automatically
     *
     * NO CLICK REQUIRED
     */
    this.loadingTimer = setTimeout(() => {

      this.showContinueButton = true;

    }, this.LOADING_TIME);

  }


  /*
   * Called when user clicks:
   * Click Here to Explore
   */
  goToContent(): void {

    /*
     * Remove loader
     */
    this.isLoading = false;


    /*
     * Enable portfolio
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


  /*
   * Clear timer when component destroyed
   */
  ngOnDestroy(): void {

    if (this.loadingTimer) {

      clearTimeout(this.loadingTimer);

    }

  }

}