import {
AfterViewInit,
Component
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { UserNav } from '../user-nav/user-nav';

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
implements AfterViewInit {

/*

* ---
* LOADING STATE
* ---
*
* Loader remains visible for 5 seconds.
*
* During this time:
* * Child components initialize
* * API calls can run in background
* * User cannot interact with portfolio
    */

isLoading = true;

/*

* ---
* AFTER VIEW INITIALIZATION
* ---

*/

ngAfterViewInit(): void {

 
/*
 * Keep the full-screen loading screen
 * visible for 5 seconds.
 */

setTimeout(() => {

  this.isLoading = false;


  /*
   * Start section animations only
   * after loading screen disappears.
   */

  this.initializeSectionAnimations();

}, 5000);
 

}

/*

* ---
* SECTION ANIMATIONS
* ---

*/

private initializeSectionAnimations(): void {

 
const sections =
  document.querySelectorAll(
    '.portfolio-section'
  );


/*
 * Intersection Observer
 *
 * Detects when portfolio sections
 * enter the viewport.
 */

const observer =
  new IntersectionObserver(

    (entries) => {

      entries.forEach((entry) => {

        if (entry.isIntersecting) {

          entry.target.classList.add(
            'show'
          );

        } else {

          entry.target.classList.remove(
            'show'
          );

        }

      });

    },

    {
      threshold: 0.05
    }

  );


/*
 * Observe every portfolio section.
 */

sections.forEach((section) => {

  observer.observe(section);

});
 

}

}
