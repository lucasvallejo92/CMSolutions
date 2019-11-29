import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.prod';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { ICredential } from 'src/app/interfaces/ICredential.interface';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private endpoint = `${environment.api_uri}/users/login`;
  public token: string;

  constructor(private _http: HttpClient, private _router: Router, private _toastr: ToastrService) {
    this.token = localStorage.getItem('token') || 'Bearer xx.yy.zz';
  }

  login(credentials: ICredential): void {
    let bearer: Subscription = this._http.post<{ token: string }>(this.endpoint, credentials)
      .subscribe(resp => {
        if (resp && resp.token) {
          this.token = 'Bearer ' + resp.token;
          localStorage.setItem('token', this.token);
          this._router.navigate(['']);
          bearer.unsubscribe();
        }
      }, (err: HttpErrorResponse) => {
        if (err) {
          switch (err.status) {
            case 404:
              this._toastr.error('El email o contraseña son invalidos');
              break;
            default:
              this._toastr.error('Ocurrio un error, por favor intentelo nuevamente.');
              break;
          }
          bearer.unsubscribe();
        }
      });
  }
  logout() {
    localStorage.removeItem('token');
    this._router.navigate(['login']);
  }
}
