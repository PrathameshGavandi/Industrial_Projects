import {
  Component,
  EventEmitter,
  OnInit,
  Output
} from '@angular/core';

import { CommonModule } from '@angular/common';

import {
  Observable,
  catchError,
  finalize,
  map,
  of,
  shareReplay
} from 'rxjs';

import { ProjectsService } from '../../Services/ProjectsService';


export interface Project {

  id?: number;

  name: string;

  type: string;

  description: string;

  technologies: string;

}


interface ProjectView extends Project {

  technologyList: string[];

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


export class UserProjectsComponent implements OnInit {


  @Output()
  loaded = new EventEmitter<void>();


  projectList$!: Observable<ProjectView[]>;


  constructor(
    private projectsService: ProjectsService
  ) {}


  ngOnInit(): void {

    this.loadProjects();

  }


  private loadProjects(): void {

    this.projectList$ = this.projectsService

      .getAllProjects()

      .pipe(

        map(
          (
            projects: Project[] | null | undefined
          ) => {

            return (projects ?? []).map(
              project => this.prepareProject(project)
            );

          }
        ),


        catchError(error => {

          console.error(
            'Projects API Error:',
            error
          );

          return of([] as ProjectView[]);

        }),


        finalize(() => {

          this.loaded.emit();

        }),


        shareReplay({

          bufferSize: 1,

          refCount: true

        })

      );

  }


  private prepareProject(
    project: Project
  ): ProjectView {

    const technologyList =
      (project.technologies ?? '')
        .split(',')
        .map(
          technology => technology.trim()
        )
        .filter(Boolean);


    return {

      ...project,

      technologyList

    };

  }


  trackById(
    index: number,
    project: ProjectView
  ): number | string {

    return project.id ??
      `${index}-${project.name}`;

  }


  trackByTechnology(
    index: number,
    technology: string
  ): string {

    return `${index}-${technology}`;

  }


  getProjectNumber(
    index: number
  ): string {

    return (index + 1)
      .toString()
      .padStart(2, '0');

  }

}