import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanionviewComponent } from './companionview.component';

describe('CompanionviewComponent', () => {
  let component: CompanionviewComponent;
  let fixture: ComponentFixture<CompanionviewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CompanionviewComponent]
    });
    fixture = TestBed.createComponent(CompanionviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
