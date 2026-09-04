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
  map,
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


  /*
   * Projects are already grouped into
   * rows of 2 cards.
   */
  projectRows$!: Observable<Project[][]>;


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
            (projects: Project[] | null | undefined) => {

              return this.groupProjects(
                projects ?? []
              );

            }
          ),


          catchError((error) => {

            console.error(
              'Projects API Error:',
              error
            );

            return of(
              [] as Project[][]
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
   * Converts:
   *
   * 01
   * 02
   * 03
   * 04
   *
   * into:
   *
   * [01, 02]
   * [03, 04]
   */
  private groupProjects(
    projects: Project[]
  ): Project[][] {

    const rows: Project[][] = [];

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
    project: Project
  ): number | string {

    return project.id ??
      `${index}-${project.name}`;

  }


  getTechnologies(
    project: Project
  ): string[] {

    return (
      project.technologies ?? ''
    )

      .split(',')

      .map(
        tech => tech.trim()
      )

      .filter(
        tech => tech.length > 0
      );

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