import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from '../Service';
import { AdmCarrierSubscription } from '../Class';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-carrier-list',
  templateUrl: './carrier-list.component.html',
  styleUrls: ['./carrier-list.component.scss']
})
export class CarrierListComponent {
  admCarrierSubscriptionList: AdmCarrierSubscription[] = []; // Defining the type and initializing the list
  admRegistration: any;

  constructor(private router: Router, private http: HttpClient, private service: WebService) {
    this.GetAllAdmCarrierSubscription();
  }

  GetAllAdmCarrierSubscription(): void {
    this.service.GetAllAdmCarrierSubscription().subscribe(data => {
      this.admCarrierSubscriptionList = data;
      console.log("admCarrierSubscriptionList Data is ", data);
    }, (error) => {
      console.error('Error fetching carrier subscriptions:', error);
      Swal.fire({
        title: 'Error!',
        text: 'Failed to load carrier subscriptions. Please try again later.',
        icon: 'error',
        confirmButtonText: 'OK'
      });
    });
  }

  viewDetails(AdmCarrierSubscriptionld: number): void {
    this.router.navigate(['/viewcarrier', AdmCarrierSubscriptionld]);
  }

  editUser(AdmCarrierSubscriptionld: number): void {
    this.router.navigateByUrl('/updatecarrier/' + AdmCarrierSubscriptionld);
  }

  
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
            this.service.UpdateAdmCarrierSubscription(this.admRegistration).subscribe({
              next: (updateResult) => {
                if (updateResult === 0) {
                  Swal.fire({
                    title: 'Error!',
                    text: 'Something went wrong! Please try again.',
                    icon: 'error',
                    confirmButtonText: 'Ok'
                  }).then(() => {
                    // Navigate to the target page after success
                    this.router.navigate(['/carrierlist']); // Replace '/target-route' with your actual route
                  });
                } else {
                  Swal.fire(
                    'Deleted!',
                    'Your item has been deleted.',
                    'success'
                  );
                  this.GetAdmCarrierSubscriptionById();
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
  GetAdmCarrierSubscriptionById() {
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
