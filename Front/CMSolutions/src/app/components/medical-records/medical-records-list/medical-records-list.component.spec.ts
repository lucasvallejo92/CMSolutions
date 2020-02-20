import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicalRecordsListComponent } from './medical-records-list.component';

describe('MedicalRecordsListComponent', () => {
  let component: MedicalRecordsListComponent;
  let fixture: ComponentFixture<MedicalRecordsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MedicalRecordsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MedicalRecordsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});