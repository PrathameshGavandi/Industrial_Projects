import { Component, OnInit } from '@angular/core';
import { AirportService } from '../airport.service'; // Import the service

@Component({
  selector: 'app-package-sender-details',
  templateUrl: './package-sender-details.component.html',
  styleUrls: ['./package-sender-details.component.scss']
})
export class PackageSenderDetailsComponent implements OnInit {

  packagesenderdetails = {
    flightNumber: '',
    date: '',
    time: '',
    from: '',
    to: '',
    weight: ''
  };

  // Fields for the airport dropdown functionality
  searchTermFrom: string = '';
  filteredAirportsFrom: any[] = [];
  isDropdownOpenFrom: boolean = false;

  searchTermTo: string = '';
  filteredAirportsTo: any[] = [];
  isDropdownOpenTo: boolean = false;

  airports: any[] = [];
  selectedAirportFrom: any = null;
  selectedAirportTo: any = null;

  constructor(private airportService: AirportService) { }

  ngOnInit() {
    // Fetch airports data from the service
    this.airportService.getAirports().subscribe((data: any[]) => {
      this.airports = data;
    });
  }

  // Search for 'From' airport
  onSearchFrom() {
    const searchTermLower = this.searchTermFrom.toLowerCase();
    this.filteredAirportsFrom = this.airports.filter(airport =>
      airport.city.toLowerCase().startsWith(searchTermLower)
    );
    this.isDropdownOpenFrom = this.filteredAirportsFrom.length > 0;
  }

  // Search for 'To' airport
  onSearchTo() {
    const searchTermLower = this.searchTermTo.toLowerCase();
    this.filteredAirportsTo = this.airports.filter(airport =>
      airport.city.toLowerCase().startsWith(searchTermLower)
    );
    this.isDropdownOpenTo = this.filteredAirportsTo.length > 0;
  }

  // Select 'From' airport
  onSelectAirportFrom(airport: any) {
    this.selectedAirportFrom = airport;
    this.searchTermFrom = airport.name;
    this.packagesenderdetails.from = airport.name;
    this.filteredAirportsFrom = [];
    this.isDropdownOpenFrom = false;
  }

  // Select 'To' airport
  onSelectAirportTo(airport: any) {
    this.selectedAirportTo = airport;
    this.searchTermTo = airport.name;
    this.packagesenderdetails.to = airport.name;
    this.filteredAirportsTo = [];
    this.isDropdownOpenTo = false;
  }

  // Form submission
  onSubmit() {
    if (!this.isFormValid()) {
      console.error('Form is invalid');
      return;
    }

    // Submit form data
    console.log('Submitted Package Details:', this.packagesenderdetails);
  }

  // Simple form validation method
  isFormValid() {
    return this.packagesenderdetails.flightNumber &&
           this.packagesenderdetails.date &&
           this.packagesenderdetails.time &&
           this.packagesenderdetails.from &&
           this.packagesenderdetails.to &&
           this.packagesenderdetails.weight;
  }
}
