import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FttlistComponent } from './fttlist.component';

describe('FttlistComponent', () => {
  let component: FttlistComponent;
  let fixture: ComponentFixture<FttlistComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FttlistComponent]
    });
    fixture = TestBed.createComponent(FttlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
