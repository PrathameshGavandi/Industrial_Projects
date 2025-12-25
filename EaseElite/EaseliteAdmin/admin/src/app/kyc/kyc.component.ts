import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from '../Service';
import Swal from 'sweetalert2';
import { GlobalVariable } from '../Global';
import { UserProfile } from '../Class';

@Component({
  selector: 'app-kyc',
  templateUrl: './kyc.component.html',
  styleUrls: ['./kyc.component.scss']
})
export class KycComponent {
  UserprofileList: any[] = [];
  registrationlist: any[] = [];
  imgPath: string = GlobalVariable.BASE_API_URL;
userprofile: UserProfile;
  constructor(private router: Router, private http: HttpClient, private service: WebService) {
    this.userprofile=new UserProfile;
    this.GetAllUserProfile();
    this.GetAllRegistration();
  }

  GetAllUserProfile(): void {
    this.service.GetAllUserProfile().subscribe(data => {
      this.UserprofileList = data;
      console.log("UserprofileList Data is ", data);

      // Log Passport and AddressProof for each user
      this.UserprofileList.forEach(user => {
        console.log("Passport", user.Passport);
        console.log("Address Proof ", user.AddressProof);
      });
    });
  }

  GetAllRegistration(): void {
    this.service.GetAllRegistration().subscribe(data => {
        this.registrationlist = data;
        console.log("registrationlist Data is ", data);

        // Assuming each item in data has an 'Email' property
        data.forEach(registration => {
            console.log("Email: ", registration.Email);
        });
    });
}

approve(id): void {
  
console.log(id);

this.service.GetUserProfileById(id).subscribe(result => {
  this.userprofile = result;
  this.userprofile.KycStatus = "Approve";
  this.service.UpdateUserProfile(this.userprofile).subscribe(result => {
    if (result > 0) {
      
     
      // SweetAlert message
      Swal.fire({
        title: 'Success!',
        text: 'Kyc Approve updated successfully.',
        icon: 'success',
        confirmButtonText: 'OK'
      });
      this.GetAllUserProfile();
    }
  });
});


}

  delete(id: string): void {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this kyc!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#d33',
      cancelButtonColor: '#3085d6',
      confirmButtonText: 'Yes, Decline it!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.service.DeleteUserProfile(id).subscribe(result => {
          if (result === "Success") {
            this.UserprofileList = this.UserprofileList.filter(item => item.UserProfileId !== id);
            Swal.fire(
              'Declined!',
              'The KYC status has been declined.',
              'success'
            );
            this.GetAllUserProfile();
          }
        }, error => {
          Swal.fire(
            'Error!',
            'Failed to decline the KYC status. Please try again.',
            'error'
          );
        });
      } else {
        Swal.fire(
          'Cancelled',
          'The KYC status is safe :)',
          'info'
        );
      }
    });
}
}
