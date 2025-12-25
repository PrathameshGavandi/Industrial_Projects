import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Registration, Userprofile } from '../Class';
import { WebService } from '../Service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-kyc',
  templateUrl: './kyc.component.html',
  styleUrls: ['./kyc.component.scss']
})
export class KycComponent {
  userprofile1: Registration;
  userprofile: Userprofile;
  passportFile: File | null = null;
  addressProofFile: File | null = null;
  SID: any;

  constructor(private router: Router, private http: HttpClient, private service: WebService) {
    this.userprofile = new Userprofile();
    this.userprofile1 = new Registration();
  }

  ngOnInit(): void {
    this.SID = sessionStorage.getItem('SID');
    this.service.GetUserprofileById(this.SID).subscribe(result => {
      this.userprofile = result;
      console.log('User Profile', this.userprofile);
    });
  }

  onSubmit() {
    // Update the entity details
    this.service.UpdateUserProfile(this.userprofile).subscribe(result => {
      if (result > 0) {
        const formData = new FormData();
  
        if (this.passportFile) {
          // Concatenate "PassP" prefix to the passport file name
          const passportFileName = "PassP_" + this.passportFile.name;
          formData.append('passport', this.passportFile, passportFileName);
        }
        if (this.addressProofFile) {
          // Concatenate "AddressP" prefix to the address proof file name
          const addressProofFileName = "AddressP_" + this.addressProofFile.name;
          formData.append('addressProof', this.addressProofFile, addressProofFileName);
        }
  
        // Save both images
        this.service.SaveKycImage(formData, this.userprofile.UserProfileId).subscribe(() => {
          Swal.fire({
            icon: 'success',
            title: 'Update Successful',
            text: 'Your KYC documents have been updated successfully.',
            confirmButtonText: 'OK'
          }).then(() => {
            this.router.navigate(['/offerlist']);
          });
        });
      } else {
        Swal.fire({
          icon: 'error',
          title: 'Update Failed',
          text: 'Something went wrong! Please try again.',
          confirmButtonText: 'OK'
        });
      }
    });
  }
  
  fileChangeEvent(event: any, fileType: string): void {
    const file = event.target.files[0];
    if (fileType === 'passport') {
      this.passportFile = file;
    } else if (fileType === 'addressProof') {
      this.addressProofFile = file;
    }
  }
}
