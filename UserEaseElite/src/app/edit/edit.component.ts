import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Userprofile } from '../Class';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { GlobalVariable } from '../Global';
import { WebService } from '../Service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent {
  userprofile: Userprofile;
  filesToUpload: Array<File> = [];
  photoURL: string | ArrayBuffer | null = null; // Added for image preview
  imgPath: string = GlobalVariable.BASE_API_URL;
  UserProfileList1: any;
  userProfileList: any;
  UserProfileList: any;
  id

  constructor(private router: Router, private http: HttpClient, private service: WebService) {
    this.userprofile = new Userprofile();
   this.id= sessionStorage.getItem('SID');
   console.log(this.id);
   this.service.GetUserprofileById(this.userprofile).subscribe(result => {
    if (result > 0) {
     
    } else {
    
    }
  });
   
  }
  GetAllUserProfile(): void {
    this.service.GetAllUserProfile().subscribe(
      data => {
        this.UserProfileList1 = data; // Populate offerList with data from the API
        console.log("Offer list data: ", this.UserProfileList1);
      },
      error => {
        console.error("Error fetching offers: ", error);
      }
    );
  }
  
  delete(UserProfileId) {
    let confirmAction = confirm("Are you sure you want to delete");
    if (confirmAction) {
    this.service.DeleteUserProfile(UserProfileId).subscribe(result => {
    if (result == "Success") {
    this.UserProfileList1 = this.userProfileList.filter(
      item => item.UserProfileld !==  this.UserProfileList)
    alert("Deleted Successfully");
    this.GetAllUserProfile()
    }
      });
      } else {
    alert("Action canceled");
    }
    }

    
    onUpdate(): void {
      // Assuming you have a RegistrationId set in your component
      this.service.GetRegistrationById(this.userprofile.RegistrationId).subscribe(
        (result) => {
          this.userprofile = result; // Update userprofile with fetched data
          console.log("Fetched registration: ", this.userprofile);
    
          // Optionally, if you want to use OTPNo, handle it here
          // this.userprofile.OTPNo = response.otp; // Assuming `response` is defined somewhere
    
          // Now proceed to update the user profile
          this.service.UpdateUserProfile(this.userprofile).subscribe(
            (updateResult) => {
              if (updateResult === 0) {
                console.log("Update failed: No changes were made.");
                Swal.fire({
                  icon: 'warning',
                  title: 'Update failed',
                  text: 'No changes were made.',
                  confirmButtonColor: '#d33'
                });
              } else {
                console.log("Update successful: ", updateResult);
                Swal.fire({
                  icon: 'success',
                  title: 'Update successful',
                  text: 'Your profile has been updated.',
                  confirmButtonColor: '#3085d6'
                });
                // Optionally, navigate to another page or refresh the list
                // this.router.navigateByUrl("/some-route");
              }
            },
            (error) => {
              console.error("Error updating profile: ", error);
              Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Something went wrong while updating your profile. Please try again.',
                confirmButtonColor: '#d33'
              });
            }
          );
        },
        (error) => {
          console.error("Error fetching registration: ", error);
          Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Could not fetch registration details. Please try again.',
            confirmButtonColor: '#d33'
          });
        }
      );
    }
    
  onSubmit(): void {
    this.userprofile.RegistrationId=this.id
 this.userprofile.Country="ABC"
    this.userprofile.Province=""
    this.userprofile.City=""
    this.userprofile.Image=""
     this.userprofile.PostalCode=""
       this.userprofile.Passport=""
       this.userprofile.AddressProof=""
       this.userprofile.KycStatus=""
         this.userprofile.Status=""
        //  console.log('userprofile111:', this.userprofile); 
    this.service.AddUserProfile(this.userprofile).subscribe(result => {
      if (result > 0) {
        const formData = new FormData();
        formData.append('uploadedImage', this.filesToUpload[0], this.filesToUpload[0].name);

        this.service.SaveUserProfileImage(formData, result).subscribe(() => {
          Swal.fire({
            icon: 'success',
            title: 'Saved Successfully!',
            text: 'Your profile has been saved successfully.',
            confirmButtonColor: '#3085d6',
            confirmButtonText: 'OK'
          }).then(() => {
            // Optional: Navigate to another route after the user confirms
            // this.router.navigateByUrl('/UserProfile');
          });
        });
      } else {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Something went wrong! Please try again.',
          confirmButtonColor: '#d33',
          confirmButtonText: 'Retry'
        });
      }
    });
  }

  fileChangeEvent(fileInput: any): void {
    this.filesToUpload = <Array<File>>fileInput.target.files;
    if (this.filesToUpload.length > 0) {
      this.userprofile.Image = this.filesToUpload[0].name;
      const reader = new FileReader();
  
      reader.onload = (e: any) => {
        this.photoURL = e.target.result; // Set photoURL for preview
        console.log('Image preview URL:', this.photoURL); // Debugging line
      };
  
      reader.readAsDataURL(this.filesToUpload[0]); // Read the image file for preview
    }
  }
//   fileChangeEvent(fileInput: any): void {
//     this.filesToUpload = <Array<File>>fileInput.target.files;
//     if (this.filesToUpload.length > 0) {
//       this.userprofile.Image = this.filesToUpload[0].name;
//     }
  }

