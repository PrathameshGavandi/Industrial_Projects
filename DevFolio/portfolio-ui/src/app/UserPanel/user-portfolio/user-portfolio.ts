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
   * Loading screen visible initially
   */
  isLoading = true;


  /*
   * After 6 seconds,
   * show the "Go To Content" button
   */
  showContinueButton = false;


  private loadingTimer?: ReturnType<typeof setTimeout>;


  ngAfterViewInit(): void {

    this.loadingTimer = setTimeout(() => {

      this.showContinueButton = true;

    }, 6000);

  }


  /*
   * User clicks the button
   */
  goToContent(): void {

    /*
     * Remove loading screen
     */
    this.isLoading = false;


    /*
     * Wait until loader disappears
     * and DOM becomes available.
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