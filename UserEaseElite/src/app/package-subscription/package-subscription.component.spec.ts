import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PackageSubscriptionComponent } from './package-subscription.component';

describe('PackageSubscriptionComponent', () => {
  let component: PackageSubscriptionComponent;
  let fixture: ComponentFixture<PackageSubscriptionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PackageSubscriptionComponent]
    });
    fixture = TestBed.createComponent(PackageSubscriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
