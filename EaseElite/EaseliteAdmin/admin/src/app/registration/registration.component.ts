import { Component } from '@angular/core';
import { AdmRegistration } from '../Class';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {

  showPassword = false;
  showPopup = false; // Initialize showPopup
  showSuccessMessage = false; // Initialize showSuccessMessage

  user = {
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    otp: '',
    status: '',
  };

  togglePasswordVisibility(field: string) {
    if (field === 'password') {
      this.showPassword = !this.showPassword;
    }
  }

  onSubmit() {
    // Check if form is valid
    if (!this.isFormValid()) {
      console.error('Form is invalid');
      return;
    }

    // Proceed with valid data submission
    console.log(this.user);
    this.showSuccessMessage = true; // Show success message on successful submission
  }

  closePopup() {
    this.showSuccessMessage = false;
  }

  isFormValid(): boolean {
    return (
      this.user.firstName && this.user.firstName.length >= 2 &&
      this.user.lastName && this.user.lastName.length >= 2 &&
      this.user.email && this.isEmailValid(this.user.email) &&
      this.user.password && this.user.password.length >= 6 &&
      this.user.otp && this.user.otp.length > 0 && // Ensure OTP is filled
      this.user.status && this.user.status.length > 0 // Ensure status is selected
    );
  }

  isEmailValid(email: string): boolean {
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
  }
}
