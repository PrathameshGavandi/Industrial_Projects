import { Component } from '@angular/core';
import { PaymentDetail } from '../Class';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent {


  paymentDetail: PaymentDetail;
 
  Paymentdetail  = {
    name: '',
    email: '',
    amount: '',
  
    
  };

  onSubmit() {
    console.log(this.paymentDetail );
  }

}
