import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarrierpanelComponent } from './carrierpanel.component';

describe('CarrierpanelComponent', () => {
  let component: CarrierpanelComponent;
  let fixture: ComponentFixture<CarrierpanelComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CarrierpanelComponent]
    });
    fixture = TestBed.createComponent(CarrierpanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
