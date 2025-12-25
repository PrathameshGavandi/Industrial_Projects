import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AdmCompSubscription } from '../Class';
import { WebService } from '../Service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-companion',
  templateUrl: './add-companion.component.html',
  styleUrls: ['./add-companion.component.scss']
})
export class AddCompanionComponent {

  @ViewChild('AdmCompSubscriptionForm') form: NgForm;
  
  admCompSubscription = new AdmCompSubscription();
  isSidebarOpen = false;  // Variable to control sidebar visibility
  dropdownOpen: string | null = null; // Variable to control dropdown visibility

  constructor(private router: Router,
              private http: HttpClient,
              private service: WebService) {
    this.admCompSubscription = new AdmCompSubscription();
  }
  validateWhitespace(control: any) {
    if (control.value && control.value.trim().length === 0) {
      control.setErrors({ whitespace: true });
    } else {
      control.setErrors(null);
    }
  }
  onSubmit() {
    console.log("admCompSubscription", this.admCompSubscription);
    this.service.AddAdmCompSubscription(this.admCompSubscription).subscribe((result) => {
      if (result > 0) {
        Swal.fire({
          title: 'Success!',
          text: 'Saved Successfully.',
          icon: 'success',
          confirmButtonText: 'OK'
        }).then(() => {
          // Navigate to the target page after success
          this.router.navigate(['/companionlist']); // Replace '/target-route' with your actual route
        });
      } else {
        Swal.fire({
          title: 'Error!',
          text: 'Something went wrong! Please try again.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      }
    });

    this.form.resetForm();
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


