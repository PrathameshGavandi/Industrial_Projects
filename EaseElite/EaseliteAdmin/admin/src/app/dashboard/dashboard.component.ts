import { Component } from '@angular/core';
import { WebService } from '../Service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
  firstTimeCount: number = 0;
  companionCount: number = 0;
  carrierCount: number = 0;
  packageSenderCount: number = 0;

  constructor(private service: WebService) {
    this.GetAllAdmRole();
  }

  GetAllAdmRole(): void {
    this.service.GetAllUserRole().subscribe({
      next: (data: any[]) => {
        // Reset counts before calculating
        this.firstTimeCount = data.filter(user => user.RoleId === 2).length;
        this.companionCount = data.filter(user => user.RoleId === 3).length;
        this.carrierCount = data.filter(user => user.RoleId === 4).length;
        this.packageSenderCount = data.filter(user => user.RoleId === 5).length;
      },
      error: (err) => {
        console.error('Error fetching user roles:', err);
        Swal.fire({
          title: 'Error!',
          text: 'Failed to load user roles. Please try again later.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      }
    });
  }
}
