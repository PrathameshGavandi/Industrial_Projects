import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentDetail3Component } from './payment-detail3.component';

describe('PaymentDetail3Component', () => {
  let component: PaymentDetail3Component;
  let fixture: ComponentFixture<PaymentDetail3Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PaymentDetail3Component]
    });
    fixture = TestBed.createComponent(PaymentDetail3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
