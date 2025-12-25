import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserFttComponent } from './user-ftt.component';

describe('UserFttComponent', () => {
  let component: UserFttComponent;
  let fixture: ComponentFixture<UserFttComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserFttComponent]
    });
    fixture = TestBed.createComponent(UserFttComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
