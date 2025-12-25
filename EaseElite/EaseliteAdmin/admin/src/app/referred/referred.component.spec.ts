import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReferredComponent } from './referred.component';

describe('ReferredComponent', () => {
  let component: ReferredComponent;
  let fixture: ComponentFixture<ReferredComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReferredComponent]
    });
    fixture = TestBed.createComponent(ReferredComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
