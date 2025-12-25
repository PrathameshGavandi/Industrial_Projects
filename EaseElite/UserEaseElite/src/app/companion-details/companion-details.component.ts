import { Component, OnInit } from '@angular/core';
import { Companiondetails } from '../Class';
import { AirportService } from '../airport.service';

@Component({
  selector: 'app-companion-details',
  templateUrl: './companion-details.component.html',
  styleUrls: ['./companion-details.component.scss']
})
export class CompanionDetailsComponent implements OnInit {

  fdata: Companiondetails;
  searchTermFrom: string = '';
  filteredAirportsFrom: any[] = [];
  isDropdownOpenFrom: boolean = false;
  searchTermTo: string = '';
  filteredAirportsTo: any[] = [];
  isDropdownOpenTo: boolean = false;
  
  airports: any[] = [];
  selectedAirportFrom: any = null;
  selectedAirportTo: any = null;
  submittedFlightDetails: any = null;
 
  user = {
    flightNumber: '',
    date: '',
    time: '',
    from: '',
    to: '',
    ticket: ''
  };
  
  flightdetails: any;
  matchedUsers: any;

  constructor(private airportService: AirportService) {
    this.fdata = new Companiondetails();
  }

  ngOnInit() {
    // Fetch airport data
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
    this.flightdetails.from = airport.name;
    this.filteredAirportsFrom = [];
    this.isDropdownOpenFrom = false;
  }

  // Select 'To' airport
  onSelectAirportTo(airport: any) {
    this.selectedAirportTo = airport;
    this.searchTermTo = airport.name;
    this.flightdetails.to = airport.name;
    this.filteredAirportsTo = [];
    this.isDropdownOpenTo = false;
  }

  // Submit flight details
  onSubmit() {
    this.submittedFlightDetails = {
      ...this.flightdetails,
      flightNumber: this.fdata.flightNumber, // Assuming 'flightNumber' is part of the model
      date: this.fdata.date, // Assuming 'date' is part of the model
      time: this.fdata.time,
      from: this.selectedAirportFrom ? this.selectedAirportFrom.name : this.flightdetails.from,
      to: this.selectedAirportTo ? this.selectedAirportTo.name : this.flightdetails.to,
      ticket: this.fdata.ticket
    };

    console.log('Submitted Flight Details:', this.submittedFlightDetails);
  }
}
