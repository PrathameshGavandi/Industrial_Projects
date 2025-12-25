import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanionpanelComponent } from './companionpanel.component';

describe('CompanionpanelComponent', () => {
  let component: CompanionpanelComponent;
  let fixture: ComponentFixture<CompanionpanelComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CompanionpanelComponent]
    });
    fixture = TestBed.createComponent(CompanionpanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
