import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AdmCarrierSubscription } from '../Class';
import { WebService } from '../Service';
import Swal from 'sweetalert2'; // Import SweetAlert2

@Component({
  selector: 'app-addcarrier',
  templateUrl: './addcarrier.component.html',
  styleUrls: ['./addcarrier.component.scss']
})
export class AddcarrierComponent {
  admCarrierSubscription: AdmCarrierSubscription;

  isSidebarOpen = false;  // Variable to control sidebar visibility
  dropdownOpen: string | null = null; // Variable to control dropdown visibility

  
  constructor(private router: Router,
              private http: HttpClient,
              private service: WebService) {
    this.admCarrierSubscription = new AdmCarrierSubscription();
  }
  validateWhitespace(control: any) {
    if (control.value && control.value.trim().length === 0) {
      control.setErrors({ whitespace: true });
    } else {
      control.setErrors(null);
    }
  }
  onSubmit() {
    console.log("admCarrierSubscription", this.admCarrierSubscription);
    this.service.AddAdmCarrierSubscription(this.admCarrierSubscription).subscribe((result) => {
      if (result > 0) {
        // Use SweetAlert for success message
        Swal.fire({
          icon: 'success',
          title: 'Saved Successfully',
          text: 'Your data has been saved.',
        }).then(() => {
          // Navigate to the target page after success
          this.router.navigate(['/carrierlist']); // Replace '/target-route' with your actual route
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


