import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmRoleComponent } from './adm-role.component';

describe('AdmRoleComponent', () => {
  let component: AdmRoleComponent;
  let fixture: ComponentFixture<AdmRoleComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdmRoleComponent]
    });
    fixture = TestBed.createComponent(AdmRoleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
