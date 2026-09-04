import {
  Component,
  EventEmitter,
  Output,
  OnInit
} from '@angular/core';

import { CommonModule } from '@angular/common';

import {
  EducationService,
  Education
} from '../../Services/EducationService';

import {
  Observable,
  catchError,
  of,
  finalize,
  shareReplay
} from 'rxjs';


@Component({

  selector: 'app-user-education',

  standalone: true,

  imports: [
    CommonModule
  ],

  templateUrl: './user-education.html',

  styleUrls: ['./user-education.scss']

})


export class UserEducationComponent
  implements OnInit {


  /* =====================================================
     LOADING EVENT
  ===================================================== */

  @Output()
  loaded = new EventEmitter<void>();


  /* =====================================================
     EDUCATION DATA
  ===================================================== */

  educations$!: Observable<Education[]>;


  /* =====================================================
     CONSTRUCTOR
  ===================================================== */

  constructor(
    private educationService: EducationService
  ) {}


  /* =====================================================
     INIT
  ===================================================== */

  ngOnInit(): void {

    this.loadEducations();

  }


  /* =====================================================
     LOAD EDUCATION
  ===================================================== */

  private loadEducations(): void {

    this.educations$ = this.educationService
      .getAllEducations()
      .pipe(

        catchError((error) => {

          console.error(
            'Education API Error:',
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


  /* =====================================================
     TRACK BY
  ===================================================== */

  trackById(
    index: number,
    edu: Education
  ): number {

    return edu.id ?? index;

  }

}