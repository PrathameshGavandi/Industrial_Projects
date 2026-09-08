import {
  Component,
  OnInit,
  ChangeDetectorRef
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { ExperienceService } from '../../Services/ExperienceService';


@Component({
  selector: 'app-user-experience',
  standalone: true,

  imports: [
    CommonModule
  ],

  templateUrl: './user-experience.html',
  styleUrls: ['./user-experience.scss']
})


export class UserExperienceComponent
  implements OnInit {


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

     Direct subscription.
  ========================================== */

  loadExperiences(): void {

    this.isLoading = true;


    this.experienceService
      .getallExperiences()
      .subscribe({

        next: (res: any[]) => {

          this.experiences = res || [];

          this.isLoading = false;

          this.cdr.detectChanges();

        },


        error: (error) => {

          console.error(
            'Experience API Error:',
            error
          );

          this.experiences = [];

          this.isLoading = false;

          this.cdr.detectChanges();

        }

      });

  }

}