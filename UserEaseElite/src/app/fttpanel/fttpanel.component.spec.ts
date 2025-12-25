import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FttpanelComponent } from './fttpanel.component';

describe('FttpanelComponent', () => {
  let component: FttpanelComponent;
  let fixture: ComponentFixture<FttpanelComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FttpanelComponent]
    });
    fixture = TestBed.createComponent(FttpanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
