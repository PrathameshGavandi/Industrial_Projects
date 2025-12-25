import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WebService } from '../Service';

@Component({
  selector: 'app-viewcompanion',
  templateUrl: './viewcompanion.component.html',
  styleUrls: ['./viewcompanion.component.scss']
})
export class ViewcompanionComponent implements OnInit {
  
  companionDetails: any;
  AdmCompSubscriptionld: string;

  constructor(private route: ActivatedRoute, private service: WebService) { }

  ngOnInit(): void {
    this.AdmCompSubscriptionld = this.route.snapshot.paramMap.get('AdmCompSubscriptionld');
    this.service.GetAdmCompSubscriptionById(this.AdmCompSubscriptionld).subscribe((data) => {
      this.companionDetails = data;
    });
  }
}