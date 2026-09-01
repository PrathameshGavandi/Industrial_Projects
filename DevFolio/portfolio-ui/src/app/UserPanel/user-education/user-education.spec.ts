import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserEducation } from './user-education';

describe('UserEducation', () => {
  let component: UserEducation;
  let fixture: ComponentFixture<UserEducation>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserEducation]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserEducation);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
