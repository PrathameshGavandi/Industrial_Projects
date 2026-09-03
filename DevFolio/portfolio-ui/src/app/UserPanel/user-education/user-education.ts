import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EducationService, Education } from '../../Services/EducationService';
import { Observable, catchError, of, tap } from 'rxjs';

@Component({

  selector: 'app-user-education',

  standalone: true,

  imports: [CommonModule],

  templateUrl: './user-education.html',

  styleUrls: ['./user-education.scss']

})

export class UserEducationComponent {

  @Output() loaded = new EventEmitter<void>();

  educations$!: Observable<Education[]>;

  constructor(private educationService: EducationService) {

    this.loadEducations();

  }

  loadEducations(): void {

    this.educations$ = this.educationService
      .getAllEducations()
      .pipe(

        tap(() => {
          this.loaded.emit();
        }),

        catchError((error) => {

          console.error('Education API Error:', error);

          this.loaded.emit();

          return of([]);

        })

      );

  }

  trackById(index: number, edu: Education): number {

    return edu.id ?? index;

  }

}