import { Component } from '@angular/core';

@Component({
  selector: 'app-payment-detail3',
  templateUrl: './payment-detail3.component.html',
  styleUrls: ['./payment-detail3.component.scss']
})
export class PaymentDetail3Component {
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