import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectsService } from '../../Services/ProjectsService';
import { Observable, catchError, of, tap } from 'rxjs';

export interface Project {

  id?: number;
  name: string;
  type: string;
  description: string;
  technologies: string;

}

@Component({

  selector: 'app-user-projects',

  standalone: true,

  imports: [CommonModule],

  templateUrl: './user-projects.html',

  styleUrls: ['./user-projects.scss'],

})

export class UserProjectsComponent {

  @Output() loaded = new EventEmitter<void>();

  projects$!: Observable<Project[]>;

  radius = 260;

  constructor(private projectsService: ProjectsService) {

    this.loadProjects();

  }

  loadProjects() {

    this.projects$ = this.projectsService
      .getAllProjects()
      .pipe(

        tap(() => {
          this.loaded.emit();
        }),

        catchError((error) => {

          console.error('Projects API Error:', error);

          this.loaded.emit();

          return of([]);

        })

      );

  }

  trackById(index: number, project: Project): number {

    return project.id ?? index;

  }

  getPosition(index: number, total: number) {

    const angle =
      (2 * Math.PI / total) * index - Math.PI / 2;

    return {

      x: this.radius * Math.cos(angle),

      y: this.radius * Math.sin(angle)

    };

  }

}