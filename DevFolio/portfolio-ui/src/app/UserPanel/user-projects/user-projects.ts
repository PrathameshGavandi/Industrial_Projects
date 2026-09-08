import {
  Component,
  OnInit
} from '@angular/core';

import { CommonModule }
  from '@angular/common';

import {
  Observable,
  catchError,
  map,
  of,
  shareReplay
} from 'rxjs';

import { ProjectsService }
  from '../../Services/ProjectsService';


export interface Project {

  id?: number;

  name: string;

  type: string;

  description: string;

  technologies: string;

}


interface ProjectView
  extends Project {

  technologyList: string[];

}


@Component({

  selector: 'app-user-projects',

  standalone: true,

  imports: [
    CommonModule
  ],

  templateUrl:
    './user-projects.html',

  styleUrls:
    ['./user-projects.scss']

})


export class UserProjectsComponent
  implements OnInit {


  projectList$!:
    Observable<ProjectView[]>;


  constructor(
    private projectsService:
      ProjectsService
  ) {}


  /* =====================================================
     INIT
  ===================================================== */

  ngOnInit(): void {

    /*
     * Projects API starts immediately.
     *
     * It does NOT wait for portfolio loader.
     */

    this.loadProjects();

  }


  /* =====================================================
     LOAD PROJECTS
  ===================================================== */

  private loadProjects(): void {

    this.projectList$ =

      this.projectsService

        .getAllProjects()

        .pipe(


          /* ==============================================
             API RESPONSE
          ============================================== */

          map(
            (
              projects:
                Project[] |
                null |
                undefined
            ) => {

              return (
                projects ?? []
              ).map(
                project =>
                  this.prepareProject(
                    project
                  )
              );

            }
          ),


          /* ==============================================
             API ERROR
          ============================================== */

          catchError(error => {

            console.error(
              'Projects API Error:',
              error
            );

            /*
             * Only Projects component
             * handles its API error.
             */

            return of(
              [] as ProjectView[]
            );

          }),


          /*
           * No finalize().
           *
           * There is no communication with
           * the parent loader anymore.
           */


          /* ==============================================
             CACHE
          ============================================== */

          shareReplay({

            bufferSize: 1,

            refCount: true

          })

        );

  }


  /* =====================================================
     PREPARE PROJECT
  ===================================================== */

  private prepareProject(
    project: Project
  ): ProjectView {

    const technologyList =

      (project.technologies ?? '')

        .split(',')

        .map(
          technology =>
            technology.trim()
        )

        .filter(Boolean);


    return {

      ...project,

      technologyList

    };

  }


  /* =====================================================
     TRACK PROJECT
  ===================================================== */

  trackById(
    index: number,
    project: ProjectView
  ): number | string {

    return (

      project.id ??

      `${index}-${project.name}`

    );

  }


  /* =====================================================
     TRACK TECHNOLOGY
  ===================================================== */

  trackByTechnology(
    index: number,
    technology: string
  ): string {

    return `${index}-${technology}`;

  }


  /* =====================================================
     PROJECT NUMBER
  ===================================================== */

  getProjectNumber(
    index: number
  ): string {

    return (

      index + 1

    )
      .toString()
      .padStart(2, '0');

  }

}