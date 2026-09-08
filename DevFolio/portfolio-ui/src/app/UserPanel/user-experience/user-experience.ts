import {
  Component,
  OnInit
} from '@angular/core';

import { CommonModule }
  from '@angular/common';

import { ExperienceService }
  from '../../Services/ExperienceService';

import {
  Observable,
  catchError,
  of,
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

  templateUrl:
    './user-experience.html',

  styleUrls: [
    './user-experience.scss'
  ]

})


export class UserExperienceComponent
  implements OnInit {


  experiences$!:
    Observable<Experience[]>;


  constructor(
    private experienceService:
      ExperienceService
  ) {}


  /* =====================================================
     INIT
  ===================================================== */

  ngOnInit(): void {

    /*
     * Experience API starts immediately.
     *
     * It does not wait for portfolio loader.
     */

    this.loadExperiences();

  }


  /* =====================================================
     LOAD EXPERIENCE
  ===================================================== */

  private loadExperiences(): void {

    this.experiences$ =

      this.experienceService

        .getallExperiences()

        .pipe(


          /* ==============================================
             API ERROR
          ============================================== */

          catchError((error) => {

            console.error(
              'Experience API Error:',
              error
            );

            /*
             * Experience component handles
             * its own API failure.
             */

            return of(
              [] as Experience[]
            );

          }),


          /*
           * No finalize().
           *
           * Parent loader is completely
           * independent.
           */


          /* ==============================================
             CACHE
          ============================================== */

          shareReplay({

            bufferSize: 1,

            refCount: true

          })

        );

  }


  /* =====================================================
     TRACK BY ID
  ===================================================== */

  trackById(
    index: number,
    exp: Experience
  ): number {

    return exp.id ?? index;

  }


  /* =====================================================
     EXPERIENCE NUMBER
  ===================================================== */

  getNumber(
    index: number
  ): string {

    return (

      index + 1

    )
      .toString()
      .padStart(2, '0');

  }


  /* =====================================================
     DESCRIPTION POINTS
  ===================================================== */

  getDescriptionPoints(
    description:
      string | string[]
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

      .map(
        point =>
          point.trim()
      )

      .filter(
        point =>
          point.length > 0
      );

  }

}