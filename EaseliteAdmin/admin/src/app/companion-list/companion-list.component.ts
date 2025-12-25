import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from '../Service';
import Swal from 'sweetalert2'; // Import SweetAlert2

@Component({
  selector: 'app-companion-list',
  templateUrl: './companion-list.component.html',
  styleUrls: ['./companion-list.component.scss']
})
export class CompanionListComponent {
  
  admCompSubscriptionList: any[]; // Store the list of subscriptions
  GetAdmCompSubscriptionById:any;
  admRegistration: any;
  constructor(private router: Router, private http: HttpClient, private service: WebService) {
    this.admCompSubscriptionList = [];
    this.GetAlladmCompSubscription(); // Fetch subscriptions on component load
  }

  // Fetch all subscriptions
  GetAlladmCompSubscription(): void {
    this.service.GetAllAdmCompSubscription().subscribe(data => {
      this.admCompSubscriptionList = data;
      console.log("admCompSubscriptionList Data is ", data);
    });
  }

  // Navigate to view companion details page
  viewDetails(AdmCompSubscriptionld: string): void {
    this.router.navigate(['/viewcompanion', AdmCompSubscriptionld]);
  }

  // Navigate to edit companion page
  editUser(AdmCompSubscriptionld: string): void {
    this.router.navigateByUrl('/updatecompanion/' + AdmCompSubscriptionld);
  }

  // Delete a subscription with SweetAlert confirmation
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
        this.service.GetAdmCompSubscriptionById(id).subscribe({
          next: (admRegistration) => {
            // Set city master info and update status
            this.admRegistration = { ...admRegistration, Status: "InActive" };
            
            // Update city master status to "InActive"
            this.service.UpdateAdmCompSubscription(this.admRegistration).subscribe({
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
                  this.GetAdmCompSubscriptionById();
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


  showSuccessAlert3() {
    Swal.fire({
      title: 'Success',
      html: ' <b style="color:red;">Are you sure you want to delete this record?</b>',
      icon: 'success'
    });
  }
}
