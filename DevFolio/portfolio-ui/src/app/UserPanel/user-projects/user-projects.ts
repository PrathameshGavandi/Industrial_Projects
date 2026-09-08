import {
  Component,
  OnInit,
  ChangeDetectorRef
} from '@angular/core';

import { CommonModule } from '@angular/common';

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


export class UserProjectsComponent
  implements OnInit {


  projectList: ProjectView[] = [];

  isLoading = true;


  constructor(
    private projectsService: ProjectsService,
    private cdr: ChangeDetectorRef
  ) {}


  ngOnInit(): void {

    this.loadProjects();

  }


  /* ==========================================
     LOAD PROJECTS

     Direct API subscription.
  ========================================== */

  loadProjects(): void {

    this.isLoading = true;


    this.projectsService
      .getAllProjects()
      .subscribe({

        next: (projects: Project[]) => {

          this.projectList =
            (projects || []).map(
              project =>
                this.prepareProject(project)
            );


          this.isLoading = false;

          this.cdr.detectChanges();

        },


        error: (error) => {

          console.error(
            'Projects API Error:',
            error
          );

          this.projectList = [];

          this.isLoading = false;

          this.cdr.detectChanges();

        }

      });

  }


  /* ==========================================
     PREPARE PROJECT
  ========================================== */

  private prepareProject(
    project: Project
  ): ProjectView {

    return {

      ...project,

      technologyList:
        project.technologies
          ? project.technologies
              .split(',')
              .map(
                technology =>
                  technology.trim()
              )
              .filter(Boolean)
          : []

    };

  }

}