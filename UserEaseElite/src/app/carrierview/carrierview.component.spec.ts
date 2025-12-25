import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarrierviewComponent } from './carrierview.component';

describe('CarrierviewComponent', () => {
  let component: CarrierviewComponent;
  let fixture: ComponentFixture<CarrierviewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CarrierviewComponent]
    });
    fixture = TestBed.createComponent(CarrierviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
