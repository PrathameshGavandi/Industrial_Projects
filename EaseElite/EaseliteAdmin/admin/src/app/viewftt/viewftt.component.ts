import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WebService } from '../Service';

@Component({
  selector: 'app-viewftt',
  templateUrl: './viewftt.component.html',
  styleUrls: ['./viewftt.component.scss']
})
export class ViewfttComponent implements OnInit {
  
  fttDetails: any;
  AdmFttSubscriptionld: string;

  constructor(private route: ActivatedRoute, private service: WebService) { }

  ngOnInit(): void {
    this.AdmFttSubscriptionld = this.route.snapshot.paramMap.get('AdmFttSubscriptionld');
    this.service.GetAdmFttSubscriptionById(this.AdmFttSubscriptionld).subscribe((data) => {
      this.fttDetails = data;
    });
  }
}