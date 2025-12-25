import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewElinfoComponent } from './view-elinfo.component';

describe('ViewElinfoComponent', () => {
  let component: ViewElinfoComponent;
  let fixture: ComponentFixture<ViewElinfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewElinfoComponent]
    });
    fixture = TestBed.createComponent(ViewElinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
