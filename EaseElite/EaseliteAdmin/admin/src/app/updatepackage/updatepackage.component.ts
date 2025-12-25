import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdmSenderSubscription } from '../Class';
import { WebService } from '../Service';
import Swal from 'sweetalert2'; // Import SweetAlert2 for alerts and confirmations

@Component({
  selector: 'app-updatepackage',
  templateUrl: './updatepackage.component.html',
  styleUrls: ['./updatepackage.component.scss']
})
export class UpdatepackageComponent implements OnInit {

  admSenderSubscription: AdmSenderSubscription;
  AdmSenderSubscriptionld: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    private service: WebService
  ) {
    this.admSenderSubscription = new AdmSenderSubscription();

    this.route.params.subscribe(params => {
      this.AdmSenderSubscriptionld = params['AdmSenderSubscriptionld'];

      // Fetch details of the subscription by ID
      this.service.GetAdmSenderSubscriptionById(this.AdmSenderSubscriptionld).subscribe(result => {
        this.admSenderSubscription = result;
      }, error => {
        Swal.fire('Error', 'Failed to fetch the subscription details. Please try again later.', 'error');
      });
    });
  }

  ngOnInit(): void {
    // Initialization logic if needed
  }

  // Method to update the subscription details
  onSubmit() {
    this.service.UpdateAdmSenderSubscription(this.admSenderSubscription).subscribe(result => {
      if (result == 0) {
        Swal.fire('Error', 'Something went wrong! Please try again.', 'error');
      } else {
        Swal.fire('Updated', 'Subscription updated successfully.', 'success').then(() => {
          this.router.navigate(['/packagesenderlist']);
        });
      }
    }, error => {
      Swal.fire('Error', 'Failed to update the subscription. Please try again later.', 'error');
    });
  }

  // Sidebar functionality
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

  // Logout functionality
  logout() {
    Swal.fire({
      title: 'Are you sure you want to log out?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, log out',
      cancelButtonText: 'Cancel'
    }).then((result) => {
      if (result.isConfirmed) {
        this.router.navigate(['/login']);
      }
    });
  }
}
