import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Notifications } from '../Class';
import { WebService } from '../Service';

@Component({
  selector: 'app-user-notifications',
  templateUrl: './user-notifications.component.html',
  styleUrls: ['./user-notifications.component.scss']
})
export class UserNotificationsComponent {
  @ViewChild('NotificationsForm') form: NgForm;
  notifications = new   Notifications();
  constructor(private router: Router,
  private http: HttpClient,
  private service: WebService) {
  this.notifications = new Notifications();
  }
  validateWhitespace(control: any) {
    if (control.value && control.value.trim().length === 0) {
      control.setErrors({ whitespace: true });
    } else {
      control.setErrors(null);
    }
  }
  OnSubmit() {
  console.log("notifications",this.notifications);
  this.service.AddNotifications(this.notifications).subscribe((result) => {
  if (result > 0) {
  alert('Saved Successfully.');
  }
  else {
  alert ('Something went wrong! Please try again.')
  }
  });
  this.form.resetForm();
  }
  }
  