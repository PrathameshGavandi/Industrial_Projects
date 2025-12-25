import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdmCarrierSubscription } from '../Class';
import { WebService } from '../Service';
import Swal from 'sweetalert2'; // SweetAlert2 for better feedback

@Component({
  selector: 'app-updatecarrier',
  templateUrl: './updatecarrier.component.html',
  styleUrls: ['./updatecarrier.component.scss']
})
export class UpdatecarrierComponent implements OnInit {

  admCarrierSubscription: AdmCarrierSubscription = new AdmCarrierSubscription(); // Initialized to avoid null errors
  AdmCarrierSubscriptionld: string | null = null;  // Subscription ID from the route parameters
  filesToUpload: any;

  isSidebarOpen = false;  // Control sidebar visibility
  dropdownOpen: string | null = null; // Control dropdown visibility

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    private service: WebService
  ) {}

  ngOnInit(): void {
    // Fetching the carrier subscription ID from the route params
    this.route.params.subscribe(params => {
      this.AdmCarrierSubscriptionld = params['AdmCarrierSubscriptionld'];
      this.fetchSubscriptionDetails();
    });
  }

  // Fetch the subscription details by ID
  fetchSubscriptionDetails(): void {
    if (this.AdmCarrierSubscriptionld) {
      this.service.GetAdmCarrierSubscriptionById(this.AdmCarrierSubscriptionld).subscribe(result => {
        this.admCarrierSubscription = result;
      }, error => {
        Swal.fire('Error!', 'Failed to fetch subscription details.', 'error');
      });
    }
  }

  // Update the carrier subscription details
  onSubmit(): void {
    this.service.UpdateAdmCarrierSubscription(this.admCarrierSubscription).subscribe(result => {
      if (result == 0) {
        Swal.fire('Error!', 'Something went wrong! Please try again.', 'error');
      } else {
        Swal.fire('Success!', 'Carrier subscription updated successfully.', 'success');
        this.router.navigate(['/carrierlist']);
      }
    }, error => {
      Swal.fire('Error!', 'Update failed. Please try again.', 'error');
    });
  }

  // Sidebar toggle logic
  toggleSidebar(): void {
    this.isSidebarOpen = !this.isSidebarOpen;
  }

  // Dropdown toggle logic
  toggleDropdown(section: string): void {
    this.dropdownOpen = this.dropdownOpen === section ? null : section;
  }

  // Navigate to a selected route based on role
  selectRole(role: string, route: string): void {
    console.log(`Role selected: ${role}`);
    this.router.navigate([route]);
  }

  // Logout and navigate to login page
  logout(): void {
    this.router.navigate(['/login']);
  }
}
