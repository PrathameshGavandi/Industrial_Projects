import { Component } from '@angular/core';

@Component({
  selector: 'app-package-subscription',
  templateUrl: './package-subscription.component.html',
  styleUrls: ['./package-subscription.component.scss']
})
export class PackageSubscriptionComponent {

  selectedPlan: string | null = null;

  selectPlan(plan: string) {
    this.selectedPlan = plan; // Update the selected plan
  }
}

