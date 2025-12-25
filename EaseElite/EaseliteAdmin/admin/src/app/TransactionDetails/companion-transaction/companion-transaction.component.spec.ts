import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanionTransactionComponent } from './companion-transaction.component';

describe('CompanionTransactionComponent', () => {
  let component: CompanionTransactionComponent;
  let fixture: ComponentFixture<CompanionTransactionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CompanionTransactionComponent]
    });
    fixture = TestBed.createComponent(CompanionTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
