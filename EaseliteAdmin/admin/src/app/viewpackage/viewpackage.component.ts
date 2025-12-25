import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WebService } from '../Service';

@Component({
  selector: 'app-viewpackage',
  templateUrl: './viewpackage.component.html',
  styleUrls: ['./viewpackage.component.scss']
})
export class ViewpackageComponent implements OnInit {
  
  packageDetails: any;
  AdmSenderSubscriptionld: string;

  constructor(private route: ActivatedRoute, private service: WebService) { }

  ngOnInit(): void {
    this.AdmSenderSubscriptionld = this.route.snapshot.paramMap.get('AdmSenderSubscriptionld');
    this.service.GetAdmSenderSubscriptionById(this.AdmSenderSubscriptionld).subscribe((data) => {
      this.packageDetails = data;
    });
  }
}