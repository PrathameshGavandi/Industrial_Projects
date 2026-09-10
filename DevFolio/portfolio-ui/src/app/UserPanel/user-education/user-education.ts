import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EducationService, Education } from '../../Services/EducationService';

@Component({
  selector: 'app-user-education',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-education.html',
  styleUrls: ['./user-education.scss']
})
export class UserEducationComponent implements OnInit {

  educations: Education[] = [];
  isLoading = true;

  constructor(
    private educationService: EducationService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadEducations();
  }

  /* ==========================================
     LOAD EDUCATION
  ========================================== */
  loadEducations(): void {
    this.isLoading = true;

    this.educationService.getAllEducations().subscribe({
      next: (res: Education[]) => {
        this.educations = res || [];
        this.isLoading = false;
        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('Education API Error:', error);
        this.educations = [];
        this.isLoading = false;
        this.cdr.detectChanges();
      }
    });
  }

  /* ==========================================
     मिसिंग फंक्शन्स (ज्यामुळे एरर येत होता)
  ========================================== */
  
  // १. अनुक्रमांक फॉरमॅट करण्यासाठी (उदा. 01, 02)
  getNumber(index: number): string {
    return (index + 1).toString().padStart(2, '0');
  }

  // २. *ngFor लूपचा परफॉर्मन्स वाढवण्यासाठी ट्रॅकिंग फंक्शन
  trackById(index: number, item: any): any {
    return item.id || index;
  }
}
