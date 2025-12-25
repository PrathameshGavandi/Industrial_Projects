import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewcarrierComponent } from './viewcarrier.component';

describe('ViewcarrierComponent', () => {
  let component: ViewcarrierComponent;
  let fixture: ComponentFixture<ViewcarrierComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewcarrierComponent]
    });
    fixture = TestBed.createComponent(ViewcarrierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
