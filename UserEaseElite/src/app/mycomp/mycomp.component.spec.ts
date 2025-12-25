import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MycompComponent } from './mycomp.component';

describe('MycompComponent', () => {
  let component: MycompComponent;
  let fixture: ComponentFixture<MycompComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MycompComponent]
    });
    fixture = TestBed.createComponent(MycompComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
