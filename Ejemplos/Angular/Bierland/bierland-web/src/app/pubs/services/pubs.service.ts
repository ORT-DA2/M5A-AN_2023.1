import { Injectable } from '@angular/core';
import { Pub } from 'src/Models/Pub';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PubsService {
  uri = `${environment.baseUrl}/Pub`;

  constructor(private http: HttpClient) {}

  getPubs(): Observable<Pub> {
    return this.http.get<Pub>(this.uri);
  }

  addPub(pub: Pub): Observable<Pub> {
    return this.http.post<Pub>(this.uri, pub);
  }

  getPubById(id: number): Observable<Pub> {
    return this.http.get<Pub>(`${this.uri}/${id}`);
  }

  putPub(pub: Pub): Observable<void> {
    return this.http.put<void>(`${this.uri}/${pub.id}`, pub);
  }

  deletePub(id: number): Observable<void> {
    return this.http.delete<void>(`${this.uri}/${id}`);
  }
}
