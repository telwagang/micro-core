import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AkibaComponent } from './akiba.component';

describe('AkibaComponent', () => {
  let component: AkibaComponent;
  let fixture: ComponentFixture<AkibaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AkibaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AkibaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
