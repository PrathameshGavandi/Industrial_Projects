import {
AfterViewInit,
Component
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { UserNav } from '../user-nav/user-nav';
import { UserProfileComponent } from '../user-profile/user-profile';
import { UserSkillsComponent } from '../user-skills/user-skills';
import { UserExperienceComponent } from '../user-experience/user-experience';
import { UserProjectsComponent } from '../user-projects/user-projects';
import { UserEducationComponent } from '../user-education/user-education';

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
export class UserPortfolioComponent implements AfterViewInit {

/*

* Controls the full-screen loading screen.
*
* Initially true because the portfolio needs
* some time to fetch data from the backend.
  */
  isLoading = true;

ngAfterViewInit(): void {

 
/*
 * Give Angular some time to initialize the
 * child components and start their API calls.
 */
setTimeout(() => {

  this.isLoading = false;

  this.initializeSectionAnimations();

}, 1200);
 

}

private initializeSectionAnimations(): void {

 
const sections =
  document.querySelectorAll('.portfolio-section');


const observer =
  new IntersectionObserver(

    (entries) => {

      entries.forEach((entry) => {

        if (entry.isIntersecting) {

          entry.target.classList.add('show');

        } else {

          entry.target.classList.remove('show');

        }

      });

    },

    {
      threshold: 0.05
    }

  );


sections.forEach((section) => {

  observer.observe(section);

});
 

}

}
