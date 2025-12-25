import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PackagesenderListComponent } from './packagesender-list.component';

describe('PackagesenderListComponent', () => {
  let component: PackagesenderListComponent;
  let fixture: ComponentFixture<PackagesenderListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PackagesenderListComponent]
    });
    fixture = TestBed.createComponent(PackagesenderListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
