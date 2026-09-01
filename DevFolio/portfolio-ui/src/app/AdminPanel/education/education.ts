import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { EducationService } from '../../Services/EducationService';
import Swal, { SweetAlertResult } from 'sweetalert2';

@Component({
  selector: 'app-education',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './education.html',
  styleUrls: ['./education.scss']
})
export class EducationComponent implements OnInit {

  educations: any[] = [];

  education = {
    degree: '',
    specialization: '',
    college: '',
    university: '',
    location: '',
    passingYear: null,
    cgpa: null
  };

  @ViewChild('eduForm') eduForm!: NgForm;

  constructor(
    private eduService: EducationService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadEducations();
  }

  loadEducations(): void {
    this.eduService.getAllEducations().subscribe({
      next: (res) => {
        this.educations = res || [];
        this.cdr.detectChanges(); // immediate table update
      },
      error: () => {
        Swal.fire('Error', 'Failed to load education records', 'error');
      }
    });
  }

  saveEducation(form: NgForm): void {
    if (form.invalid) return;

    this.eduService.saveEducation(this.education).subscribe({
      next: () => {
        Swal.fire('Success', 'Education saved successfully', 'success');

        // Reset model
        this.education = {
          degree: '',
          specialization: '',
          college: '',
          university: '',
          location: '',
          passingYear: null,
          cgpa: null
        };

        if (this.eduForm) this.eduForm.resetForm();
        this.loadEducations();
      },
      error: () => {
        Swal.fire('Error', 'Failed to save education', 'error');
      }
    });
  }

  deleteEducation(id: number): void {
    Swal.fire({
      title: 'Are you sure?',
      text: 'This education record will be deleted!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it',
      cancelButtonText: 'Cancel'
    }).then((result: SweetAlertResult) => {
      if (result.isConfirmed) {
        this.eduService.deleteEducation(id).subscribe({
          next: () => {
            Swal.fire('Deleted', 'Education deleted successfully', 'success');
            this.loadEducations();
          },
          error: () => {
            Swal.fire('Error', 'Failed to delete education', 'error');
          }
        });
      }
    });
  }

}
