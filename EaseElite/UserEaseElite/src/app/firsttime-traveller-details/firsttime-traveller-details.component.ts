import { Component, HostListener } from '@angular/core';
// import {  Flight} from '../Class';
import { AirportService } from '../airport.service';
import {  FlightDetailsFirsttimeTraveller } from '../Class';

@Component({
  selector: 'app-firsttime-traveller-details',
  templateUrl: './firsttime-traveller-details.component.html',
  styleUrls: ['./firsttime-traveller-details.component.scss']
})
export class FirsttimeTravellerDetailsComponent {
  fdata: FlightDetailsFirsttimeTraveller
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
  
  flightdetails = {
    flightNumber: '',
    date: '',
    time: '',
    from: '',
    to: '',
    ticket: ''
  };
ticket: any;
  
  constructor(private airportService: AirportService) {
    this.fdata= new FlightDetailsFirsttimeTraveller()
  }
  
  ngOnInit() {
    // Fetch airports data
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
  
  // Submit form
  // onSubmit() {
  //   this.submittedFlightDetails = {
  //     ...this.flightdetails,
  //     from: this.selectedAirportFrom ? this.selectedAirportFrom.name : this.flightdetails.from,
  //     to: this.selectedAirportTo ? this.selectedAirportTo.name : this.flightdetails.to
  //   };
  //   console.log('Submitted Flight Details:', this.submittedFlightDetails);
  // }



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


