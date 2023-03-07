import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { environment } from '../../environments/environment';
import { Movie } from '../models/movie';
import { ICreateMovie } from '../interfaces/create-movie.interface';
import { IDeleteResponse } from '../interfaces/delete-response.interface';

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
    headers.append('clave', 'valor');
    return this._http.get<Movie[]>(`${environment.API_HOST_URL}/movies`, {headers}).pipe(
      tap((movies: Movie[]) => this._moviesBehaviorSubject$.next(movies)),
    );
  }

  public getMovieById(movieId: number): Observable<Movie> {
    return this._http.get<Movie>(`${environment.API_HOST_URL}/movies/${movieId}`);
  }

  public postMovie(movieToAdd: ICreateMovie): Observable<Movie> {
    return this._http.post<Movie>(`${environment.API_HOST_URL}/movies`, movieToAdd);
  }

  public putMovie(movieToUpdate: Movie): Observable<Movie> {
    return this._http.put<Movie>(`${environment.API_HOST_URL}/movies/${movieToUpdate.id}`, movieToUpdate);
  }

  public deleteMovie(movieId: number): Observable<IDeleteResponse> {
    return this._http.delete<IDeleteResponse>(`${environment.API_HOST_URL}/movies/${movieId}`);
  }
}
