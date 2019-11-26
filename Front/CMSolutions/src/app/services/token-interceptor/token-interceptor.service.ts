import { Injectable, Injector } from '@angular/core';
import { HttpInterceptor } from '@angular/common/http';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {

  constructor(private _injector: Injector) { }

  intercept(req, next) {
    const authService = this._injector.get(AuthService);
    const tokenizedReq = req.clone({
      setHeaders: {
        Authorization: authService.token
      }
    });
    return next.handle(tokenizedReq);
  }
}
