import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPortfolio } from './user-portfolio';

describe('UserPortfolio', () => {
  let component: UserPortfolio;
  let fixture: ComponentFixture<UserPortfolio>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserPortfolio]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserPortfolio);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
