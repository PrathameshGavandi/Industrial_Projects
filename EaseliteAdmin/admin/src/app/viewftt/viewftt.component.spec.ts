import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewfttComponent } from './viewftt.component';

describe('ViewfttComponent', () => {
  let component: ViewfttComponent;
  let fixture: ComponentFixture<ViewfttComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewfttComponent]
    });
    fixture = TestBed.createComponent(ViewfttComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
