import { Component, OnInit } from '@angular/core';
import { AdmELInfo } from '../Class'; // Use the AdmELInfo entity
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2'; // Import SweetAlert2
import { WebService } from '../Service'; // Import the service
import { GlobalVariable } from '../Global'; // Global variable for base URL

@Component({
  selector: 'app-update-elinfo',
  templateUrl: './update-elinfo.component.html',
  styleUrls: ['./update-elinfo.component.scss']
})
export class UpdateElinfoComponent implements OnInit {

  admELInfo: AdmELInfo;  // The entity being updated
  AdmELInfoId: any;      // ID of the entity to update
  filesToUpload: Array<File> = []; // To handle file uploads
  imgPath: string = GlobalVariable.BASE_API_URL; // Image path from global variables

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    private service: WebService
  ) {
    this.admELInfo = new AdmELInfo(); // Initialize the entity object

    // Fetch the entity details based on the ID from the URL
    this.route.params.subscribe(params => {
      this.AdmELInfoId = params['AdmELInfoId']; // Get the ID from the route parameters

      // Fetch the details of the entity by ID
      this.service.GetAdmELInfoById(this.AdmELInfoId).subscribe(result => {
        this.admELInfo = result;
      });
    });
  }

  ngOnInit(): void {
    // Any additional initialization logic can go here
  }

  onSubmit() {
    // Update the entity details
    this.service.UpdateAdmELInfo(this.admELInfo).subscribe(result => {
      if (result > 0) {
        const formData = new FormData();
        if (this.filesToUpload.length > 0) {
          formData.append('uploadedImage', this.filesToUpload[0], this.filesToUpload[0].name);
  
          // Save the image to the server
          this.service.SaveAdmElinfoImage(formData, this.admELInfo.AdmELInfoId).subscribe(() => {
            Swal.fire({
              title: 'Success!',
              text: 'Updated and image saved successfully.',
              icon: 'success',
              confirmButtonText: 'OK'
            }).then(() => {
              this.router.navigate(['/elinfolist']); // Navigate after success
            });
          }, error => {
            Swal.fire({
              title: 'Error!',
              text: 'Image upload failed. Please try again.',
              icon: 'error',
              confirmButtonText: 'OK'
            });
          });
        } else {
          Swal.fire({
            icon: 'success',
            title: 'Update Successful',
            text: 'The entity details have been updated successfully.',
            confirmButtonText: 'OK'
          }).then(() => {
            this.router.navigate(['/elinfolist']); // Adjust navigation path after successful update
          });
        }
      } else {
        Swal.fire({
          icon: 'error',
          title: 'Update Failed',
          text: 'An error occurred during the update. Please try again later.',
          confirmButtonText: 'OK'
        });
      }
    }, error => {
      Swal.fire({
        icon: 'error',
        title: 'Update Error',
        text: 'An error occurred during the update. Please try again later.',
        confirmButtonText: 'OK'
      });
    });
  }
  
  // Handle file selection
  fileChangeEvent(fileInput: any): void {
    this.filesToUpload = <Array<File>>fileInput.target.files;
    if (this.filesToUpload.length > 0) {
      this.admELInfo.Logo = this.filesToUpload[0].name; // Update the image name in the entity
    }
  }

  // Sidebar and dropdown functionality
  isSidebarOpen = false;  // Variable to control sidebar visibility
  dropdownOpen: string | null = null; // Variable to control dropdown visibility

  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }

  toggleDropdown(section: string) {
    this.dropdownOpen = this.dropdownOpen === section ? null : section;
  }

  selectRole(role: string, route: string) {
    console.log(`Role selected: ${role}`);
    this.router.navigate([route]);
  }

  logout() {
    this.router.navigate(['/login']);
  }
}
