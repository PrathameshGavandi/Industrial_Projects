import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { EducationService, Education } from '../../Services/EducationService';

@Component({
  selector: 'app-user-education',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-education.html',
  styleUrls: ['./user-education.scss']
})
export class UserEducationComponent {

  educations$!: Observable<Education[]>;

  constructor(private educationService: EducationService) {
    this.loadEducations();
  }

  loadEducations(): void {
    this.educations$ = this.educationService.getAllEducations();
  }

  trackById(index: number, edu: Education): number {
    return edu.id ?? index;
  }
}
