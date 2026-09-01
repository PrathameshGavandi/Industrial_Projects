import { AfterViewInit, Component } from '@angular/core';

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

  ngAfterViewInit(): void {

    const sections =
      document.querySelectorAll('.portfolio-section');

    const observer = new IntersectionObserver(
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