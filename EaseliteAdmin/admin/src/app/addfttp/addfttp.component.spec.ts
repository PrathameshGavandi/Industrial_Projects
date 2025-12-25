import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddfttpComponent } from './addfttp.component';

describe('AddfttpComponent', () => {
  let component: AddfttpComponent;
  let fixture: ComponentFixture<AddfttpComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddfttpComponent]
    });
    fixture = TestBed.createComponent(AddfttpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
