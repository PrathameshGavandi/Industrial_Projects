import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmELinfoComponent } from './adm-elinfo.component';

describe('AdmELinfoComponent', () => {
  let component: AdmELinfoComponent;
  let fixture: ComponentFixture<AdmELinfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdmELinfoComponent]
    });
    fixture = TestBed.createComponent(AdmELinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
