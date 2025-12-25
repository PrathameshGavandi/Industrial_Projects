import { Component } from '@angular/core';
import { AdmRegistration } from '../Class';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.scss']
})
export class UserRegistrationComponent {

  showPassword = false;
  showConfirmPassword = false;
  showPopup: boolean;
  showSuccessMessage: boolean;

  togglePasswordVisibility(field: string) {
      if (field === 'password') {
          this.showPassword = !this.showPassword;
      } else if (field === 'confirmPassword') {
          this.showConfirmPassword = !this.showConfirmPassword;
      }
  }

  registration: AdmRegistration;
  user = {
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    confirmPassword: '',
     referralCode: ''
  };

  onSubmit() {
    // Check if form is valid
    
    // if (!this.isFormValid()) {
    //   console.error('Form is invalid');
    //   return;
    // }
    
    // Proceed with valid data submission
    console.log(this.user);

  }
  closePopup() {
    this.showSuccessMessage = false;
  }
  // isFormValid(): boolean {
  //   return (
  //     this.user.firstName && this.user.firstName.length >= 2 &&
  //     this.user.lastName && this.user.lastName.length >= 2 &&
  //     this.user.email && this.isEmailValid(this.user.email) &&
  //     this.user.password && this.user.password.length >= 6 &&
  //     this.user.password === this.user.confirmPassword
  //   );
  // }

  isEmailValid(email: string): boolean {
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
  }
}
function closePopup() {
  throw new Error('Function not implemented.');
}

