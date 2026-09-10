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
  rawSkills: any = null; /* डेटाबेसचा मूळ ऑब्जेक्ट साठवण्यासाठी */
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
      next: (res: any) => {
        // जर बॅकएंडकडून ॲरे येत असेल तर पहिला ऑब्जेक्ट घ्या, अन्यथा थेट ऑब्जेक्ट वापरा
        this.rawSkills = Array.isArray(res) ? res[0] : res;
        
        this.createSkillRows();
        this.isLoading = false;
        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('Skills API Error:', error);
        this.skills = [];
        this.rawSkills = null;
        this.isLoading = false;
        this.cdr.detectChanges();
      }
    });
  }

  /* ==========================================
     CREATE ROWS (डेटाबेसच्या रचनेनुसार ६ स्वतंत्र कार्ड्स मॅपिंग)
  ========================================== */
  private createSkillRows(): void {
    this.skills = [];
    
    if (!this.rawSkills) {
      return;
    }

    const skillData = this.rawSkills;

    // डेटाबेसमधील अचूक फील्ड्स (pop, vm, fw, web, db, vcs) ६ कार्ड्समध्ये मॅप करणे
    const formattedSkills = [
      {
        label: 'Core Programming',
        values: skillData.pop ? skillData.pop.split(',').map((t: string) => t.trim()).filter(Boolean) : []
      },
      {
        label: 'Object-Oriented & VM Languages',
        values: skillData.vm ? skillData.vm.split(',').map((t: string) => t.trim()).filter(Boolean) : []
      },
      {
        label: 'Frameworks & Architectures',
        values: skillData.fw ? skillData.fw.split(',').map((t: string) => t.trim()).filter(Boolean) : []
      },
      {
        label: 'Web Technologies & APIs',
        values: skillData.web ? skillData.web.split(',').map((t: string) => t.trim()).filter(Boolean) : []
      },
      {
        label: 'Databases & Storage',
        values: skillData.db ? skillData.db.split(',').map((t: string) => t.trim()).filter(Boolean) : []
      },
      {
        label: 'Tools & DevOps (Version Control)',
        values: skillData.vcs ? skillData.vcs.split(',').map((t: string) => t.trim()).filter(Boolean) : []
      }
    ];

    // सीएसएस ग्रिड लेआउटसाठी एका ओळीत २ कार्ड्स गोळा करणे
    const rowSize = 2;
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
    return item.label || index;
  }

  // ४. चीप/व्हॅल्यू लूप ट्रॅकिंग
  trackByValue(index: number, item: string): string {
    return item || index.toString();
  }
}
