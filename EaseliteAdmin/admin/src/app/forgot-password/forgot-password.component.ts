import { Component } from '@angular/core';
import {  Registration } from '../Class';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { WebService } from '../Service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent {

  
  registrationlist: any[]
  mainlist: any[]
  mainlist1:any[]
  registration: Registration;
  Id:any

  constructor(private router: Router,
    private http: HttpClient,
    private service: WebService) {
    this.registration = new Registration();
    this.registrationlist = []
    this.mainlist = []
    this.mainlist1=[]
   
  }
  OnSubmit() {
    this.registrationlist = []
    this.service.GetAllRegistration().subscribe((result) => {
      console.log(result);
      debugger
      for (let data of result) {
        this.registrationlist.push(data);
      }
      console.log("registration", this.registrationlist); //Email

      this.mainlist = this.registrationlist.filter(x => x.Email == this.registration.Email);
      console.log("e1", this.mainlist);

      if (this.mainlist.length == 1) {
        // alert('Email Id Existed');
        this.SendOTPEmail()
      }

      else {
        Swal.fire({
          icon: 'warning',
          title: 'Invalid',
          text: 'The Email was provided is invalid',
         
          timer: 2000, // Optional: the alert will automatically close after 2 seconds
          showConfirmButton: false // Optional: hides the "OK" button
        });


      }
    });

  }


  SendOTPEmail() {
    this.registrationlist = []
    this.mainlist = []
    this.mainlist1=[]
    this.service.SendOTPEmail(this.registration.Email).subscribe({

      next: (response) => {
        // alert("Email sent successfully")

        console.log('Email sent successfully:', response);
        Swal.fire({
          icon: 'success',
          title: 'Success!',
          text: 'The OTP has been sent to your Email successfully.',
          timer: 2000, // Optional: the alert will automatically close after 2 seconds
          showConfirmButton: false // Optional: hides the "OK" button
        });

       
        this.registration.OTPNo = response.otp;
        console.log('Received OTP:', this.registration.OTPNo);
       
        this.service.GetAllAdmRegistration().subscribe((result) => {
          this.registrationlist = result;
          this.mainlist1 = this.registrationlist.filter(x => x.Email == this.registration.Email);

          for (let data1 of this.mainlist1) {
            this.Id = data1.AdmRegistrationId;
       
          }
        
          this.service.GetAdmRegistrationById(this.Id).subscribe((result) => {
            this.registration = result;
            console.log("fun", this.registration);

          
            this.registration.OTPNo = response.otp;
            this.service.UpdateAdmRegistration(this.registration).subscribe((result) => {
              if (result == 0) {
                alert('Not updated!');

              } else {
                // alert('updated successfully');
                this.router.navigateByUrl("/verificationotp/" + this.Id);

                
              }
            });
          });
        });
      }
    });
  }


}
