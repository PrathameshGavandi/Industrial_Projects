import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { WebService } from '../Service';

@Component({
  selector: 'app-notifications-list',
  templateUrl: './notifications-list.component.html',
  styleUrls: ['./notifications-list.component.scss']
})
export class NotificationsListComponent {
  NotificationsList: any[];
  admRegistration: any;
  GetNotificationsById: any;
  loading: boolean = true;
  constructor(private router: Router, private http: HttpClient, private service: WebService) {
    this.NotificationsList = [];
    this.GetAllNotifications();
  }

  GetAllNotifications(): void {
    this.service.GetAllNotifications().subscribe(data => {
      this.NotificationsList = data;
      console.log("NotifivcationList Data is ", data);
    });
  }

  viewDetails(NotificationsId: string): void {
    this.router.navigate(['/viewnotifications', NotificationsId]);
  }

  editUser(NotificationsId: string): void {
    this.router.navigateByUrl('/updatenotifications/' + NotificationsId);
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
        this.service.GetNotificationsById(id).subscribe({
          next: (admRegistration) => {
            // Set city master info and update status
            this.admRegistration = { ...admRegistration, Status: "InActive" };

            // Update city master status to "InActive"
            this.service.UpdateNotifications(this.admRegistration).subscribe({
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
                  this.GetNotificationsById();
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
