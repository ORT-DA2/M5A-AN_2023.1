import { Injectable } from '@angular/core';
import { Beer } from 'src/Models/Beer';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BeersService {
  uri = `${environment.baseUrl}/Beer`;
  constructor(private http: HttpClient) {}

  getBeers(): Observable<Beer> {
    return this.http.get<Beer>(this.uri);
  }

  getBeerById(id: number): Observable<Beer> {
    return this.http.get<Beer>(`${this.uri}/${id}`);
  }
}
