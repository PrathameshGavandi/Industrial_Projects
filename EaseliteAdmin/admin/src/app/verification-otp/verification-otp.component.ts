import { Component, ElementRef, Renderer2, ViewChild } from '@angular/core';
import { AdmRegistration } from '../Class';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { WebService } from '../Service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-verification-otp',
  templateUrl: './verification-otp.component.html',
  styleUrls: ['./verification-otp.component.scss']
})
export class VerificationOtpComponent {
  


  @ViewChild('input1') input1!: ElementRef;
  @ViewChild('input2') input2!: ElementRef;
  @ViewChild('input3') input3!: ElementRef;
  @ViewChild('input4') input4!: ElementRef;
  @ViewChild('input5') input5!: ElementRef;
  @ViewChild('input6') input6!: ElementRef;


  Id: any;
  admRegistration: AdmRegistration;
  AdmRegistrationlist: any[];
  showPassword: boolean;
  mainList: any[];
  otp1: any;
  otp2: any;
  otp3: any;
  otp4: any;
  otp5: any;
  otp6: any;

  constructor(private renderer: Renderer2, private router: Router, private http: HttpClient, private route: ActivatedRoute,
    private service: WebService) {
    this.admRegistration = new AdmRegistration();
    this.AdmRegistrationlist = [];
    this.mainList = []

    this.route.params.subscribe((params) => {
      this.Id = params['AdmRegistrationId'];
      console.log(" this.Id", this.Id)
    });

  }

  moveToNext(currentInput: any, nextInput: any): void {
    if (currentInput.value.length === 1) {
      nextInput.focus();
    }
  }
  SendOTPEmail() {


    this.service.GetAdmRegistrationById(this.Id).subscribe((result) => {
      this.AdmRegistrationlist = []
      console.log(this.AdmRegistrationlist);
      
      this.mainList = []
  
      this.admRegistration = result;
    });
    
  
    this.AdmRegistrationlist = []
    this.mainList = []
    console.log(this.admRegistration.Email);
    
    
    this.service.SendOTPEmail(this.admRegistration.Email).subscribe({
  
      next: (response) => {
        // alert("Otp Sent to your registered Email ")
  
  
        Swal.fire({
          icon: 'success',
          title: 'OTP Sent',
          text: 'OTP has been sent to your registered email address.',
          timer: 3000,
          showConfirmButton: false
        });
  
        console.log('Email sent successfully:', response);
        this.admRegistration.OTPNo = response.otp;
        console.log('Received OTP:', this.admRegistration.OTPNo);
  
        this.service.GetAllRegistration().subscribe((result) => {
          this.AdmRegistrationlist = result;
          this.mainList = this.AdmRegistrationlist.filter(x => x.Email == this.admRegistration.Email);
  
          for (let data1 of this.mainList) {
            this.Id = data1.AdmRegistrationId;
          }
  
          this.service.GetAdmRegistrationById(this.Id).subscribe((result) => {
            this.admRegistration = result;
            console.log("fun", this.admRegistration);
            this.admRegistration.OTPNo = response.otp;
            this.service.UpdateAdmRegistration(this.admRegistration).subscribe((result) => {
              if (result == 0) {
                // alert('Not updated!');
  
              } else {
                // alert('updated successfully');
                // this.router.navigateByUrl("/TermConditions/" + this.Id);
                this.router.navigateByUrl("/ResetPassword/" + this.Id);
              }
            });
          });
        });
      }
    });
  }


  
  OnSubmit1() {
    const enteredOTP = this.otp1 + this.otp2 + this.otp3 + this.otp4 + this.otp5 + this.otp6;
  
    // Ensure OTP fields are filled
    if (enteredOTP.length < 6) {
      Swal.fire({
        icon: 'error',
        title: 'Incomplete OTP',
        text: 'Please enter all 6 digits of the OTP.',
      });
      return;
    }
  
    this.service.GetAdmRegistrationById(this.Id).subscribe({
      next: (result) => {
        // Log the fetched data to verify
        console.log('Fetched AdmRegistration:', result);
  
        if (!result) {
          Swal.fire({
            icon: 'error',
            title: 'Invalid Data',
            text: 'Failed to fetch user data. Please try again.',
          });
          return;
        }
  
        this.admRegistration = result;
  
        // Validate OTP
        if (this.admRegistration.OTPNo === enteredOTP) {
          this.admRegistration.EmailStatus = "Active";
  
          this.service.UpdateAdmRegistration(this.admRegistration).subscribe({
            next: (updateResult) => {
              if (updateResult) {
                Swal.fire({
                  icon: 'success',
                  title: 'OTP Verified',
                  text: 'Your OTP has been verified successfully.',
                  timer: 3000,
                  showConfirmButton: false,
                });
                this.router.navigate(['/resetpassword', this.Id]);
              } else {
                Swal.fire({
                  icon: 'error',
                  title: 'Update Failed',
                  text: 'Failed to activate your email. Please try again.',
                });
              }
            },
            error: (err) => {
              Swal.fire({
                icon: 'error',
                title: 'Error',
                text: `An error occurred while updating your details: ${err.message}`,
              });
            },
          });
        } else {
          Swal.fire({
            icon: 'error',
            title: 'Invalid OTP',
            text: 'The entered OTP does not match. Please check and try again.',
          });
        }
      },
      error: (err) => {
        Swal.fire({
          icon: 'error',
          title: 'Error',
          text: `An error occurred while fetching user data: ${err.message}`,
        });
      },
    });
  }
  
  

}