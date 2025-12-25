import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPackageSenderComponent } from './user-package-sender.component';

describe('UserPackageSenderComponent', () => {
  let component: UserPackageSenderComponent;
  let fixture: ComponentFixture<UserPackageSenderComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserPackageSenderComponent]
    });
    fixture = TestBed.createComponent(UserPackageSenderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
