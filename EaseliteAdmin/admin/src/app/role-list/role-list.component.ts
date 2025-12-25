import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from '../Service';
import Swal from 'sweetalert2'; // Import SweetAlert2 for alerts

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss']
})
export class RoleListComponent implements OnInit {
  admroleList: any[] = []; // List to store role data

  isSidebarOpen = false;  // Variable to control sidebar visibility
  dropdownOpen: string | null = null; // Variable to control dropdown visibility

  constructor(private router: Router, private service: WebService) {}

  // Initialize component
  ngOnInit(): void {
    this.GetAllAdmRole(); // Call method to get all roles when component is initialized
  }

  // Fetch all roles from the API
  GetAllAdmRole(): void {
    this.service.GetAllAdmRole().subscribe(
      data => {
        this.admroleList = data; // Assign the data to admroleList
        console.log("admRoleList Data is ", data);
      },
      error => {
        Swal.fire('Error', 'Failed to fetch role list. Please try again later.', 'error');
        console.error('Error fetching role list', error);
      }
    );
  }

  // Edit role based on AdmRoleId
  Edit(AdmRoleId: string): void {
    this.router.navigateByUrl('/roleupdate/' + AdmRoleId);
  }

  // View specific role details
  View(AdmSenderSubscription: string): void {
    this.router.navigate(['/viewAdmSenderSubscription', AdmSenderSubscription]);
  }

  // Delete role by id
  deleteUser(id: number): void {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.service.DeleteAdmRole(id).subscribe(
          result => {
            if (result === 'Success') {
              // Filter out the deleted item from the list
              this.admroleList = this.admroleList.filter(
                item => item.AdmRoleId !== id // Assuming AdmRoleId is the correct identifier
              );
              Swal.fire('Deleted!', 'Your role has been deleted.', 'success');
              this.GetAllAdmRole(); // Refresh the list after deletion
            } else {
              Swal.fire('Error', 'Failed to delete role. Please try again.', 'error');
            }
          },
          error => {
            Swal.fire('Error', 'Failed to delete role. Please try again later.', 'error');
            console.error('Error deleting role', error);
          }
        );
      } else {
        Swal.fire('Canceled', 'Your role is safe :)', 'info');
      }
    });
  }

  // Toggle sidebar visibility
  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }

  // Toggle dropdown visibility for the clicked section
  toggleDropdown(section: string) {
    this.dropdownOpen = this.dropdownOpen === section ? null : section;
  }

  // Navigate to selected role's route
  selectRole(role: string, route: string) {
    console.log(`Role selected: ${role}`);
    this.router.navigate([route]);
  }

  // Logout functionality
  logout() {
    this.router.navigate(['/login']);
  }
}
