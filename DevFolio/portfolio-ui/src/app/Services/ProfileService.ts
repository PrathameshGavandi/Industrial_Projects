import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Profile {
  name: string;
  email: string;
  phone: string;
  bio: string;
}

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  private baseUrl = 'https://my-portfolio-backend-y3cz.onrender.com/api/profile';

  constructor(private http: HttpClient) {}


  getallProfiles(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl);
  }

  saveProfile(profile: any) {
    return this.http.post(this.baseUrl, profile);
  }
  

  deleteProfile(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
