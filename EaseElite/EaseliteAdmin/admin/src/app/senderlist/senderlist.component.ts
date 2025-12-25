import { Component } from '@angular/core';
import { WebService } from '../Service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-senderlist',
  templateUrl: './senderlist.component.html',
  styleUrls: ['./senderlist.component.scss']
})
export class SenderlistComponent {


  admSenderSubscriptionList: any[];
  constructor(private router: Router, private http: HttpClient, private service: WebService) {
    this.admSenderSubscriptionList = []
    this.GetAlladmSenderSubscription();
  }


  GetAlladmSenderSubscription(): void {
    this.service.subscribe(data => {
      this.admSenderSubscriptionList = data;
      console.log("admSenderSubscriptionList Data is ", data);

    });
  }



  deleteUser(id) {
    console.log(id);

    let confirmAction = confirm("Are you sure you want to delete?");
    if (confirmAction) {
      this.service.DeleteAdmSenderSubscription(id).subscribe(result => {
        if (result == "Success") {
          this.admSenderSubscriptionList = this.admSenderSubscriptionList.filter(
            item => item.AdmSenderSubscriptionld !== this.admSenderSubscriptionList)
          alert("Deleted Successfully");
          this.GetAlladmSenderSubscription();
        }
      });
    } else {
      alert("Action canceled");
    }
  }
}