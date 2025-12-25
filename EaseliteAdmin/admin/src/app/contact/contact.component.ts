import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent {
  contactList = [];

  viewDetails(contact: any) {
    // Logic to view details
    console.log('Viewing details for:', contact);
  }

  edit(contact: any) {
    // Logic to edit
    console.log('Editing:', contact);
  }

  delete(id: number) {
    // Logic to delete
    if (confirm('Are you sure you want to delete this entry?')) {
      this.contactList = this.contactList.filter(contact => contact.id !== id);
      alert('Deleted Successfully');
    }
  }
  isSidebarOpen = false;  // Variable to control sidebar visibility
  dropdownOpen: string | null = null; // Variable to control dropdown visibility

  constructor(private router: Router) {}

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

