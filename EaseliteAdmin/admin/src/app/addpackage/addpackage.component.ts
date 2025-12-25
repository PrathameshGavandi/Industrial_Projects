import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AdmSenderSubscription } from '../Class';
import { WebService } from '../Service';
import Swal from 'sweetalert2'; // Import SweetAlert2

@Component({
  selector: 'app-addpackage',
  templateUrl: './addpackage.component.html',
  styleUrls: ['./addpackage.component.scss']
})
export class AddpackageComponent {
  @ViewChild('AdmSenderSubscriptionForm') form: NgForm;
  admSenderSubscription = new AdmSenderSubscription();
  
  isSidebarOpen = false;  // Variable to control sidebar visibility
  dropdownOpen: string | null = null; // Variable to control dropdown visibility

  constructor(private router: Router,
              private http: HttpClient,
              private service: WebService) {
    this.admSenderSubscription = new AdmSenderSubscription();
  }

  onSubmit() {
    console.log("admSenderSubscription", this.admSenderSubscription);
    this.service.AddAdmSenderSubscription(this.admSenderSubscription).subscribe((result) => {
      if (result > 0) {
        // Use SweetAlert for success message
        Swal.fire({
          icon: 'success',
          title: 'Saved Successfully',
          text: 'Your data has been saved.',
        }).then(() => {
          // Navigate to the target page after success
          this.router.navigate(['/companionlist']); // Replace '/target-route' with your actual route
        });
      } else {
        // Use SweetAlert for error message
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Something went wrong! Please try again.',
        });
      }
    });
    
    this.form.resetForm(); // Reset the form after submission
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

