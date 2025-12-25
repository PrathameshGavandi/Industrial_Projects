import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from '../Service';
import Swal from 'sweetalert2'; // Import SweetAlert2

@Component({
  selector: 'app-fttlist',
  templateUrl: './fttlist.component.html',
  styleUrls: ['./fttlist.component.scss']
})
export class FttlistComponent {
  admFttSubscriptionList: any[];
  admRegistration: any;
  GetAdmFttSubscriptionById: any;
  loading: boolean = true;
  constructor(private router: Router, private http: HttpClient, private service: WebService) {
    this.admFttSubscriptionList = [];
    this.GetAlladmFttSubscription();
  }

  GetAlladmFttSubscription(): void {
    this.service.GetAllAdmFttSubscription().subscribe(data => {
      this.admFttSubscriptionList = data;
      console.log("admFttSubscriptionList Data is ", data);
    });
  }

  viewDetails(AdmFttSubscriptionId: string): void {
    this.router.navigate(['/viewftt', AdmFttSubscriptionId]);
  }

  editUser(AdmFttSubscriptionId: string): void {
    this.router.navigateByUrl('/updateftt/' + AdmFttSubscriptionId);
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
        this.service.GetAdmFttSubscriptionById(id).subscribe({
          next: (admRegistration) => {
            // Set city master info and update status
            this.admRegistration = { ...admRegistration, Status: "InActive" };

            // Update city master status to "InActive"
            this.service.UpdateAdmFttSubscription(this.admRegistration).subscribe({
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
                  this.GetAdmFttSubscriptionById();
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
