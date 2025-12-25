import { Component } from '@angular/core';
import { Carrierdetail } from '../Class';
import { AirportService } from '../airport.service';

@Component({
  selector: 'app-carrier-details',
  templateUrl: './carrier-details.component.html',
  styleUrls: ['./carrier-details.component.scss']
})
export class CarrierDetailsComponent {
  carrierDetail: Carrierdetail;
  searchTermFrom: string = '';
  filteredAirportsFrom: any[] = [];
  isDropdownOpenFrom: boolean = false;
  searchTermTo: string = '';
  filteredAirportsTo: any[] = [];
  isDropdownOpenTo: boolean = false;

  airports: any[] = [];
  selectedAirportFrom: any = null;
  selectedAirportTo: any = null;
  submittedCarrierDetails: any = null;

  constructor(private airportService: AirportService) {
    this.carrierDetail = new Carrierdetail();
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
    this.carrierDetail.from = airport.name;
    this.filteredAirportsFrom = [];
    this.isDropdownOpenFrom = false;
  }

  // Select 'To' airport
  onSelectAirportTo(airport: any) {
    this.selectedAirportTo = airport;
    this.searchTermTo = airport.name;
    this.carrierDetail.to = airport.name;
    this.filteredAirportsTo = [];
    this.isDropdownOpenTo = false;
  }

  // Submit form
  onSubmit() {
    this.submittedCarrierDetails = {
      ...this.carrierDetail,
      from: this.selectedAirportFrom ? this.selectedAirportFrom.name : this.carrierDetail.from,
      to: this.selectedAirportTo ? this.selectedAirportTo.name : this.carrierDetail.to
    };

    console.log('Submitted Carrier Details:', this.submittedCarrierDetails);
  }
}
