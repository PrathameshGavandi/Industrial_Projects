import {
  Component,
  EventEmitter,
  Output,
  OnInit
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { ProjectsService } from '../../Services/ProjectsService';

import {
  Observable,
  catchError,
  finalize,
  map,
  of,
  shareReplay
} from 'rxjs';


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


export class UserProjectsComponent
implements OnInit {


  @Output()
  loaded = new EventEmitter<void>();


  /*
   * Projects are grouped as:
   *
   * [01] [02]
   * [03] [04]
   * [05] [06]
   *
   * Each complete row becomes sticky.
   */
  projectRows$!: Observable<ProjectView[][]>;


  constructor(
    private projectsService: ProjectsService
  ) {}


  ngOnInit(): void {

    this.loadProjects();

  }


  private loadProjects(): void {

    this.projectRows$ =

      this.projectsService
        .getAllProjects()

        .pipe(

          map(
            (
              projects:
              Project[] |
              null |
              undefined
            ) => {

              const preparedProjects =
                (projects ?? []).map(
                  project => this.prepareProject(
                    project
                  )
                );


              return this.groupProjects(
                preparedProjects
              );

            }
          ),


          catchError((error) => {

            console.error(
              'Projects API Error:',
              error
            );

            return of(
              [] as ProjectView[][]
            );

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


  /*
   * Prepare project data once.
   *
   * This prevents split/map work
   * from happening repeatedly in HTML.
   */
  private prepareProject(
    project: Project
  ): ProjectView {

    return {

      ...project,

      technologyList:
        (project.technologies ?? '')
          .split(',')
          .map(
            tech => tech.trim()
          )
          .filter(
            tech => tech.length > 0
          )

    };

  }


  /*
   * Group projects into 2-card rows.
   */
  private groupProjects(
    projects: ProjectView[]
  ): ProjectView[][] {

    const rows: ProjectView[][] = [];


    for (
      let i = 0;
      i < projects.length;
      i += 2
    ) {

      rows.push(
        projects.slice(i, i + 2)
      );

    }


    return rows;

  }


  trackByRow(
    index: number
  ): number {

    return index;

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