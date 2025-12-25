import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanionListComponent } from './companion-list.component';

describe('CompanionListComponent', () => {
  let component: CompanionListComponent;
  let fixture: ComponentFixture<CompanionListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CompanionListComponent]
    });
    fixture = TestBed.createComponent(CompanionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
