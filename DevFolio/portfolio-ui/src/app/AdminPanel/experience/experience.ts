import { Component, ViewChild, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { ExperienceService } from '../../Services/ExperienceService';
import Swal, { SweetAlertResult } from 'sweetalert2';

@Component({
  selector: 'app-experience',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './experience.html',
  styleUrls: ['./experience.scss']
})
export class ExperienceComponent implements OnInit {

  experiences: any[] = [];

  experience = {
    company: '',
    role: '',
    duration: '',
    description: ''
  };

  @ViewChild('ExperienceForm') ExperienceForm!: NgForm;

  constructor(
    private experienceService: ExperienceService,
    private cdr: ChangeDetectorRef // 🔹 Inject ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadExperiences();
  }

  loadExperiences(): void {
    this.experienceService.getallExperiences().subscribe({
      next: (res) => {
        this.experiences = res || [];
        this.cdr.detectChanges(); // 🔹 force Angular to update table immediately
      },
      error: () => {
        Swal.fire('Error', 'Failed to load experiences', 'error');
      }
    });
  }

  saveExperience(form: NgForm): void {
    if (form.invalid) return;

    this.experienceService.saveExperience(this.experience).subscribe({
      next: () => {
        Swal.fire('Success', 'Experience saved successfully', 'success');

        // Reset object
        this.experience = {
          company: '',
          role: '',
          duration: '',
          description: ''
        };

        if (this.ExperienceForm) this.ExperienceForm.resetForm(); // 🔹 reset form
        this.loadExperiences(); // 🔹 reload table
      },
      error: () => {
        Swal.fire('Error', 'Failed to save experience', 'error');
      }
    });
  }

  deleteExperience(id: number): void {
    Swal.fire({
      title: 'Are you sure?',
      text: 'This record will be deleted!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it',
      cancelButtonText: 'Cancel'
    }).then((result: SweetAlertResult) => {
      if (result.isConfirmed) {
        this.experienceService.deleteExperience(id).subscribe({
          next: () => {
            Swal.fire('Deleted', 'Experience deleted successfully', 'success');
            this.loadExperiences(); // 🔹 reload table immediately
          },
          error: () => {
            Swal.fire('Error', 'Failed to delete experience', 'error');
          }
        });
      }
    });
  }
}
