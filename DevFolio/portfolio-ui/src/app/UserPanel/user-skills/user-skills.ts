import {
  Component,
  EventEmitter,
  Output,
  OnInit
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { SkillsService }
  from '../../Services/SkillsService';

import {
  Observable,
  map,
  catchError,
  of,
  finalize,
  shareReplay
} from 'rxjs';


interface SkillRow {

  label: string;

  values: string[];

}


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


  @Output()
  loaded = new EventEmitter<void>();


  /*
   * Every array inside this observable
   * represents ONE ROW.
   *
   * Example:
   *
   * [
   *   [skill1, skill2],
   *   [skill3, skill4],
   *   [skill5, skill6]
   * ]
   */

  skills$!:
    Observable<SkillRow[][]>;


  constructor(

    private skillsService:
      SkillsService

  ) {}


  ngOnInit(): void {

    this.loadSkills();

  }


  /* =====================================================
     LOAD SKILLS
  ===================================================== */

  private loadSkills(): void {

    this.skills$ =

      this.skillsService
        .getAllSkills()
        .pipe(

          /* ===============================================
             CONVERT API RESPONSE
          =============================================== */

          map((res: any[]) => {

            if (
              !res ||
              res.length === 0
            ) {

              return [];

            }


            const s = res[0];


            const skills: SkillRow[] = [

              {
                label:
                  'Procedural Oriented Programming',

                values:
                  s.pop?.split(',')
                  ?? []

              },


              {
                label:
                  'Object Oriented Programming',

                values:
                  s.oop?.split(',')
                  ?? []

              },


              {
                label:
                  'Virtual Machines Based',

                values:
                  s.vm?.split(',')
                  ?? []

              },


              {
                label:
                  'Frameworks',

                values:
                  s.fw?.split(',')
                  ?? []

              },


              {
                label:
                  'Scripting Languages',

                values:
                  s.script?.split(',')
                  ?? []

              },


              {
                label:
                  'Web Technologies',

                values:
                  s.web?.split(',')
                  ?? []

              },


              {
                label:
                  'IDEs & Tools',

                values:
                  s.ide?.split(',')
                  ?? []

              },


              {
                label:
                  'Servers',

                values:
                  s.server?.split(',')
                  ?? []

              },


              {
                label:
                  'Version Control System',

                values:
                  s.vcs?.split(',')
                  ?? []

              },


              {
                label:
                  'Database',

                values:
                  s.db?.split(',')
                  ?? []

              },


              {
                label:
                  'Operating Systems',

                values:
                  s.os?.split(',')
                  ?? []

              },


              {
                label:
                  'Methodologies',

                values:
                  s.method?.split(',')
                  ?? []

              }

            ];


            return this.groupSkills(
              skills
            );

          }),


          /* ===============================================
             ERROR HANDLING
          =============================================== */

          catchError((error) => {

            console.error(
              'Skills API Error:',
              error
            );

            return of([]);

          }),


          /* ===============================================
             LOADING COMPLETE
          =============================================== */

          finalize(() => {

            this.loaded.emit();

          }),


          shareReplay(1)

        );

  }


  /* =====================================================
     GROUP SKILLS INTO 2-CARD ROWS
  ===================================================== */

  private groupSkills(
    skills: SkillRow[]
  ): SkillRow[][] {

    const rows: SkillRow[][] = [];

    for (
      let i = 0;
      i < skills.length;
      i += 2
    ) {

      rows.push(
        skills.slice(
          i,
          i + 2
        )
      );

    }

    return rows;

  }


  /* =====================================================
     TRACK ROW
  ===================================================== */

  trackByRow(
    index: number
  ): number {

    return index;

  }


  /* =====================================================
     TRACK SKILL
  ===================================================== */

  trackBySkill(
    index: number,
    skill: SkillRow
  ): string {

    return skill.label;

  }


  /* =====================================================
     TRACK VALUE
  ===================================================== */

  trackByValue(
    index: number,
    value: string
  ): string {

    return value;

  }


  /* =====================================================
     CARD NUMBER
  ===================================================== */

  getSkillNumber(
    rowIndex: number,
    cardIndex: number
  ): string {

    const number =
      (rowIndex * 2) +
      cardIndex +
      1;

    return number
      .toString()
      .padStart(2, '0');

  }

}