import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewcompanionComponent } from './viewcompanion.component';

describe('ViewcompanionComponent', () => {
  let component: ViewcompanionComponent;
  let fixture: ComponentFixture<ViewcompanionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewcompanionComponent]
    });
    fixture = TestBed.createComponent(ViewcompanionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
