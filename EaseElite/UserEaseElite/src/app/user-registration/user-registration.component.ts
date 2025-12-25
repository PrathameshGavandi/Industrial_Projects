import { Component } from '@angular/core';
import { Registration, Userprofile } from '../Class';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { WebService } from '../Service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.scss']
})
export class UserRegistrationComponent {

 userprofile : Userprofile
  registration:Registration
  showPopup: boolean;
  showSuccessMessage: boolean;
  registrationList: any[];
  userRole: any;
  mainlist: any[];
  Emailid: string;
  mainlist1: any[];
 
  RegistrationId: any;
  
  constructor(private router: Router, private http: HttpClient, private service: WebService) {
    this.registration= new  Registration ();
    this.userprofile = new Userprofile();
  }


showPassword: boolean = false;
showConfirmPassword: boolean = false;

togglePasswordVisibility(type: string) {
    if (type === 'password') {
        this.showPassword = !this.showPassword;
    } else if (type === 'confirmPassword') {
        this.showConfirmPassword = !this.showConfirmPassword;
    }
}

  onSubmit() {
   
    console.log("this.registration", this.registration);
    console.log("this.registration.Email", this.registration.Email);

// this.registration.EmailStatus="inactive"
// this.registration.OTPNo=""
// this.registration.DefaultRole="1"
// this.registration.Status="active"
    //====================================================================================================

    this.service.AddRegistration(this.registration).subscribe((result) => {
         
            if (result > 0) {
              alert('User Registrated Successfully.');
          //     this.userprofile.RegistrationId=result
          //     this.userprofile.FirstName=""
          //       this.userprofile.LastName=""
          //         this.userprofile.ContactNumber=""
          //           this.userprofile.Email=""
          //             this.userprofile.Address=""
          //               this.userprofile.AlternativeEmail=""
          // this.userprofile.Country=""
          // this.userprofile.Province=""
          // this.userprofile.City=""
          //  this.userprofile.Image=""
          //  this.userprofile.PostalCode=""
          //    this.userprofile.Passport=""
          //    this.userprofile.AddressProof=""
          //    this.userprofile.KycStatus=""
          //      this.userprofile.Status=""
          //     console.log("user profile", this.userprofile);
              

          // this.service.AddUserProfile(this.userprofile).subscribe(result => {
          //   if (result > 0) {
             
          //   } else {
          //     Swal.fire({
          //       icon: 'error',
          //       title: 'Oops...',
          //       text: 'Something went wrong! Please try again123.',
          //       confirmButtonColor: '#d33',
          //       confirmButtonText: 'Retry'
          //     });
          //   }
          // });

              Swal.fire({
                icon: 'success',
                title: 'User Registered Successfully!',
                showConfirmButton: false,
                timer: 2000
              });
              //Add Default user Role as a EndUser
              this.userRole.RegistrationId=result
              this.userRole.RoleId=1
              this.userRole.Status="Active"
              // this.service.AddUserRole(this.userRole).subscribe((result) => {
              //   if (result > 0) {
              //     // alert('add user Role Successfully.');
              //   }
              //   else {
              //     alert("Something went wrong! Please try again.")
                 }
                 
                //  else {
                //   Swal.fire({
                //     icon: 'error',
                //     title: 'Something went wrong!',
                //     text: 'Please try again later.',
                //     confirmButtonText: 'OK'
                //   });
                // }
              });
          


 //==========================================================================================================


    this.service.GetAllRegistration().subscribe((result) => {
      this.registrationList = []
      for (let data of result) {
        this.registrationList.push(data);
      }
      this.mainlist = this.registrationList.filter(x => x.Email == this.registration.Email);
      console.log("this.mainlist.length", this.mainlist.length);
      if (this.mainlist.length == 1) {
        alert('This email registered allready');
      }
      else {

        this.Emailid = this.registration.Email
        this.registration.EmailStatus = "Active"
        this.registration.OTPNo = ""
       this.registration.DefaultRole = "1"
        this.registration.Status = "Active"
        this.service.AddRegistration(this.registration).subscribe((result) => {
         console.log(result);
         
          if (result > 0) {
            alert('User Registrated Successfully.');

            //Add Default user Role as a EndUser
            this.userRole.RegistrationId=result
            this.userRole.RoleId=1
            this.userRole.Status="Active"
            // this.service.AddUserRole(this.userRole).subscribe((result) => {
            //   if (result > 0) {
            //     // alert('add user Role Successfully.');
            //   }
            //   else {
            //     alert("Something went wrong! Please try again.")
            //   }
            // });
         

            // this.SendOTPEmail()
          }
          else {
            alert("Something went wrong! Please try again.")
          }
        });

      }
    })
  }

//send otp to email and store to Database
  // SendOTPEmail() {
   
  //   this.registrationList = []
  //   this.mainlist1 = []
  //   this.service.SendOTPEmail(this.registration.Email).subscribe({

  //     next: (response) => {
  //       alert("Otp Sent to your registered Email ")

  //       console.log('Email sent successfully:', response);
  //       this.registration.OTPNo = response.otp;
  //       console.log('Received OTP:', this.registration.OTPNo);

  //       this.service.GetAllRegistration().subscribe((result) => {
  //         this.registrationList = result;
  //         this.mainlist1 = this.registrationList.filter(x => x.Email == this.registration.Email);

  //         for (let data1 of this.mainlist1) {
  //           this.registration = data1.RegistrationId;
  //         }

  //         this.service.GetRegistrationById(this.RegistrationId).subscribe((result) => {
  //           this.registration = result;
  //           console.log("fun", this.registration);
  //           this.registration.OTPNo = response.otp;
  //           this.service.UpdateRegistration(this.registration).subscribe((result) => {
  //             if (result == 0) {
  //               // alert('Not updated!');

  //             } else {
  //               alert('updated successfully');
  //               // this.router.navigateByUrl("/login/" + this.RegistrationId);
  //             }
  //           });
  //         });
  //       });
  //     }
  //   });
  // }

  // closePopup() {
  //   this.showSuccessMessage = false;
  // }
  isFormValid(): boolean {
    return (
      this.registration.FName && this.registration.FName.length >= 2 &&
      this.registration.LName && this.registration.LName.length >= 2 &&
      this.registration.Email && this.isEmailValid(this.registration.Email) &&
      this.registration.Password && this.registration.Password.length >= 8 &&
      this.registration.Password === this.registration.confirmPassword
    );
  }

  isEmailValid(email: string): boolean {
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
  }
}
// function closePopup() {
//   throw new Error('Function not implemented.');
// }

