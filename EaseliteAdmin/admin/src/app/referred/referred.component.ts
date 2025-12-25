import { Component } from '@angular/core';
import { Refferal } from '../Class';

@Component({
  selector: 'app-referred',
  templateUrl: './referred.component.html',
  styleUrls: ['./referred.component.scss']
})
export class ReferredComponent {
  referral:Refferal;
  onSubmit() {
    // Handle form submission
    console.log('Referral Data Submitted:', this.referral);
}
}
