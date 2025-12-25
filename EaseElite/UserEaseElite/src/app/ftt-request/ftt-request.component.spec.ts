import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FttRequestComponent } from './ftt-request.component';

describe('FttRequestComponent', () => {
  let component: FttRequestComponent;
  let fixture: ComponentFixture<FttRequestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FttRequestComponent]
    });
    fixture = TestBed.createComponent(FttRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
