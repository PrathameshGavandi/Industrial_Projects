import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanionSubscriptionComponent } from './companion-subscription.component';

describe('CompanionSubscriptionComponent', () => {
  let component: CompanionSubscriptionComponent;
  let fixture: ComponentFixture<CompanionSubscriptionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CompanionSubscriptionComponent]
    });
    fixture = TestBed.createComponent(CompanionSubscriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
