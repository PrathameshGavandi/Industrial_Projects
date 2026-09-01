import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExperienceService } from '../../Services/ExperienceService';
import { Observable } from 'rxjs';

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

  experiences$!: Observable<Experience[]>;

  constructor(private experienceService: ExperienceService) {
    this.loadExperiences();
  }

  loadExperiences() {
    this.experiences$ = this.experienceService.getallExperiences();
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
