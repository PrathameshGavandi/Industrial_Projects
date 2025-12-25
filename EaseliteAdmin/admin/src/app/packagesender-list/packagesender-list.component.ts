import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from '../Service'; // Ensure that the service path is correct
import Swal from 'sweetalert2'; // Import SweetAlert2 for alerts and confirmations

@Component({
  selector: 'app-packagesender-list',
  templateUrl: './packagesender-list.component.html',
  styleUrls: ['./packagesender-list.component.scss']
})
export class PackagesenderListComponent {

  admSenderSubscriptionList: any[] = []; // Initialize the list properly
  admRegistration: any;

  constructor(private router: Router, private http: HttpClient, private service: WebService) {
    this.GetAlladmSenderSubscription(); // Fetch sender subscriptions on component initialization
  }

  // Fetch all sender subscriptions
  GetAlladmSenderSubscription(): void {
    this.service.GetAllAdmSenderSubscription().subscribe(
      data => {
        this.admSenderSubscriptionList = data;
        console.log("admSenderSubscriptionList Data:", data);
      },
      error => {
        Swal.fire('Error', 'Failed to fetch data. Please try again later.', 'error');
      }
    );
  }

  // Edit function
  editUser(AdmSenderSubscriptionld: string): void {
    this.router.navigateByUrl('/updatepackage/' + AdmSenderSubscriptionld);
  }

  // View details function
  viewDetails(AdmSenderSubscriptionld: string): void {
    this.router.navigate(['/viewpackage', AdmSenderSubscriptionld]);
  }

  // Delete function with confirmation dialog
  Delete(id: number): void {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You won’t be able to revert this!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.isConfirmed) {
        // Retrieve city master info by ID
        this.service.GetAdmCarrierSubscriptionById(id).subscribe({
          next: (admRegistration) => {
            // Set city master info and update status
            this.admRegistration = { ...admRegistration, Status: "InActive" };
            
            // Update city master status to "InActive"
            this.service.UpdateAdmSenderSubscription(this.admRegistration).subscribe({
              next: (updateResult) => {
                if (updateResult === 0) {
                  Swal.fire({
                    title: 'Error!',
                    text: 'Something went wrong! Please try again.',
                    icon: 'error',
                    confirmButtonText: 'Ok'
                  });
                } else {
                  Swal.fire(
                    'Deleted!',
                    'Your item has been deleted.',
                    'success'
                  );
                  this.GetAdmSenderSubscriptionById();
                }
              },
              error: () => {
                Swal.fire(
                  'Error!',
                  'There was an error updating your item.',
                  'error'
                );
              }
            });
          },
          error: () => {
            Swal.fire(
              'Error!',
              'Failed to retrieve city master information.',
              'error'
            );
          }
        });
      }
    });
  }
  GetAdmSenderSubscriptionById() {
    throw new Error('Method not implemented.');
  }

  
  

  showSuccessAlert3() {
    Swal.fire({
      title: 'Success',
      html: ' <b style="color:red;">Are you sure you want to delete this record?</b>',
      icon: 'success'
    });
  }
}
