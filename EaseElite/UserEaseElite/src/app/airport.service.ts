import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})


  export class AirportService {

    private jsonUrl = 'assets/airports.json'; // Path to your JSON file
  
    constructor(private http: HttpClient) { }
  
    getAirports(): Observable<any[]> {
      return this.http.get<any>(this.jsonUrl).pipe(
        map((data: any) => {
          // Convert the JSON object into an array of airport objects
          return Object.keys(data).map(key => data[key]);
        })
      );
    }
  }