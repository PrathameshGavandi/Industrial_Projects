import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { WebService } from '../Service';
import { Notifications } from '../Class';

@Component({
  selector: 'app-update-notifications',
  templateUrl: './update-notifications.component.html',
  styleUrls: ['./update-notifications.component.scss']
})
export class UpdateNotificationsComponent implements OnInit {

  notifications: Notifications; 
  
  
  NotificationsId: string | null = null;  // Subscription ID from the route parameters
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
      this.NotificationsId = params['NotificationsId'];
      this.fetchNotificationsDetails();
    });
  }

  // Fetch the subscription details by ID
  fetchNotificationsDetails(): void {
    if (this.NotificationsId) {
      this.service.GetNotificationsById(this.NotificationsId).subscribe(result => {
        this.notifications = result;
      }, error => {
        Swal.fire('Error!', 'Failed to fetch notifications details.', 'error');
      });
    }
  }

  // Update the carrier subscription details
  OnUpdate(): void {
    this.service.UpdateNotifications(this.notifications).subscribe(result => {
      if (result == 0) {
        Swal.fire('Error!', 'Something went wrong! Please try again.', 'error');
      } else {
        Swal.fire('Success!', 'Notifications updated successfully.', 'success');
        this.router.navigate(['/notificationslist']);
      }
    }, error => {
      Swal.fire('Error!', 'Update failed. Please try again.', 'error');
    });
  }
  validateWhitespace(control: any) {
    if (control.value && control.value.trim().length === 0) {
      control.setErrors({ whitespace: true });
    } else {
      control.setErrors(null);
    }
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
