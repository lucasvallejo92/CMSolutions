import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { Observable, Subscription } from 'rxjs';
import { ICredential } from 'src/app/interfaces/ICredential.interface';
import { IUser } from './IUser.interface';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private endpoint = `${environment.api_uri}/users/login`;
  public token: string;

  constructor(private _http: HttpClient, private _router: Router) {
    this.token = localStorage.getItem('token') || null;
  }

  login(credentials: ICredential) {
    let bearer: Subscription = this._http.post<{ token: string }>(this.endpoint, credentials).subscribe(resp => {
      if (resp && resp.token) {
        this.token = resp.token;
        localStorage.setItem('token', resp.token);
        this._router.navigate(['']);
        bearer.unsubscribe();
      }
    });
  }
  logout() {
    localStorage.removeItem('token');
    this._router.navigate(['login']);
  }
}
