import { Component, OnInit } from '@angular/core';
import { Offer } from '../Class';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { WebService } from '../Service';
import { GlobalVariable } from '../Global';

@Component({
  selector: 'app-updateoffer',
  templateUrl: './updateoffer.component.html',
  styleUrls: ['./updateoffer.component.scss']
})
export class UpdateofferComponent implements OnInit {

  offer: Offer;  // Use the new entity type
  Id: any;   // ID of the entity to update
  filesToUpload: Array<File> = [];
  imgPath: string = GlobalVariable.BASE_API_URL;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    private service: WebService
  ) {
    this.offer = new Offer();

    // Fetch entity details based on ID from the URL
    this.route.params.subscribe(params => {
      this.Id = params['Id']; // Adjust this based on your route

      // Fetch details of the entity by ID
      this.service.GetOfferById(this.Id).subscribe(result => {
        this.offer = result;
      }, error => {
        Swal.fire('Error', 'Failed to fetch offer details. Please try again later.', 'error');
      });
    });
  }

  ngOnInit(): void {
    // You can add any initialization logic here if needed
  }

  onSubmit() {
    // Update the entity details
    this.service.UpdateOffer(this.offer).subscribe(result => {
      if (result > 0) {
        // Prepare form data for the image upload
        const formData = new FormData();
        if (this.filesToUpload.length > 0) {
          formData.append('uploadedImage', this.filesToUpload[0], this.filesToUpload[0].name);
        }

        // Save the offer image after updating the offer details (without alerts)
        this.service.SaveOfferImage(formData, this.offer.Id).subscribe(() => {
          // Optionally, you can add logic here if needed, but no alert
        }, error => {
          // Optionally handle image upload errors silently
        });

        // Success alert for update
        Swal.fire({
          icon: 'success',
          title: 'Update Successful',
          text: 'The offer details have been updated successfully.',
          confirmButtonText: 'OK'
        }).then(() => {
          this.router.navigate(['/offerlist']); // Adjust navigation path as needed
        });
      } else {
        // Error alert for failed update
        Swal.fire({
          icon: 'error',
          title: 'Update Failed',
          text: 'Something went wrong! Please try again.',
          confirmButtonText: 'OK'
        });
      }
    }, error => {
      // Error alert for HTTP error
      Swal.fire({
        icon: 'error',
        title: 'Update Error',
        text: 'An error occurred during the update. Please try again later.',
        confirmButtonText: 'OK'
      });
    });
  }



  fileChangeEvent(fileInput: any): void {
    this.filesToUpload = <Array<File>>fileInput.target.files;
    if (this.filesToUpload.length > 0) {
      this.offer.Image = this.filesToUpload[0].name;
    }
  }
}
