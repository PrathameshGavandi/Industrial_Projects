import {
  Component,
  OnInit
} from '@angular/core';

import { CommonModule }
  from '@angular/common';

import {
  EducationService,
  Education
} from '../../Services/EducationService';

import {
  Observable,
  catchError,
  of,
  shareReplay
} from 'rxjs';


@Component({

  selector: 'app-user-education',

  standalone: true,

  imports: [
    CommonModule
  ],

  templateUrl:
    './user-education.html',

  styleUrls:
    ['./user-education.scss']

})


export class UserEducationComponent
  implements OnInit {


  educations$!:
    Observable<Education[]>;


  constructor(
    private educationService:
      EducationService
  ) {}


  /* =====================================================
     INIT
  ===================================================== */

  ngOnInit(): void {

    /*
     * Education API starts immediately.
     *
     * It does NOT wait for portfolio loader.
     */

    this.loadEducations();

  }


  /* =====================================================
     LOAD EDUCATION
  ===================================================== */

  private loadEducations(): void {

    this.educations$ =

      this.educationService

        .getAllEducations()

        .pipe(


          /* ==============================================
             API ERROR
          ============================================== */

          catchError((error) => {

            console.error(
              'Education API Error:',
              error
            );

            /*
             * Education component handles
             * its own API failure.
             */

            return of(
              [] as Education[]
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
    edu: Education
  ): number {

    return edu.id ?? index;

  }


  /* =====================================================
     EDUCATION NUMBER
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

}