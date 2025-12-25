import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FttTransactionComponent } from './ftt-transaction.component';

describe('FttTransactionComponent', () => {
  let component: FttTransactionComponent;
  let fixture: ComponentFixture<FttTransactionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FttTransactionComponent]
    });
    fixture = TestBed.createComponent(FttTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
