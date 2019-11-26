import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IUser } from '../../interfaces/IUser.interface';
import { HttpErrorResponse, HttpClient } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { IUserCreate } from 'src/app/interfaces/IUserCreate.interface';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private endpoint = `${environment.api_uri}/users/`;
  public user: IUser = null;
  public users: IUser[] = null;
  public pagina = 0;

  constructor(private _http: HttpClient, private _router: Router, private _toastr: ToastrService) { }

  get(id: string): void {
    const uri = this.endpoint + id;
    let response: Subscription = this._http.get<IUser>(uri)
      .subscribe(resp => {
        if (resp) {
          this.user = resp;
          response.unsubscribe();
        }
      }, err => this.errorHandler(err, response));
  }

  getAll(): void {
    const uri = this.endpoint;
    let response: Subscription = this._http.get<IUser[]>(uri)
      .subscribe(resp => {
        if (resp) {
          this.users = resp;
          response.unsubscribe();
        }
      }, err => this.errorHandler(err, response));
  }

  create(user: IUserCreate): void {
    const uri = this.endpoint;
    let response: Subscription = this._http.post<any>(uri, user)
      .subscribe(resp => {
        if (resp) {
          this._router.navigate(['login']);
          this._toastr.success('Usuaio creado con éxito.');
          response.unsubscribe();
        }
      }, err => this.errorHandler(err, response));
  }

  update(user: IUser): void {
    const uri = this.endpoint + user.id;
    let response: Subscription = this._http.put<any>(uri, user)
      .subscribe(resp => {
        if (resp) {
          this._toastr.success('Usuaio actualizado con éxito.');
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
