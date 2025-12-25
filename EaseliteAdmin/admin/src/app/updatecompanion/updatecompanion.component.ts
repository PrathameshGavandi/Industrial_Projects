import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdmCompSubscription } from '../Class';
import { WebService } from '../Service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-updatecompanion',
  templateUrl: './updatecompanion.component.html',
  styleUrls: ['./updatecompanion.component.scss']
})
export class UpdatecompanionComponent implements OnInit {

  admCompSubscription: AdmCompSubscription;
  AdmCompSubscriptionld: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    private service: WebService
  ) {
    this.admCompSubscription = new AdmCompSubscription();
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.AdmCompSubscriptionld = params['AdmCompSubscriptionld'];

      // Fetch details of the subscription by ID
      this.service.GetAdmCompSubscriptionById(this.AdmCompSubscriptionld).subscribe(result => {
        this.admCompSubscription = result;
      }, (error) => {
        console.error('Error fetching subscription details:', error);
        Swal.fire({
          title: 'Error!',
          text: 'Failed to load subscription details. Please try again later.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      });
    });
  }

  onSubmit() {
    // Update the subscription details
    this.service.UpdateAdmCompSubscription(this.admCompSubscription).subscribe(result => {
      if (result == 0) {
        Swal.fire({
          title: 'Error!',
          text: 'Something went wrong! Please try again.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      } else {
        Swal.fire({
          title: 'Success!',
          text: 'Updated Successfully.',
          icon: 'success',
          confirmButtonText: 'OK'
        }).then(() => {
          this.router.navigate(['/companionlist']);
        });
      }
    }, (error) => {
      console.error('Error updating subscription:', error);
      Swal.fire({
        title: 'Error!',
        text: 'Failed to update subscription. Please check the details and try again.',
        icon: 'error',
        confirmButtonText: 'OK'
      });
    });
  }

  // Sidebar and Dropdown toggling
  isSidebarOpen = false;  // Variable to control sidebar visibility
  dropdownOpen: string | null = null; // Variable to control dropdown visibility

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
