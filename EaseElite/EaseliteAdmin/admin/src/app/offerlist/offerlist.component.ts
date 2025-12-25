import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from '../Service';
import { Offer } from '../Class';
import { GlobalVariable } from '../Global';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-offerlist',
  templateUrl: './offerlist.component.html',
  styleUrls: ['./offerlist.component.scss']
})
export class OfferlistComponent implements OnInit {
  offerList1: Offer[] = []; // Initialize offerList as an empty array
  imgPath: string = GlobalVariable.BASE_API_URL;

  constructor(private router: Router, private http: HttpClient, private service: WebService) {}

  ngOnInit(): void {
    console.log("Component initialized.");
    this.GetAlloffer(); // Fetch all offers when the component loads
  }

  GetAlloffer(): void {
    this.service.GetAllOffer().subscribe(
      data => {
        this.offerList1 = data; // Populate offerList with data from the API
        console.log("Offer list data: ", this.offerList1);
      },
      error => {
        console.error("Error fetching offers:", error);
        Swal.fire({
          title: 'Error!',
          text: 'Failed to load offers. Please try again later.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      }
    );
  }

  editUser(Id): void {
    this.router.navigateByUrl('/updateoffer/' + Id);
  }

 

  deleteUser(id: number): void {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, cancel!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.service.DeleteOffer(id).subscribe(
          result => {
            if (result === "Success") {
              // Filter the offerList after deletion
              this.offerList1 = this.offerList1.filter(item => item.Id !== id);
              Swal.fire({
                title: 'Deleted!',
                text: 'The offer has been deleted.',
                icon: 'success',
                confirmButtonText: 'OK'
              });
            } else {
              Swal.fire({
                title: 'Error!',
                text: 'Failed to delete the offer. Please try again.',
                icon: 'error',
                confirmButtonText: 'OK'
              });
            }
          },
          error => {
            console.error("Error deleting offer:", error);
            Swal.fire({
              title: 'Error!',
              text: 'Failed to delete the offer. Please try again later.',
              icon: 'error',
              confirmButtonText: 'OK'
            });
          }
        );
      } else {
        Swal.fire({
          title: 'Cancelled',
          text: 'Your offer is safe!',
          icon: 'info',
          confirmButtonText: 'OK'
        });
      }
    });
  }
}
