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

            return of([] as Experience[]);

          }),

          finalize(() => {

            this.loaded.emit();

          }),

          shareReplay({
            bufferSize: 1,
            refCount: true
          })

        );

  }


  trackById(
    index: number,
    exp: Experience
  ): number {

    return exp.id ?? index;

  }


  getNumber(index: number): string {

    return (index + 1)
      .toString()
      .padStart(2, '0');

  }


  getDescriptionPoints(
    description: string | string[]
  ): string[] {

    if (Array.isArray(description)) {

      return description;

    }


    if (!description) {

      return [];

    }


    return description
      .split('||')
      .map(point => point.trim())
      .filter(
        point => point.length > 0
      );

  }

}