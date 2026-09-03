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


  isLoading = true;


  /*
   * Minimum loader duration
   * 7 seconds
   */
  private readonly MIN_LOADING_TIME = 7000;


  private loadingStartTime = Date.now();


  /*
   * Track API completion
   */
  private loadedSections = new Set<string>();


  private readonly TOTAL_SECTIONS = 5;


  ngAfterViewInit(): void {

    this.loadingStartTime = Date.now();

  }


  /*
   * Called by child components
   * when their API data is ready.
   */
  onSectionLoaded(section: string): void {

    this.loadedSections.add(section);


    console.log(
      `Portfolio section loaded: ${section}`
    );


    /*
     * Check whether all APIs
     * are completed.
     */
    if (
      this.loadedSections.size ===
      this.TOTAL_SECTIONS
    ) {

      this.finishLoadingWhenReady();

    }

  }


  private finishLoadingWhenReady(): void {

    const elapsed =
      Date.now() - this.loadingStartTime;


    const remainingTime =
      Math.max(
        0,
        this.MIN_LOADING_TIME - elapsed
      );


    /*
     * If backend is already ready,
     * wait only until 7 seconds.
     *
     * If backend took longer,
     * remainingTime becomes 0
     * and portfolio opens immediately.
     */
    setTimeout(() => {

      this.isLoading = false;


      /*
       * Wait for Angular DOM update
       * before initializing animations.
       */
      setTimeout(() => {

        this.initializeSectionAnimations();

      }, 50);

    }, remainingTime);

  }


  private initializeSectionAnimations(): void {

    const sections =
      document.querySelectorAll(
        '.portfolio-section'
      );


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


  ngOnDestroy(): void {

    this.isLoading = false;

  }

}