import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanHomeComponent } from './loanhome.component';

describe('LoanHomeComponent', () => {
  let component: LoanHomeComponent;
  let fixture: ComponentFixture<LoanHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoanHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoanHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
