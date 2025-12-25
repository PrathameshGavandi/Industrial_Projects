import { Component, ViewChild } from '@angular/core';
import { WebService } from '../Service';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AdmFttSubscription } from '../Class';
import Swal from 'sweetalert2';
// import { noWhitespaceValidator } from './path-to-validator'; // Update the path accordingly

@Component({
  selector: 'app-addfttp',
  templateUrl: './addfttp.component.html',
  styleUrls: ['./addfttp.component.scss']
})
export class AddfttpComponent {
  @ViewChild('AdmFttSubscriptionForm') form: NgForm;
  admFttSubscription = new AdmFttSubscription();

  constructor(private router: Router,
              private http: HttpClient,
              private service: WebService) {
    this.admFttSubscription = new AdmFttSubscription();
  }

  // ngOnInit() {
  //   this.form.controls['title'].setValidators([noWhitespaceValidator()]);
  //   this.form.controls['subtitle'].setValidators([noWhitespaceValidator()]);
  //   this.form.controls['description'].setValidators([noWhitespaceValidator()]);
  //   this.form.controls['title'].updateValueAndValidity();
  //   this.form.controls['subtitle'].updateValueAndValidity();
  //   this.form.controls['description'].updateValueAndValidity();
  // }
  onSubmit() {
    console.log("admFttSubscription", this.admFttSubscription);

    this.service.AddAdmFttSubscription(this.admFttSubscription).subscribe((result) => {
      if (result > 0) {
        Swal.fire({
          title: 'Success!',
          text: 'Saved Successfully.',
          icon: 'success',
          confirmButtonText: 'OK'
        }).then(() => {
          // Navigate to the target page after success
          this.router.navigate(['/fttlist']); // Replace '/target-route' with your actual route
        });
      } else {
        Swal.fire({
          title: 'Error!',
          text: 'Something went wrong! Please try again.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      }
    });

    this.form.resetForm();
  }
}
