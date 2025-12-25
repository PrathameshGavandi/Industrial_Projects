import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddcarrierComponent } from './addcarrier.component';

describe('AddcarrierComponent', () => {
  let component: AddcarrierComponent;
  let fixture: ComponentFixture<AddcarrierComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddcarrierComponent]
    });
    fixture = TestBed.createComponent(AddcarrierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
