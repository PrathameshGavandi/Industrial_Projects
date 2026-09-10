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

  skills: any[][] = []; /* HTML च्या संरचनेनुसार तयार केलेला २-डायमेंशनल रो ॲरे */
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
     CREATE ROWS (डेटा मॅपिंग सुरक्षित करण्यासाठी अपडेटेड)
  ========================================== */
  private createSkillRows(): void {
    this.skills = [];
    const rowSize = 2; /* सीएसएस ग्रिड लेआउटसाठी एका ओळीत २ कार्ड्स */

    // डेटाबेस मधील व्हेरिएबल्सची नावे काहीही असली तरी त्यांना मॅप करणारे सेफ लॉजिक
    const formattedSkills = this.rawSkills.map(skill => {
      // १. स्किल कॅटेगरीचे नाव शोधणे (label किंवा category)
      const labelName = skill.label || skill.category || skill.name || 'Technical Expertise';
      
      // २. कॉमा-सेपरेटेड टेक्नॉलॉजीचे व्यवस्थित ॲरेमध्ये रुपांतर करणे
      let skillValues: string[] = [];
      const rawText = skill.technologies || skill.skills || skill.values;
      
      if (rawText) {
        if (Array.isArray(rawText)) {
          skillValues = rawText;
        } else if (typeof rawText === 'string') {
          skillValues = rawText.split(',').map((t: string) => t.trim()).filter(Boolean);
        }
      }

      return {
        ...skill,
        label: labelName,
        values: skillValues
      };
    });

    for (let i = 0; i < formattedSkills.length; i += rowSize) {
      this.skills.push(formattedSkills.slice(i, i + rowSize));
    }
  }

  /* ==========================================
     मिसिंग फंक्शन्स
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
