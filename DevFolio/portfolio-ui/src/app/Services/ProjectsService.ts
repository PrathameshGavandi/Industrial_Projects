import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

/* ===============================
   PROJECT INTERFACE
================================ */
export interface Project {
  id?: number;
  name: string;
  type: string;
  description: string;
  technologies: string;
}

@Injectable({
  providedIn: 'root'
})
export class ProjectsService {

  private baseUrl = 'https://my-portfolio-backend-y3cz.onrender.com/api/projects';

  constructor(private http: HttpClient) {}

  /* ===============================
     GET ALL PROJECTS
  ================================ */
  getAllProjects() {
    return this.http.get<Project[]>(this.baseUrl);
  }

  /* ===============================
     SAVE PROJECT (ADD)
  ================================ */
  saveProject(project: Project) {
    return this.http.post<Project>(this.baseUrl, project);
  }

  /* ===============================
     DELETE PROJECT
  ================================ */
  deleteProject(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
