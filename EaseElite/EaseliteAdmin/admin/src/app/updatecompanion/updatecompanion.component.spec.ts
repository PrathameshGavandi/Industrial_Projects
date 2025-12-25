import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatecompanionComponent } from './updatecompanion.component';

describe('UpdatecompanionComponent', () => {
  let component: UpdatecompanionComponent;
  let fixture: ComponentFixture<UpdatecompanionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdatecompanionComponent]
    });
    fixture = TestBed.createComponent(UpdatecompanionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
