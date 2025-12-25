import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { HttpClient } from '@angular/common/http';
import { WebService } from '../Service';
import { AuthService } from '../authguard.service.spec';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent {
  isSidebarOpen = false;  // Variable to control sidebar visibility
  dropdownOpen: string | null = null; // Variable to control dropdown visibility

  constructor(private authService: AuthService,private router: Router,private http: HttpClient, private service: WebService) {}

  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen; // Toggle sidebar visibility
  }

  toggleDropdown(section: string) {
    // Toggle dropdown visibility for the clicked section
    this.dropdownOpen = this.dropdownOpen === section ? null : section;
  }

  selectRole(role: string, route: string) {
    console.log(`Role selected: ${role}`); // Log selected role
    this.router.navigate([route]); // Navigate to the specified route
  }

  logout() {
    this.router.navigate(['/login']); // Navigate to the login page on logout
  }
}
