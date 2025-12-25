import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PackageSenderDetailsComponent } from './package-sender-details.component';

describe('PackageSenderDetailsComponent', () => {
  let component: PackageSenderDetailsComponent;
  let fixture: ComponentFixture<PackageSenderDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PackageSenderDetailsComponent]
    });
    fixture = TestBed.createComponent(PackageSenderDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
