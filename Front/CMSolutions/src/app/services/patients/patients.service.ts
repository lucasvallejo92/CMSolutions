import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment.prod';
import { Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientsService {
  private endpoint = `${environment.api_uri}/patients/`;
  public patient: any = null;
  public lastMR: any = null;
  public patients: any[] = [];
  public pagina = 0;

  constructor(private _http: HttpClient, private _toastr: ToastrService) { }

  public get(id: string): void {
    const uri = this.endpoint + id;
    this.patient = null;
    let response: Subscription = this._http.get<any>(uri)
      .subscribe(resp => {
        if (resp) {
          this.patient = resp;
          if (resp.medicalRecords.length) {
            this.lastMR = resp.medicalRecords[resp.medicalRecords.length - 1];
          } else {
            this.lastMR = null;
          }
          response.unsubscribe();
        }
      }, err => this.errorHandler(err, response));
  }

  public getAll(): void {
    const uri = this.endpoint;
    this.patients = [];
    let response: Subscription = this._http.get<any[]>(uri)
      .subscribe(resp => {
        if (resp) {
          this.patients = resp;
          response.unsubscribe();
        }
      }, err => this.errorHandler(err, response));
  }

  public create(patient: any): void {
    const uri = this.endpoint;
    let response: Subscription = this._http.post<any>(uri, patient)
      .subscribe(resp => {
        if (resp) {
          this._toastr.success('Paciente generado con éxito.');
          response.unsubscribe();
        }
      }, err => this.errorHandler(err, response));
  }

  public update(patient: any): void {
    const uri = this.endpoint + patient.id;
    let response: Subscription = this._http.put<any>(uri, patient)
      .subscribe(resp => {
        if (resp) {
          this._toastr.success('Paciente actualizado con éxito.');
          response.unsubscribe();
        }
      }, err => this.errorHandler(err, response));
  }

  errorHandler(err: HttpErrorResponse, sub: Subscription) {
    if (err) {
      this._toastr.error('Ocurrio un error, por favor intentelo nuevamente.');
      sub.unsubscribe();
    }
  }
}
