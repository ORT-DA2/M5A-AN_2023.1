import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Login } from 'src/models/Login';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  uri = `${environment.baseUrl}/User`;
  constructor(private http: HttpClient) {}

  login(login: Login): Observable<string> {
    const myHeaders = new HttpHeaders();
    myHeaders.append('Accept', 'application/text');
    return this.http.post<string>(`${this.uri}/login`, login, { headers: myHeaders, responseType: 'text' as 'json' });
  }

  logout(): Observable<void> {
    const headers = new HttpHeaders().set('token', localStorage.token);
    return this.http.get<void>(`${this.uri}/logout`, { headers });
  }

  isLogued(): boolean {
    const token = localStorage.token;
    return token != null && token !== undefined && token !== '';
  }
}
