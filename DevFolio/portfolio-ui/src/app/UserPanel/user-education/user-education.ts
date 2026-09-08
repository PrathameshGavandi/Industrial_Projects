import {
  Component,
  OnInit,
  ChangeDetectorRef
} from '@angular/core';

import { CommonModule } from '@angular/common';

import {
  EducationService,
  Education
} from '../../Services/EducationService';


@Component({
  selector: 'app-user-education',
  standalone: true,

  imports: [
    CommonModule
  ],

  templateUrl: './user-education.html',
  styleUrls: ['./user-education.scss']
})


export class UserEducationComponent
  implements OnInit {


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

     Direct API subscription like Admin panel.
  ========================================== */

  loadEducations(): void {

    this.isLoading = true;


    this.educationService
      .getAllEducations()
      .subscribe({

        next: (res: Education[]) => {

          this.educations = res || [];

          this.isLoading = false;

          /*
           * Immediate UI update.
           */
          this.cdr.detectChanges();

        },


        error: (error) => {

          console.error(
            'Education API Error:',
            error
          );

          this.educations = [];

          this.isLoading = false;

          this.cdr.detectChanges();

        }

      });

  }

}