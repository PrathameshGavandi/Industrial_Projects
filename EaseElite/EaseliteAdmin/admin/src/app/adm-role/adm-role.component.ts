import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http'; // For API calls
import { AdmRole } from '../Class'; // AdmRole model class
import { WebService } from '../Service'; // WebService for making API requests
import { GlobalVariable } from '../Global'; // Global variable for the base API URL
import { Router } from '@angular/router';
import Swal from 'sweetalert2'; // Import SweetAlert2

@Component({
  selector: 'app-adm-role',
  templateUrl: './adm-role.component.html',
  styleUrls: ['./adm-role.component.scss']
})
export class AdmRoleComponent {
  admRole: AdmRole = {
    Title: '',
    Description: '',
    Status: 'active',
    AdmRoleId: 0,
    CreatedDate: '',
    CreatedBy: '',
    UpdatedDate: '',
    UpdatedBy: ''
  }; // Initialize admRole
  
  isSidebarOpen = false;  // Variable to control sidebar visibility
  dropdownOpen: string | null = null; // Variable to control dropdown visibility

  constructor(private router: Router, private http: HttpClient, private service: WebService) {} // Inject WebService

  onSubmit(roleForm: any) {
    // Check if the form is invalid
    if (roleForm.invalid) {
      Swal.fire({
        title: 'Invalid Form',
        text: 'Please fill all the required fields correctly before submitting.',
        icon: 'warning',
        confirmButtonText: 'OK'
      });
      return; // Stop further execution if the form is invalid
    }

    // Log form values to the console
    console.log('Form submitted:', this.admRole);

    // Call the API to save the role data
    this.service.AddAdmRole(this.admRole).subscribe(
      response => {
        // Check for the result and show the appropriate SweetAlert message
        if (response > 0) {
          Swal.fire({
            title: 'Success!',
            text: 'Saved Successfully.',
            icon: 'success',
            confirmButtonText: 'OK'
          }).then(() => {
            // Navigate to the target page after success
            this.router.navigate(['/rolelist']); // Replace '/target-route' with your actual route
          });
        } else {
          Swal.fire({
            title: 'Error!',
            text: 'Something went wrong! Please try again.',
            icon: 'error',
            confirmButtonText: 'OK'
          });
        }
      },
      error => {
        console.error('Error saving role:', error);
        Swal.fire({
          title: 'Error!',
          text: 'Error occurred while saving the role.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      }
    );
  }

  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }

  toggleDropdown(section: string) {
    // Toggle dropdown visibility for the clicked section
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
