import { Component, OnInit } from '@angular/core';
import { PatientsService } from '../../../services/patients/patients.service';
import { showDate } from '../../../utils/dateHandler';

@Component({
  selector: 'app-patients-list',
  templateUrl: './patients-list.component.html',
  styleUrls: ['./patients-list.component.scss']
})
export class PatientsListComponent implements OnInit {
  public showDate = showDate;
  constructor(public patientsService: PatientsService) {
    this.patientsService.getAll();
  }

  ngOnInit() {
  }

}
