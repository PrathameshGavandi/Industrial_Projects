import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateElinfoComponent } from './update-elinfo.component';

describe('UpdateElinfoComponent', () => {
  let component: UpdateElinfoComponent;
  let fixture: ComponentFixture<UpdateElinfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateElinfoComponent]
    });
    fixture = TestBed.createComponent(UpdateElinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
