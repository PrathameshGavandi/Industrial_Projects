import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatefttComponent } from './updateftt.component';

describe('UpdatefttComponent', () => {
  let component: UpdatefttComponent;
  let fixture: ComponentFixture<UpdatefttComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdatefttComponent]
    });
    fixture = TestBed.createComponent(UpdatefttComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
