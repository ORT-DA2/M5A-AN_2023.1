import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { environment } from '../../environments/environment';
import { ICreateMovie } from '../interfaces/create-movie.interface';
import { IMessageResponse } from '../interfaces/message-response.interface';
import { Movie } from '../models/movie';
import { MOVIES_CONTROLLER_URL } from '../utils/api.routes';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  private _moviesBehaviorSubject$: BehaviorSubject<Movie[] | undefined>;

  constructor(
    private _http: HttpClient,
  ) {
    this._moviesBehaviorSubject$ = new BehaviorSubject<Movie[] | undefined>(undefined);
  }

  public get movies$(): Observable<Movie[] | undefined> {
    return this._moviesBehaviorSubject$.asObservable();
  }

  public getMovies(): Observable<Movie[]> {
    const headers = new HttpHeaders();
    headers.append('key', 'value');
    return this._http.get<Movie[]>(
      `${environment.API_HOST_URL}/${MOVIES_CONTROLLER_URL}`,
      {headers}
    ).pipe(
      tap((movies: Movie[]) => this._moviesBehaviorSubject$.next(movies)),
    );
  }

  public getMovieById(movieId: number): Observable<Movie> {
    return this._http.get<Movie>(`${environment.API_HOST_URL}/${MOVIES_CONTROLLER_URL}/${movieId}`);
  }

  public postMovie(movieToAdd: ICreateMovie): Observable<Movie> {
    return this._http.post<Movie>(`${environment.API_HOST_URL}/${MOVIES_CONTROLLER_URL}`, movieToAdd);
  }

  public putMovie(movieToUpdate: Movie): Observable<Movie> {
    return this._http.put<Movie>(
      `${environment.API_HOST_URL}/${MOVIES_CONTROLLER_URL}/${movieToUpdate.id}`,
      movieToUpdate
    );
  }

  public deleteMovie(movieId: number): Observable<IMessageResponse> {
    return this._http.delete<IMessageResponse>(
      `${environment.API_HOST_URL}/${MOVIES_CONTROLLER_URL}/${movieId}`
    );
  }
}
