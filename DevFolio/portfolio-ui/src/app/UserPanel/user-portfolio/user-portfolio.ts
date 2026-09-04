import {
Component,
OnInit,
OnDestroy,
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

/* ==========================================
LOADER STATE
========================================== */

isLoading = true;

showContinueButton = false;

progressValue = 0;

/* ==========================================
COMPONENT STATUS
========================================== */

private componentStatus: Record<string, boolean> = {

 
profile: false,

skills: false,

experience: false,

projects: false,

education: false
 

};

/* ==========================================
MAXIMUM LOADING TIME

 
 10 seconds maximum
 

========================================== */

private readonly MAX_LOADING_TIME = 10000;

private fallbackTimer?: ReturnType<typeof setTimeout>;

constructor(
private cdr: ChangeDetectorRef
) {}

ngOnInit(): void {

 
this.startLoader();
 

}

private startLoader(): void {

 
this.isLoading = true;

this.showContinueButton = false;

this.progressValue = 0;


this.componentStatus = {

  profile: false,

  skills: false,

  experience: false,

  projects: false,

  education: false

};


/* Maximum 10 seconds */

this.fallbackTimer = setTimeout(() => {


  if (!this.showContinueButton) {


    console.warn(
      'Maximum loading time reached.'
    );


    this.finishLoading();

  }


}, this.MAX_LOADING_TIME);
 

}

/* ==========================================
CHILD COMPONENT LOADED
========================================== */

onComponentLoaded(
componentName: string
): void {

 
/* Avoid duplicate events */

if (
  this.componentStatus[componentName]
) {

  return;

}


this.componentStatus[componentName] = true;


const totalComponents =
  Object.keys(
    this.componentStatus
  ).length;


const loadedComponents =
  Object.values(
    this.componentStatus
  ).filter(Boolean)
  .length;


this.progressValue = Math.round(

  (
    loadedComponents /
    totalComponents
  ) * 100

);


console.log(

  `Loaded: ${componentName}`,

  `${loadedComponents}/${totalComponents}`

);


/* All APIs finished */

if (
  loadedComponents === totalComponents
) {

  this.finishLoading();

}


this.cdr.detectChanges();
 

}

/* ==========================================
FINISH LOADING
========================================== */

private finishLoading(): void {

 
if (
  this.showContinueButton
) {

  return;

}


this.progressValue = 100;

this.showContinueButton = true;


if (
  this.fallbackTimer
) {

  clearTimeout(
    this.fallbackTimer
  );

  this.fallbackTimer = undefined;

}


console.log(
  '🚀 Portfolio loading completed!'
);


this.cdr.detectChanges();
 

}

/* ==========================================
ENTER PORTFOLIO
========================================== */

goToContent(): void {

 
if (
  !this.showContinueButton
) {

  return;

}


this.isLoading = false;


this.cdr.detectChanges();


setTimeout(() => {


  const profileSection =
    document.getElementById(
      'profile'
    );


  if (
    profileSection
  ) {

    profileSection.scrollIntoView({

      behavior: 'smooth',

      block: 'start'

    });

  }


}, 100);
 

}

ngOnDestroy(): void {

 
if (
  this.fallbackTimer
) {

  clearTimeout(
    this.fallbackTimer
  );

}
 

}

}
