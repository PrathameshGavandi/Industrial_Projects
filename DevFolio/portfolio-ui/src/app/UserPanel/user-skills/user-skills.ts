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

  skills: any[][] = []; /* HTML च्या रचनेनुसार २-डायमेंशनल रो ॲरे */
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
        // नेटवर्क लॉगमधील ॲरे स्ट्रक्चरनुसार [0] इंडेक्सवरील ऑब्जेक्ट सुरक्षितपणे मिळवणे
        if (Array.isArray(res) && res.length > 0) {
          this.rawSkills = res[0];
        } else {
          this.rawSkills = res;
        }
        
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
     CREATE ROWS (डेटाबेसमधील सर्व १२ रकाने मॅप केले आहेत)
  ========================================== */
  private createSkillRows(): void {
    this.skills = [];
    
    if (!this.rawSkills) {
      return;
    }

    const skillData = this.rawSkills;

    // कॉमा-सेपरेटेड मजकुराचे ॲरेमध्ये रूपांतर करण्यासाठी हेल्पर फंक्शन
    const parseValues = (text: string): string[] => {
      return text ? text.split(',').map((t: string) => t.trim()).filter(Boolean) : [];
    };

    // डेटाबेसमधील सर्व १२ कीवर्ड्सना स्वतंत्र आणि अर्थपूर्ण नावे देऊन मॅप करणे
    const formattedSkills = [
      { label: 'Procedure Oriented Programming', values: parseValues(skillData.pop) },
      { label: 'Object Oriented Programming', values: parseValues(skillData.oop) },
      { label: 'Virtual Machine Languages', values: parseValues(skillData.vm) },
      { label: 'Backend Frameworks', values: parseValues(skillData.fw) },
      { label: 'Scripting Languages', values: parseValues(skillData.script) },
      { label: 'Web Technologies', values: parseValues(skillData.web) },
      { label: 'Integrated Development Environments (IDE)', values: parseValues(skillData.ide) },
      { label: 'Application & Web Servers', values: parseValues(skillData.server) },
      { label: 'Version Control Systems', values: parseValues(skillData.vcs) },
      { label: 'Databases & Query Languages', values: parseValues(skillData.db) },
      { label: 'Operating Systems', values: parseValues(skillData.os) },
      { label: 'Development Methodologies', values: parseValues(skillData.method) }
    ].filter(skill => skill.values.length > 0); // फक्त डेटा असलेला रकानाच फ्रंटエンドला दाखवेल

    // सीएसएस ग्रिड लेआउटसाठी एका ओळीत २ कार्ड्स गोळा करणे
    const rowSize = 2;
    for (let i = 0; i < formattedSkills.length; i += rowSize) {
      this.skills.push(formattedSkills.slice(i, i + rowSize));
    }
  }

  /* ==========================================
     मिसिंग फंक्शन्स
  ========================================== */
  getSkillNumber(rowIndex: number, cardIndex: number): string {
    const num = (rowIndex * 2) + cardIndex + 1;
    return num.toString().padStart(2, '0');
  }

  trackByRow(index: number, item: any): any {
    return index;
  }

  trackBySkill(index: number, item: any): any {
    return item.label || index;
  }

  trackByValue(index: number, item: string): string {
    return item || index.toString();
  }
}
