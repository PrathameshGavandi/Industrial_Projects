import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExperienceService } from '../../Services/ExperienceService';

@Component({
  selector: 'app-user-experience',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-experience.html',
  styleUrls: ['./user-experience.scss']
})
export class UserExperienceComponent implements OnInit {

  experiences: any[] = [];
  isLoading = true;

  constructor(
    private experienceService: ExperienceService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadExperiences();
  }

  /* ==========================================
     LOAD EXPERIENCE
  ========================================== */
  loadExperiences(): void {
    this.isLoading = true;

    this.experienceService.getallExperiences().subscribe({
      next: (res: any[]) => {
        this.experiences = res || [];
        this.isLoading = false;
        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('Experience API Error:', error);
        this.experiences = [];
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

  // ३. अनुभवाचे वर्णन पॉईंट्समध्ये (Array) रुपांतरित करण्यासाठी फंक्शन
  getDescriptionPoints(description: string): string[] {
    if (!description) return [];
    // जर डिस्क्रिप्शनमध्ये फुलस्टॉप (.) किंवा स्वल्पविराम (,) असेल तर त्यानुसार त्याचे तुकडे पाडून लिस्ट बनवेल
    return description.split('.').map(point => point.trim()).filter(point => point.length > 0);
  }
}
