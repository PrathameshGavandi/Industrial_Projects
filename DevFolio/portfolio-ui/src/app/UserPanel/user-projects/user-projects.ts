import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
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
  imports: [CommonModule],
  templateUrl: './user-projects.html',
  styleUrls: ['./user-projects.scss']
})
export class UserProjectsComponent implements OnInit {

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
  ========================================== */
  loadProjects(): void {
    this.isLoading = true;

    this.projectsService.getAllProjects().subscribe({
      next: (projects: Project[]) => {
        this.projectList = (projects || []).map(
          project => this.prepareProject(project)
        );
        this.isLoading = false;
        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('Projects API Error:', error);
        this.projectList = [];
        this.isLoading = false;
        this.cdr.detectChanges();
      }
    });
  }

  /* ==========================================
     PREPARE PROJECT
  ========================================== */
  private prepareProject(project: Project): ProjectView {
    return {
      ...project,
      technologyList: project.technologies
        ? project.technologies
            .split(',')
            .map(technology => technology.trim())
            .filter(Boolean)
        : []
    };
  }

  /* ==========================================
     मिसिंग फंक्शन्स (ज्यामुळे एरर येत होता)
  ========================================== */

  // १. प्रोजेक्टचा अनुक्रमांक फॉरमॅट करण्यासाठी (उदा. 01, 02)
  getProjectNumber(index: number): string {
    return (index + 1).toString().padStart(2, '0');
  }

  // २. प्रोजेक्ट्स लूपचा परफॉर्मन्स वाढवण्यासाठी ट्रॅकिंग फंक्शन
  trackById(index: number, item: any): any {
    return item.id || index;
  }

  // ३. टेक्नॉलॉजी लूपचा परफॉर्मन्स वाढवण्यासाठी ट्रॅकिंग फंक्शन
  trackByTechnology(index: number, item: string): string {
    return item || index.toString();
  }
}
