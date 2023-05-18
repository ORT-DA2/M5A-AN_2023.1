import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MoviesService } from '../../services/movies.service';
import { Movie } from '../../models/movie';
import { ADD_MOVIE_URL, getUrl, idParam, MOVIE_FORM_URL } from '../../utils/routes';
import { catchError, filter, of, switchMap, take, tap } from 'rxjs';
import { IMessageResponse } from '../../interfaces/message-response.interface';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss']
})
export class MovieListComponent implements OnInit {
  public filterValue: string = '';
  public movies: Movie[] = [];

  constructor(
    private _moviesService: MoviesService,
    private _router: Router,
  ) { }

  public ngOnInit(): void {
    this._moviesService.getMovies().pipe(
      take(1),
      catchError((err: any) => {
        console.log({err});
        return of(err);
      }),
    )
    .subscribe((movies: Movie[]) => {
      this.setMovies(movies);
    });
  }

  public navigateToAddMovie(): void {
    this._router.navigateByUrl(`/${ADD_MOVIE_URL}`);
  }

  public navigateToEditMovie(movie: Movie): void {
    this._router.navigateByUrl(`/${getUrl(MOVIE_FORM_URL, idParam, movie.id)}`);
  }

  public deleteMovie(movieToDelete: Movie): void {
    this._moviesService.deleteMovie(movieToDelete?.id).pipe(
      take(1),
      catchError((err: any) => {
        console.log({err});
        return of(err);
      }),
      filter((response: IMessageResponse) => response.success === true),
      switchMap(() => this._moviesService.getMovies()),
      take(1),
      catchError((err: any) => {
        console.log({err});
        return of(err);
      }),
      tap((movies: Movie[]) => this.setMovies(movies)),
    ).subscribe();
  }

  private setMovies = (movies: Movie[] | undefined) => {
    if(!movies) this.movies = [];
    else this.movies = movies;
  };
}
