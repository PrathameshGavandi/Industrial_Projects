import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FirsttimeTravellerDetailsComponent } from './firsttime-traveller-details.component';

describe('FirsttimeTravellerDetailsComponent', () => {
  let component: FirsttimeTravellerDetailsComponent;
  let fixture: ComponentFixture<FirsttimeTravellerDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FirsttimeTravellerDetailsComponent]
    });
    fixture = TestBed.createComponent(FirsttimeTravellerDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
