import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = sessionStorage.getItem('userToken'); //obtengo el token del session storage
    // en el login success guardo token haciendo sessionStorage.setItem('userToken', 'TOKEN');
    // al hacer logout debería hacer sessionStorage.removeItem('userToken');
    let newRequest = request;
    if(!!token) {
      const headers = request.headers.set('userToken', token);
      newRequest = request.clone({ headers });
    }
    return next.handle(newRequest);

  }
}
