import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserExperience } from './user-experience';

describe('UserExperience', () => {
  let component: UserExperience;
  let fixture: ComponentFixture<UserExperience>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserExperience]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserExperience);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
