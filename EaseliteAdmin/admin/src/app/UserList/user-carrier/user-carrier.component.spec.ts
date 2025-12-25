import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserCarrierComponent } from './user-carrier.component';

describe('UserCarrierComponent', () => {
  let component: UserCarrierComponent;
  let fixture: ComponentFixture<UserCarrierComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserCarrierComponent]
    });
    fixture = TestBed.createComponent(UserCarrierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
