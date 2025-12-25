import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { WebService } from '../Service';
import { Router } from '@angular/router';
import { AdmELInfo } from '../Class'; // Ensure you import the class for the form object
import Swal from 'sweetalert2';

@Component({
  selector: 'app-adm-elinfo',
  templateUrl: './adm-elinfo.component.html',
  styleUrls: ['./adm-elinfo.component.scss']
})
export class AdmELinfoComponent {
  @ViewChild('form') form: NgForm; // Update to match the template
  admELInfo: AdmELInfo = new AdmELInfo(); // Initialize the form object
  filesToUpload: Array<File> = []; // Array to hold the selected files

  constructor(private router: Router, private service: WebService) {}

  onSubmit(): void {
    if (this.form.valid && this.filesToUpload.length > 0) {
      // Save admin EL Info
      this.service.AddAdmELInfo(this.admELInfo).subscribe(result => {
        if (result > 0) {
          // Show success message
          Swal.fire({
            title: 'Success!',
            text: 'Information saved successfully.',
            icon: 'success',
            confirmButtonText: 'OK'
          }).then(() => {
            // Navigate to the target page after success
            this.router.navigate(['/elinfolist']); // Replace '/target-route' with your actual route
          });

          // Prepare form data for image upload
          const formData = new FormData();
          formData.append('uploadedImage', this.filesToUpload[0], this.filesToUpload[0].name); // Append the image to formData
          
          // Save uploaded image
          this.service.SaveAdmElinfoImage(formData, result).subscribe(() => {
            this.form.resetForm(); // Reset the form after submission
          }, (error) => {
            console.error('Error uploading image:', error);
            Swal.fire({
              title: 'Error!',
              text: 'Failed to upload the image. Please try again.',
              icon: 'error',
              confirmButtonText: 'OK'
            });
          });
        } else {
          // Show error message
          Swal.fire({
            title: 'Error!',
            text: 'Something went wrong! Please try again.',
            icon: 'error',
            confirmButtonText: 'OK'
          });
        }
      }, (error) => {
        console.error('Error occurred:', error);
        Swal.fire({
          title: 'Error!',
          text: 'An error occurred while saving information. Please check the details and try again.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      });
    } else {
      Swal.fire({
        title: 'Warning!',
        text: 'Form is invalid or no file selected.',
        icon: 'warning',
        confirmButtonText: 'OK'
      });
    }
  }

  // Handle file selection for image upload
  fileChangeEvent(fileInput: any): void {
    this.filesToUpload = <Array<File>>fileInput.target.files; // Cast file input to File array
    if (this.filesToUpload.length > 0) {
      this.admELInfo.Logo = this.filesToUpload[0].name; // Store the file name in the object
    }
  }

  // Sidebar and Dropdown toggling
  isSidebarOpen = false;
  dropdownOpen: string | null = null;

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
