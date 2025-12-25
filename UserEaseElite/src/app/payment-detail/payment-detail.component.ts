import { Component } from '@angular/core';

@Component({
  selector: 'app-payment-detail',
  templateUrl: './payment-detail.component.html',
  styleUrls: ['./payment-detail.component.scss']
})
export class PaymentDetailComponent {

  // choosePlan() {
  //   console.log('Plan selected');
  // }

  openPaypalScanner() {
    console.log('Opening PayPal scanner...');
    // Logic to open a PayPal scanner/modal
  }

  handleCardPayment() {
    console.log('Card payment initiated');
    // Logic for handling credit/debit card payment
  }
}