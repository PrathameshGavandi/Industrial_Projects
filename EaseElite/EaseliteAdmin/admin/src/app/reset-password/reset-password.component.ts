import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdmRegistration } from '../Class';
import { WebService } from '../Service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent {
  admRegistration: AdmRegistration;
  Id: any;

  showPassword: boolean = false;
  showConfirmPassword: boolean = false;

  newPassword: string = '';
  confirmPassword: string = '';

  constructor(
    private router: Router,
    private service: WebService,
    private route: ActivatedRoute
  ) {
    this.admRegistration = new AdmRegistration();
    this.route.params.subscribe((params) => {
      this.Id = params['AdmRegistrationId'];
      this.getAdmRegistrationById();
    });
  }

  // Get Admin Registration by ID
  getAdmRegistrationById() {
    this.service.GetAdmRegistrationById(this.Id).subscribe((result) => {
      this.admRegistration = result;
    });
  }

  // Toggle password visibility for both fields
  togglePasswordVisibility(type: string) {
    if (type === 'newPassword') {
      this.showPassword = !this.showPassword;
    } else if (type === 'confirmPassword') {
      this.showConfirmPassword = !this.showConfirmPassword;
    }
  }

  // Submit the new password
  onSubmit(form: any) {
    if (!form.valid) {
      return;
    }

    if (this.newPassword === this.confirmPassword) {
      this.admRegistration.Password = this.newPassword;

      this.service.UpdateAdmRegistration(this.admRegistration).subscribe((result) => {
        if (result === 0) {
          Swal.fire({
            title: 'Error!',
            text: 'Something went wrong! Please try again.',
            icon: 'error',
            confirmButtonText: 'OK'
          });
        } else {
          Swal.fire({
            title: 'Success!',
            text: 'Password changed successfully.',
            icon: 'success'
          }).then(() => {
            this.router.navigate(['/login']);
          });
        }
      });
    } else {
      Swal.fire({
        title: 'Error!',
        text: 'Passwords do not match.',
        icon: 'error',
        confirmButtonText: 'OK'
      });
    }
  }
}
