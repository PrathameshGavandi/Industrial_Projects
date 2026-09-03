import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExperienceService } from '../../Services/ExperienceService';
import { Observable, catchError, of, tap } from 'rxjs';

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

  imports: [CommonModule],

  templateUrl: './user-experience.html',

  styleUrl: './user-experience.scss',

})

export class UserExperienceComponent {

  @Output() loaded = new EventEmitter<void>();

  experiences$!: Observable<Experience[]>;

  constructor(private experienceService: ExperienceService) {

    this.loadExperiences();

  }

  loadExperiences() {

    this.experiences$ = this.experienceService
      .getallExperiences()
      .pipe(

        tap(() => {
          this.loaded.emit();
        }),

        catchError((error) => {

          console.error('Experience API Error:', error);

          this.loaded.emit();

          return of([]);

        })

      );

  }

  trackById(index: number, exp: Experience): number {

    return exp.id ?? index;

  }

  getDescriptionPoints(description: string | string[]): string[] {

    if (Array.isArray(description)) {
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