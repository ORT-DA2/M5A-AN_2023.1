import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(
    private _authService: AuthService,
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = this._authService.getToken();
    // en el login success guardo token haciendo this._authService.setToken('TOKEN');
    // al hacer logout debería hacer this._authService.removeToken();
    let newRequest = request;
    if(!!token) {
      const headers = request.headers.set('userToken', token);
      newRequest = request.clone({ headers });
    }
    return next.handle(newRequest);

  }
}
