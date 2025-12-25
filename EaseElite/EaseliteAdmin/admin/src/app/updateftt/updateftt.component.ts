import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdmFttSubscription } from '../Class';
import { WebService } from '../Service';
import Swal from 'sweetalert2'; // Import SweetAlert

@Component({
  selector: 'app-updateftt',
  templateUrl: './updateftt.component.html',
  styleUrls: ['./updateftt.component.scss']
})
export class UpdatefttComponent implements OnInit {

  admFttSubscription: AdmFttSubscription;
  AdmFttSubscriptionld: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    private service: WebService
  ) {
    this.admFttSubscription = new AdmFttSubscription();

    // Fetch subscription details based on ID from the URL
    this.route.params.subscribe(params => {
      this.AdmFttSubscriptionld = params['AdmFttSubscriptionld'];

      // Fetch details of the FttSubscription by ID
      this.service.GetAdmFttSubscriptionById(this.AdmFttSubscriptionld).subscribe(result => {
        this.admFttSubscription = result;
      });
    });
  }

  ngOnInit(): void {}

  onUpdate() {
    // Update the subscription details
    this.service.UpdateAdmFttSubscription(this.admFttSubscription).subscribe(result => {
      if (result == 0) {
        Swal.fire({
          icon: 'error',
          title: 'Update Failed',
          text: 'Something went wrong! Please try again.',
          confirmButtonText: 'OK'
        });
      } else {
        Swal.fire({
          icon: 'success',
          title: 'Update Successful',
          text: 'The subscription details have been updated successfully.',
          confirmButtonText: 'OK'
        }).then(() => {
          // Redirect to the subscription list page after success
          this.router.navigate(['/fttlist']);
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

  // Sidebar control
  isSidebarOpen = false;  
  dropdownOpen: string | null = null;

  // Toggle sidebar visibility
  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }

  // Toggle dropdown visibility
  toggleDropdown(section: string) {
    this.dropdownOpen = this.dropdownOpen === section ? null : section;
  }

  // Role selection
  selectRole(role: string, route: string) {
    console.log(`Role selected: ${role}`);
    this.router.navigate([route]);
  }

  // Logout function
  logout() {
    this.router.navigate(['/login']);
  }
}
