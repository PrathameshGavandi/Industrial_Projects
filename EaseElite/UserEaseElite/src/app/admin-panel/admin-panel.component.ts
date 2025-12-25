import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent {

  isSidebarOpen = false;  // Variable to control sidebar visibility
  dropdownOpen = false;    // Variable to control dropdown visibility

  toggleSidebar() {
      this.isSidebarOpen = !this.isSidebarOpen;
  }

  toggleDropdown() {
      this.dropdownOpen = !this.dropdownOpen;
  }

  selectRole(role: string, route: string) {
      // Logic for selecting a role and navigating
      console.log(`Role selected: ${role}`);
      // Example: Navigate to the selected route
      this.router.navigate([route]);
  }
  // Logout functionality
  constructor(private router: Router) { }

  logout() {
    this.router.navigate(['/login']);
  }

}
