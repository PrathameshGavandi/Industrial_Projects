import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from 'src/app/Service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-companion-transaction',
  templateUrl: './companion-transaction.component.html',
  styleUrls: ['./companion-transaction.component.scss']
})
export class CompanionTransactionComponent implements OnInit {
  ftttransactionList: any[] = []; // List to store transaction data
  userDetailsMap: { [key: string]: any } = {}; // Map to store user details by RegistrationId

  constructor(private router: Router, private service: WebService) {}

  ngOnInit(): void {
    this.GetAllCompanionTransactionDetail(); // Fetch transactions on component init
  }

  // Fetch all transactions
  GetAllCompanionTransactionDetail(): void {
    this.service.GetAllCompanionTransactionDetail().subscribe(
      (data: any[]) => {
        this.ftttransactionList = data;
        console.log('Companion Transaction Data:', data);
        // Fetch user details for each RegistrationId
        const registrationIds = [...new Set(data.map(transaction => transaction.RegistrationId))];
        this.fetchUserDetails(registrationIds);
      },
      error => {
        Swal.fire('Error', 'Failed to fetch Companion transactions. Please try again later.', 'error');
        console.error('Error fetching transactions:', error);
      }
    );
  }

  // Fetch user details for multiple RegistrationIds
  fetchUserDetails(registrationIds: string[]): void {
    registrationIds.forEach(registrationId => {
      this.service.GetRegistrationById(registrationId).subscribe(
        userDetails => {
          this.userDetailsMap[registrationId] = userDetails;
        },
        error => {
          console.error(`Error fetching user details for RegistrationId: ${registrationId}`, error);
        }
      );
    });
  }

  // Get user detail dynamically by RegistrationId
  getUserDetail(registrationId: string, key: string): string {
    return this.userDetailsMap[registrationId]?.[key] || 'N/A';
  }
}
