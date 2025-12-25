import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from 'src/app/Service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-carrier',
  templateUrl: './user-carrier.component.html',
  styleUrls: ['./user-carrier.component.scss']
})
export class UserCarrierComponent implements OnInit {
  userroleList: any[] = []; // Full list of roles
  filteredUserRoleList: any[] = []; // Filtered roles with RoleId === 2

  constructor(private router: Router, private http: HttpClient, private service: WebService) {}

  ngOnInit(): void {
    this.GetAllUserRole(); // Fetch all roles on component initialization
  }

  // Fetch all roles and filter by RoleId === 2
  GetAllUserRole(): void {
    this.service.GetAllUserRole().subscribe(
      (data) => {
        // Filter roles by RoleId === 2
        this.filteredUserRoleList = data.filter((user) => user.RoleId === 4);

        // Fetch user details for each filtered user
        this.filteredUserRoleList.forEach((user) => {
          this.service.GetRegistrationById(user.RegistrationId).subscribe(
            (details) => {
              user.FName = details.FName;
              user.LName = details.LName;
              user.Status = details.Status; 
              user.Email = details.Email; 
            },
            (error) => {
              console.error(`Error fetching details for RegistrationId ${user.RegistrationId}:`, error);
            }
          );
        });

        console.log('Filtered User Role List:', this.filteredUserRoleList);
      },
      (error) => {
        Swal.fire('Error', 'Failed to fetch role list. Please try again later.', 'error');
        console.error('Error fetching role list:', error);
      }
    );
  }
}
