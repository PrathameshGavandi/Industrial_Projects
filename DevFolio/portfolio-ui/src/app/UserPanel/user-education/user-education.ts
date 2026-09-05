import {
  Component,
  EventEmitter,
  OnInit,
  Output
} from '@angular/core';

import { CommonModule } from '@angular/common';

import {
  EducationService,
  Education
} from '../../Services/EducationService';

import {
  Observable,
  catchError,
  finalize,
  of,
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


  @Output()
  loaded = new EventEmitter<void>();


  educations$!: Observable<Education[]>;


  constructor(
    private educationService: EducationService
  ) {}


  ngOnInit(): void {

    this.loadEducations();

  }


  private loadEducations(): void {

    this.educations$ = this.educationService
      .getAllEducations()
      .pipe(

        catchError((error) => {

          console.error(
            'Education API Error:',
            error
          );

          return of([] as Education[]);

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
    edu: Education
  ): number {

    return edu.id ?? index;

  }


  getNumber(index: number): string {

    return (index + 1)
      .toString()
      .padStart(2, '0');

  }

}