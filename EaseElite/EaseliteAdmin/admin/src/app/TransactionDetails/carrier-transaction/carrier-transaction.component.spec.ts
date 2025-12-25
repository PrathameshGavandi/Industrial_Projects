import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarrierTransactionComponent } from './carrier-transaction.component';

describe('CarrierTransactionComponent', () => {
  let component: CarrierTransactionComponent;
  let fixture: ComponentFixture<CarrierTransactionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CarrierTransactionComponent]
    });
    fixture = TestBed.createComponent(CarrierTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
