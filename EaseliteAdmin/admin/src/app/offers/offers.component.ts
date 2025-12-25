import { Component } from '@angular/core';
import { Offer } from '../Class';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { WebService } from '../Service';
import { GlobalVariable } from '../Global';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-offers',
  templateUrl: './offers.component.html',
  styleUrls: ['./offers.component.scss']
})
export class OffersComponent {
  offer:Offer;

  filesToUpload: Array<File> = [];

  imgPath: string = GlobalVariable.BASE_API_URL;



 

  categories: any[] = [];
  allCities: string[] = []; 
  filteredCities: string[] = [];


  constructor(private router: Router, private http: HttpClient, private service: WebService) {
    this.offer= new Offer();
  }
  onSubmit(): void {
    // Assuming the form is valid and files are selected
    this.service.AddOffer(this.offer).subscribe(result => {
      if (result > 0) {
        const formData = new FormData();
        formData.append('uploadedImage', this.filesToUpload[0], this.filesToUpload[0].name);
  
        this.service.SaveOfferImage(formData, result).subscribe(() => {
          // Success SweetAlert after saving the image
          Swal.fire({
            icon: 'success',
            title: 'Saved Successfully!',
            text: 'Your offer has been saved successfully.',
            confirmButtonColor: '#3085d6',
            confirmButtonText: 'OK'
          }).then(() => {
            // Optional: Navigate after the user confirms
            this.router.navigateByUrl('/offerlist');
          });
        });
      } else {
        // Error SweetAlert if something goes wrong
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Something went wrong! Please try again.',
          confirmButtonColor: '#d33',
          confirmButtonText: 'Retry'
        });
      }
    });
  }
  
  
  fileChangeEvent(fileInput: any): void {
    this.filesToUpload = <Array<File>>fileInput.target.files;
    if (this.filesToUpload.length > 0) {
      this.offer.Image = this.filesToUpload[0].name;
    }
  }
}