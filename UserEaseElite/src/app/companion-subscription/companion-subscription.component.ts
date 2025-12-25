import { Component } from '@angular/core';

@Component({
  selector: 'app-companion-subscription',
  templateUrl: './companion-subscription.component.html',
  styleUrls: ['./companion-subscription.component.scss']
})
export class CompanionSubscriptionComponent {

  selectedPlan: string | null = null;

  selectPlan(plan: string) {
    this.selectedPlan = plan; // Update the selected plan
  }
}
