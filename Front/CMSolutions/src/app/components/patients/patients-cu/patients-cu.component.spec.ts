import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientsCuComponent } from './patients-cu.component';

describe('PatientsCuComponent', () => {
  let component: PatientsCuComponent;
  let fixture: ComponentFixture<PatientsCuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PatientsCuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PatientsCuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
