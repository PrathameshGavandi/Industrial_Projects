import {
  Component,
  OnInit,
  ChangeDetectorRef
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { SkillsService } from '../../Services/SkillsService';


@Component({
  selector: 'app-skills',
  standalone: true,

  imports: [
    CommonModule
  ],

  templateUrl: './user-skills.html',
  styleUrls: ['./user-skills.scss']
})


export class UserSkillsComponent
  implements OnInit {


  skills: any[] = [];

  skillRows: any[][] = [];

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

     Direct API subscription.
  ========================================== */

  loadSkills(): void {

    this.isLoading = true;


    this.skillsService
      .getAllSkills()
      .subscribe({

        next: (res: any[]) => {

          this.skills = res || [];

          this.createSkillRows();

          this.isLoading = false;

          this.cdr.detectChanges();

        },


        error: (error) => {

          console.error(
            'Skills API Error:',
            error
          );

          this.skills = [];

          this.skillRows = [];

          this.isLoading = false;

          this.cdr.detectChanges();

        }

      });

  }


  /* ==========================================
     CREATE ROWS
  ========================================== */

  private createSkillRows(): void {

    this.skillRows = [];

    const rowSize = 3;


    for (
      let i = 0;
      i < this.skills.length;
      i += rowSize
    ) {

      this.skillRows.push(
        this.skills.slice(
          i,
          i + rowSize
        )
      );

    }

  }

}