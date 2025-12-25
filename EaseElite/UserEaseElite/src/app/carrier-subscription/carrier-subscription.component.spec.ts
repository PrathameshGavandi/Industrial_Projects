import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarrierSubscriptionComponent } from './carrier-subscription.component';

describe('CarrierSubscriptionComponent', () => {
  let component: CarrierSubscriptionComponent;
  let fixture: ComponentFixture<CarrierSubscriptionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CarrierSubscriptionComponent]
    });
    fixture = TestBed.createComponent(CarrierSubscriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
