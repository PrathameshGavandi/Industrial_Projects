import { Component } from '@angular/core';
import { AdmRegistration } from '../Class';
import { HttpClient } from '@angular/common/http';
import { WebService } from '../Service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  Email: string = '';
  Password: string = '';
  userid: any;
  passwordVisible: boolean = false;
  admRegistration: AdmRegistration;
  // AdmRegistrationId:any;

  constructor(private router: Router, private http: HttpClient, private service: WebService) {
    this.admRegistration = new AdmRegistration();
  }



  ngOnInit() {
    this.userid = JSON.parse(sessionStorage.getItem('SID'));
    if (this.userid == 0) {
      // alert("Invalid Email and Password.")
      // alert('Invalid Email or Password.');
    }
    else {
      // alert("Login Successfully");
      // this.showSuccessAlert() ;
      this.router.navigateByUrl("/adminpanel") ;
    }
  }

  OnSubmit() {
    this.service.Loginc(this.admRegistration.Email, this.admRegistration.Password).subscribe(
      (result) => {
        if (result && result.AdmRegistrationId) {
          
          // If result is valid and contains AdmRegistrationId
          sessionStorage.setItem('SID', result.AdmRegistrationId);
          this.userid = result.AdmRegistrationId;
  
          console.log("userid", this.userid);
          
          // Redirect to Dashboard if login is successful
          this.showSuccessAlert();
          this.router.navigateByUrl("/adminpanel");
        } else {
          // Handle case where login fails
          this.showErrorAlert('Invalid Email or Password.');
        }
      },
      (error) => {
        // Handle any errors that occur during the API call
        console.error("Login Error:", error);
        this.showErrorAlert('An error occurred while logging in. Please try again.');
      }
    );
  }
  

  // Toggle password visibility
  togglePasswordVisibility() {
    this.passwordVisible = !this.passwordVisible;
  }

  

  showSuccessAlert() {
    Swal.fire({
      title: 'Success',
      html: '<b style="color:green;">Welcome back! You are now logged in</b>',
      icon: 'success'
    });
  }

  showErrorAlert(message: string) {
    Swal.fire({
      title: 'Error',
      text: message,
      icon: 'error'
    });
  }
}
 