import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentDetail2Component } from './payment-detail2.component';

describe('PaymentDetail2Component', () => {
  let component: PaymentDetail2Component;
  let fixture: ComponentFixture<PaymentDetail2Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PaymentDetail2Component]
    });
    fixture = TestBed.createComponent(PaymentDetail2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
