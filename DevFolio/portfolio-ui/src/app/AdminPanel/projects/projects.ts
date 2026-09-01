import { Component, ViewChild, ChangeDetectorRef, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { ProjectsService } from '../../Services/ProjectsService';
import Swal, { SweetAlertResult } from 'sweetalert2';

@Component({
  selector: 'app-projects',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './projects.html',
  styleUrls: ['./projects.scss']
})
export class ProjectsComponent implements OnInit {

  projects: any[] = [];

  project = {
    name: '',
    type: '',
    description: '',
    technologies: ''
  };

  @ViewChild('projectForm') projectForm!: NgForm;

  constructor(
    private projectsService: ProjectsService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadProjects();
  }

  loadProjects(): void {
    this.projectsService.getAllProjects().subscribe({
      next: (res) => {
        this.projects = res || [];
        this.cdr.detectChanges(); // immediate table update
      },
      error: () => {
        Swal.fire('Error', 'Failed to load projects', 'error');
      }
    });
  }

  saveProject(form: NgForm): void {
    if (form.invalid) return;

    this.projectsService.saveProject(this.project).subscribe({
      next: () => {
        Swal.fire('Success', 'Project saved successfully', 'success');

        // Reset object
        this.project = {
          name: '',
          type: '',
          description: '',
          technologies: ''
        };

        if (this.projectForm) this.projectForm.resetForm(); // reset form
        this.loadProjects(); // reload table
      },
      error: () => {
        Swal.fire('Error', 'Failed to save project', 'error');
      }
    });
  }

  deleteProject(id: number): void {
    Swal.fire({
      title: 'Are you sure?',
      text: 'This project will be deleted!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it',
      cancelButtonText: 'Cancel'
    }).then((result: SweetAlertResult) => {
      if (result.isConfirmed) {
        this.projectsService.deleteProject(id).subscribe({
          next: () => {
            Swal.fire('Deleted', 'Project deleted successfully', 'success');
            this.loadProjects();
          },
          error: () => {
            Swal.fire('Error', 'Failed to delete project', 'error');
          }
        });
      }
    });
  }
}
