import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from 'src/app/Service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-package-sender-transaction',
  templateUrl: './package-sender-transaction.component.html',
  styleUrls: ['./package-sender-transaction.component.scss']
})
export class PackageSenderTransactionComponent implements OnInit {
  ftttransactionList: any[] = []; // List to store transaction data
  userDetailsMap: { [key: string]: any } = {}; // Map to store user details by RegistrationId

  constructor(private router: Router, private service: WebService) {}

  ngOnInit(): void {
    this.GetAllPackageSenderTransactionDetail(); // Fetch transactions on component init
  }

  // Fetch all transactions
  GetAllPackageSenderTransactionDetail(): void {
    this.service.GetAllPackageSenderTransactionDetail().subscribe(
      (data: any[]) => {
        this.ftttransactionList = data;
        console.log('Package Sender Transaction Data:', data);
        // Fetch user details for each RegistrationId
        const registrationIds = [...new Set(data.map(transaction => transaction.RegistrationId))];
        this.fetchUserDetails(registrationIds);
      },
      error => {
        Swal.fire('Error', 'Failed to fetch Package Sender transactions. Please try again later.', 'error');
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
