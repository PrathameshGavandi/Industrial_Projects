import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserCompanionComponent } from './user-companion.component';

describe('UserCompanionComponent', () => {
  let component: UserCompanionComponent;
  let fixture: ComponentFixture<UserCompanionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserCompanionComponent]
    });
    fixture = TestBed.createComponent(UserCompanionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
