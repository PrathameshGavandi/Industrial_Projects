import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { WebService } from '../Service';
import { AdmRole } from '../Class';  // Assuming AdmRole is defined in Class.ts
import Swal from 'sweetalert2'; // Import SweetAlert2

@Component({
  selector: 'app-roleupdate',
  templateUrl: './roleupdate.component.html',
  styleUrls: ['./roleupdate.component.scss']
})
export class RoleupdateComponent implements OnInit {
  admrole: AdmRole = new AdmRole();  // Initialize to avoid null references
  AdmRoleId: string | null = null;  // The role ID passed through route params

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: WebService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.AdmRoleId = params['AdmRoleId'];  // Get the ID from route params

      // Fetch role details by ID
      this.service.GetAdmRoleById(this.AdmRoleId).subscribe(result => {
        this.admrole = result;  // Populate the form with existing role data
      }, error => {
        console.error('Error fetching role:', error);
        Swal.fire({
          title: 'Error!',
          text: 'Failed to load role details. Please try again.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      });
    });
  }

  onUpdate(): void {
    if (!this.admrole || !this.AdmRoleId) {
      Swal.fire({
        title: 'Warning!',
        text: 'Form data is missing or invalid.',
        icon: 'warning',
        confirmButtonText: 'OK'
      });
      return;
    }

    // Call service to update role details
    this.service.UpdateAdmRole(this.admrole).subscribe(result => {
      if (result === 'Failed') {
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
          this.router.navigate(['/rolelist']);  // Redirect after successful update
        });
      }
    }, error => {
      console.error('Error updating role:', error);
      Swal.fire({
        title: 'Error!',
        text: 'Failed to update role. Please try again.',
        icon: 'error',
        confirmButtonText: 'OK'
      });
    });
  }
}
