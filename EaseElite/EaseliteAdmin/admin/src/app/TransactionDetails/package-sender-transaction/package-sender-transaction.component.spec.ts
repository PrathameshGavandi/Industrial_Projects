import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PackageSenderTransactionComponent } from './package-sender-transaction.component';

describe('PackageSenderTransactionComponent', () => {
  let component: PackageSenderTransactionComponent;
  let fixture: ComponentFixture<PackageSenderTransactionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PackageSenderTransactionComponent]
    });
    fixture = TestBed.createComponent(PackageSenderTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
