import {
  Component,
  EventEmitter,
  Output,
  OnInit
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { ProjectsService }
  from '../../Services/ProjectsService';

import {
  Observable,
  catchError,
  of,
  finalize,
  shareReplay
} from 'rxjs';


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

  imports: [
    CommonModule
  ],

  templateUrl: './user-projects.html',

  styleUrls: ['./user-projects.scss']

})


export class UserProjectsComponent
implements OnInit {


  @Output()
  loaded = new EventEmitter<void>();


  projects$!: Observable<Project[]>;


  constructor(
    private projectsService: ProjectsService
  ) {}


  ngOnInit(): void {

    this.loadProjects();

  }


  private loadProjects(): void {

    this.projects$ =

      this.projectsService
        .getAllProjects()
        .pipe(

          catchError((error) => {

            console.error(
              'Projects API Error:',
              error
            );

            return of([]);

          }),

          finalize(() => {

            this.loaded.emit();

          }),

          shareReplay(1)

        );

  }


  trackById(
    index: number,
    project: Project
  ): number {

    return project.id ?? index;

  }

}