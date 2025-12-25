import { Component } from '@angular/core';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent {
  resetpassword = {
    password: '',
    confirmPassword: ''
  };

  resetPassword() {
    console.log('Password reset:', this.resetpassword);
    // Reset the form fields
    this.resetpassword.password = '';
    this.resetpassword.confirmPassword = '';
    // Optionally navigate or show a success message
  }

  // Optional: Add a method to check if passwords match
  passwordsMatch(): boolean {
    return this.resetpassword.password === this.resetpassword.confirmPassword;
  }
}
