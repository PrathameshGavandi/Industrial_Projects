import { Component } from '@angular/core';

@Component({
  selector: 'app-payment-detail2',
  templateUrl: './payment-detail2.component.html',
  styleUrls: ['./payment-detail2.component.scss']
})
export class PaymentDetail2Component {

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
