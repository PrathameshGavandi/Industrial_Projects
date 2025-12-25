import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PackagesenderpanelComponent } from './packagesenderpanel.component';

describe('PackagesenderpanelComponent', () => {
  let component: PackagesenderpanelComponent;
  let fixture: ComponentFixture<PackagesenderpanelComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PackagesenderpanelComponent]
    });
    fixture = TestBed.createComponent(PackagesenderpanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
