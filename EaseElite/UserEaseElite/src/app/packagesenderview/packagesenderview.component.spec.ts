import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PackagesenderviewComponent } from './packagesenderview.component';

describe('PackagesenderviewComponent', () => {
  let component: PackagesenderviewComponent;
  let fixture: ComponentFixture<PackagesenderviewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PackagesenderviewComponent]
    });
    fixture = TestBed.createComponent(PackagesenderviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
