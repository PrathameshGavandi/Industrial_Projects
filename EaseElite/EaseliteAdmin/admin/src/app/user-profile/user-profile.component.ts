import { Component, ViewChild } from '@angular/core';
import { AdmRegistration, UserProfile } from '../Class';

import { WebService } from '../Service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';



@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent {
  @ViewChild('UserProfileForm') form: NgForm;
  userProfile = new   UserProfile();
  admRegistration = new AdmRegistration(
 );
  constructor(private router: Router,
    private http: HttpClient,
  private service: WebService) {
  // this.userProfile = new UserProfile();
  // this.userProfile.admRegistration = new AdmRegistration();
  }
  OnSubmit() {
  console.log("userProfile",this.userProfile);
  // this.service.AddUserProfile(this.userProfile).subscribe((result) => {
  // if (result > 0) {
  // alert('Saved Successfully.');
  // }
  // else {
  // alert ('Something went wrong! Please try again.')
  // }
  // });
  // this.form.resetForm();
  }
  }
  
