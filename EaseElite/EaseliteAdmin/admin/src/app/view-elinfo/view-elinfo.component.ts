import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WebService } from '../Service';

@Component({
  selector: 'app-view-elinfo',
  templateUrl: './view-elinfo.component.html',
  styleUrls: ['./view-elinfo.component.scss']
})
export class ViewElinfoComponent implements OnInit {
  
  elinfoDetails: any;
  AdmELInfoId: string;
  router: any;

  constructor(private route: ActivatedRoute, private service: WebService) { }

  ngOnInit(): void {
    this.AdmELInfoId = this.route.snapshot.paramMap.get('AdmELInfoId');
    this.service.GetAdmELInfoById(this.AdmELInfoId).subscribe((data) => {
      this.elinfoDetails = data;
    });
  }

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

  


