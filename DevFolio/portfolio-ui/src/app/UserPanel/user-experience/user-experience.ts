import {
Component,
EventEmitter,
Output,
OnInit
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { ExperienceService }
from '../../Services/ExperienceService';

import {
Observable,
catchError,
of,
finalize,
shareReplay
} from 'rxjs';

export interface Experience {

id?: number;

company: string;

role: string;

duration: string;

description: string;

}

@Component({

selector: 'app-user-experience',

standalone: true,

imports: [
CommonModule
],

templateUrl: './user-experience.html',

styleUrls: ['./user-experience.scss']

})

export class UserExperienceComponent
implements OnInit {

@Output()
loaded = new EventEmitter<void>();

experiences$!:
Observable<Experience[]>;

constructor(
private experienceService:
ExperienceService
) {}

ngOnInit(): void {

 
this.loadExperiences();
 

}

private loadExperiences(): void {

 
this.experiences$ =

  this.experienceService
    .getallExperiences()
    .pipe(


      catchError((error) => {


        console.error(
          'Experience API Error:',
          error
        );


        return of([]);

      }),


      finalize(() => {

        this.loaded.emit();

      }),


      shareReplay(1)

    );
 

}

trackById(
index: number,
exp: Experience
): number {

 
return exp.id ?? index;
 

}

getDescriptionPoints(
description: string | string[]
): string[] {

 
if (
  Array.isArray(description)
) {

  return description;

}


if (!description) {

  return [];

}


return description
  .split('||')
  .map(point => point.trim())
  .filter(point => point.length > 0);
 

}

}
