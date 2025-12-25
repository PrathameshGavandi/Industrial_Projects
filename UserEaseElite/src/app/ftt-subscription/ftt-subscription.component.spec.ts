import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FttSubscriptionComponent } from './ftt-subscription.component';

describe('FttSubscriptionComponent', () => {
  let component: FttSubscriptionComponent;
  let fixture: ComponentFixture<FttSubscriptionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FttSubscriptionComponent]
    });
    fixture = TestBed.createComponent(FttSubscriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
