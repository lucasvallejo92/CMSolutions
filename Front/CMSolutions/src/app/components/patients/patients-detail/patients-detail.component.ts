import { Component, OnInit } from '@angular/core';
import { PatientsService } from 'src/app/services/patients/patients.service';
import { ActivatedRoute, Router } from '@angular/router';
import { showDate } from '../../../utils/dateHandler';

@Component({
  selector: 'app-patients-detail',
  templateUrl: './patients-detail.component.html',
  styleUrls: ['./patients-detail.component.scss']
})
export class PatientsDetailComponent implements OnInit {
  private id = null;
  public showDate = showDate;
  constructor(public patientsService: PatientsService, private activatedRoute: ActivatedRoute, private router: Router) {
    this.activatedRoute.params.subscribe(params => {
      if (params && params.id) {
        this.id = params.id;
      } else {
        this.router.navigate(['/patients']);
      }
    });
    if (this.id) {
      this.patientsService.get(this.id);
    }
  }

  ngOnInit() {
  }

}
