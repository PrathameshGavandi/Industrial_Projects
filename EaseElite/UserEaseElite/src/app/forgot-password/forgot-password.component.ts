import { Component } from '@angular/core';
import {  Login } from '../Class';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent {
login:Login;


  Email: string = '';
  // showForgotPassword: boolean = false;


  resetPassword() {
    // Handle password reset logic here
    console.log('Forgot password email:', this.Email);
    // Perform password reset action, e.g., call an API
    // this.showForgotPassword = false; // Hide the forgot password form after submission
  }
}
