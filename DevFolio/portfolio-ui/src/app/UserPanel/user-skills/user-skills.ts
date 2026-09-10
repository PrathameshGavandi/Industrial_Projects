import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SkillsService } from '../../Services/SkillsService';

@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-skills.html',
  styleUrls: ['./user-skills.scss']
})
export class UserSkillsComponent implements OnInit {

  skills: any[][] = []; /* HTML मध्ये `skills` लूप फिरवला आहे, म्हणून `skillRows` ऐवजी याला रो-ॲरे बनवले */
  rawSkills: any[] = [];
  isLoading = true;

  constructor(
    private skillsService: SkillsService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadSkills();
  }

  /* ==========================================
     LOAD SKILLS
  ========================================== */
  loadSkills(): void {
    this.isLoading = true;

    this.skillsService.getAllSkills().subscribe({
      next: (res: any[]) => {
        this.rawSkills = res || [];
        this.createSkillRows();
        this.isLoading = false;
        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('Skills API Error:', error);
        this.skills = [];
        this.rawSkills = [];
        this.isLoading = false;
        this.cdr.detectChanges();
      }
    });
  }

  /* ==========================================
     CREATE ROWS
  ========================================== */
  private createSkillRows(): void {
    this.skills = [];
    const rowSize = 2; /* तुमच्या CSS डिझाइननुसार २ कार्ड्सची एक रो बनवली */

    // बॅकएंड डेटा फॉरमॅट करणे (उदा. कॉमा सेपरेटेड व्हॅल्यूजचा ॲरे बनवणे)
    const formattedSkills = this.rawSkills.map(skill => ({
      ...skill,
      values: skill.technologies 
        ? skill.technologies.split(',').map((t: string) => t.trim()).filter(Boolean)
        : (skill.values || [])
    }));

    for (let i = 0; i < formattedSkills.length; i += rowSize) {
      this.skills.push(formattedSkills.slice(i, i + rowSize));
    }
  }

  /* ==========================================
     मिसिंग फंक्शन्स (ज्यामुळे एरर येत होता)
  ========================================== */

  // १. स्किल्सचा अनुक्रमांक काढण्यासाठी (उदा. 01, 02)
  getSkillNumber(rowIndex: number, cardIndex: number): string {
    const num = (rowIndex * 2) + cardIndex + 1;
    return num.toString().padStart(2, '0');
  }

  // २. रो लूप ट्रॅकिंग
  trackByRow(index: number, item: any): any {
    return index;
  }

  // ३. स्किल कार्ड लूप ट्रॅकिंग
  trackBySkill(index: number, item: any): any {
    return item.id || index;
  }

  // ४. चीप/व्हॅल्यू लूप ट्रॅकिंग
  trackByValue(index: number, item: string): string {
    return item || index.toString();
  }
}
