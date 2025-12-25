import { Component } from '@angular/core';

@Component({
  selector: 'app-carrier-subscription',
  templateUrl: './carrier-subscription.component.html',
  styleUrls: ['./carrier-subscription.component.scss']
})
export class CarrierSubscriptionComponent {

  selectedPlan: string | null = null;

  selectPlan(plan: string) {
    this.selectedPlan = plan; // Update the selected plan
  }
}
