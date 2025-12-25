import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from '../Service';
import { GlobalVariable } from '../Global';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-elinfo-list',
  templateUrl: './elinfo-list.component.html',
  styleUrls: ['./elinfo-list.component.scss']
})
export class ElinfoListComponent {
  imgPath: string = GlobalVariable.BASE_API_URL;
  elinfoList: any[] = []; // Defining the type and initializing the list
  admRegistration: any;
  GetAdmELInfoById:any;
  constructor(private router: Router, private http: HttpClient, private service: WebService) {
    this.GetAllAdmELInfo();
  }

  GetAllAdmELInfo(): void {
    this.service.GetAllAdmELInfo().subscribe(data => {
      this.elinfoList = data;
      console.log("admFttSubscriptionList Data is ", data);
    }, (error) => {
      console.error('Error fetching data:', error);
      Swal.fire({
        title: 'Error!',
        text: 'Failed to load information. Please try again later.',
        icon: 'error',
        confirmButtonText: 'OK'
      });
    });
  }

  viewDetails(AdmELInfoId: string): void {
    this.router.navigate(['/viewelinfo', AdmELInfoId]);
  }

  editUser(AdmELInfoId: string): void {
    this.router.navigateByUrl('/updateelinfo/' + AdmELInfoId);
  }

  Delete(id: number): void {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You won’t be able to revert this!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.isConfirmed) {
        // Retrieve city master info by ID
        this.service.GetAdmELInfoById(id).subscribe({
          next: (admRegistration) => {
            // Set city master info and update status
            this.admRegistration = { ...admRegistration, Status: "InActive" };
            
            // Update city master status to "InActive"
            this.service.UpdateAdmELInfo(this.admRegistration).subscribe({
              next: (updateResult) => {
                if (updateResult === 0) {
                  Swal.fire({
                    title: 'Error!',
                    text: 'Something went wrong! Please try again.',
                    icon: 'error',
                    confirmButtonText: 'Ok'
                  });
                } else {
                  Swal.fire(
                    'Deleted!',
                    'Your item has been deleted.',
                    'success'
                  );
                  this.GetAdmELInfoById();
                }
              },
              error: () => {
                Swal.fire(
                  'Error!',
                  'There was an error updating your item.',
                  'error'
                );
              }
            });
          },
          error: () => {
            Swal.fire(
              'Error!',
              'Failed to retrieve city master information.',
              'error'
            );
          }
        });
      }
    });
  }


  showSuccessAlert3() {
    Swal.fire({
      title: 'Success',
      html: ' <b style="color:red;">Are you sure you want to delete this record?</b>',
      icon: 'success'
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
