import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Skills {
  pop: string;
  oop: string;
  vm: string;
  fw: string;
  script: string;
  web: string;
  ide: string;
  server: string;
  vcs: string;
  db: string;
  os: string;
  method: string;
}

@Injectable({
  providedIn: 'root'
})
export class SkillsService {

  

  private baseUrl = 'https://my-portfolio-backend-y3cz.onrender.com/api/skills';
  

  constructor(private http: HttpClient) {}

  getAllSkills(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl);
  }

  saveSkills(skills: any) {
    return this.http.post(this.baseUrl, skills);
  }

  deleteSkills(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
