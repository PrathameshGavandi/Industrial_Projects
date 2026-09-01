import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export interface Experience {
  id?: number;   // ⭐ IMPORTANT FIX
  company: string;
  role: string;
  duration: string;
  description: string;
}

@Injectable({
  providedIn: 'root'
})
export class ExperienceService {

  private baseUrl = 'http://localhost:8080/api/experience';

  constructor(private http: HttpClient) {}

  getallExperiences() {
    return this.http.get<Experience[]>(this.baseUrl);
  }

  saveExperience(experience: Experience) {
    return this.http.post(this.baseUrl, experience);
  }

  deleteExperience(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
