
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

/* ===============================
   EDUCATION INTERFACE
================================= */
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

  // Live Spring Boot Backend API
  private baseUrl = 'https://my-portfolio-backend-y3cz.onrender.com/api/education';

  constructor(private http: HttpClient) {}

  // Get all education records
  getAllEducations() {
    return this.http.get<Education[]>(this.baseUrl);
  }

  // Save education record
  saveEducation(edu: Education) {
    return this.http.post<Education>(this.baseUrl, edu);
  }

  // Delete education record
  deleteEducation(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}

