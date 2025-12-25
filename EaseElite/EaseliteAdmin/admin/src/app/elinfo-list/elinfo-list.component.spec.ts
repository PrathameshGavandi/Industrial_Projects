import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ElinfoListComponent } from './elinfo-list.component';

describe('ElinfoListComponent', () => {
  let component: ElinfoListComponent;
  let fixture: ComponentFixture<ElinfoListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ElinfoListComponent]
    });
    fixture = TestBed.createComponent(ElinfoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
