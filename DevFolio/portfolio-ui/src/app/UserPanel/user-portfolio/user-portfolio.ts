import { Component, OnDestroy, OnInit } from '@angular/core';
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
export class UserPortfolioComponent implements OnInit, OnDestroy {

  isLoading = true;
  showContinueButton = false;

  // Loader will stay for exactly 9 seconds
  private readonly LOADING_DURATION = 9000;

  private loadingTimer?: ReturnType<typeof setTimeout>;

  ngOnInit(): void {
    this.loadingTimer = setTimeout(() => {
      this.showContinueButton = true;
    }, this.LOADING_DURATION);
  }

  goToContent(): void {
    this.isLoading = false;

    setTimeout(() => {
      const profileSection = document.getElementById('profile');

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