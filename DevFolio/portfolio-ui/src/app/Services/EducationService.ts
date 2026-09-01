import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

/* ===============================
   EDUCATION INTERFACE
================================ */
export interface Education {
  id?: number;
  degree: string;
  specialization: string;
  college: string;
  university: string;
  location: string;
  passingYear: number | null;
  cgpa: number | null;
}

@Injectable({
  providedIn: 'root'
})
export class EducationService {

  private baseUrl = 'http://localhost:8080/api/education';

  constructor(private http: HttpClient) {}

  getAllEducations() {
    return this.http.get<Education[]>(this.baseUrl);
  }

  saveEducation(edu: Education) {
    return this.http.post(this.baseUrl, edu);
  }

  deleteEducation(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
