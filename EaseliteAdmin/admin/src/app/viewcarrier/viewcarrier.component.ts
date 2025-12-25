import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WebService } from '../Service';

@Component({
  selector: 'app-viewcarrier',
  templateUrl: './viewcarrier.component.html',
  styleUrls: ['./viewcarrier.component.scss']
})
export class ViewcarrierComponent implements OnInit {
  
  carrierDetails: any;
  AdmCarrierSubscriptionld: string;

  constructor(private route: ActivatedRoute, private service: WebService) { }

  ngOnInit(): void {
    this.AdmCarrierSubscriptionld = this.route.snapshot.paramMap.get('AdmCarrierSubscriptionld');
    this.service.GetAdmCarrierSubscriptionById(this.AdmCarrierSubscriptionld).subscribe((data) => {
      this.carrierDetails = data;
    });
  }
}