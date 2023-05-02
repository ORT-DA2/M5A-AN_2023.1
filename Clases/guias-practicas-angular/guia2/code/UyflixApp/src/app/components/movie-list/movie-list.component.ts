import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MoviesService } from '../../services/movies.service';
import { Movie } from '../../models/movie';
import { ADD_MOVIE_URL } from '../../utils/routes';

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
    this.movies = this._moviesService.getMovies();
  }

  public navigateToAddMovie(): void {
    this._router.navigateByUrl(`/${ADD_MOVIE_URL}`);
  }

  public deleteMovie(movieToDelete: Movie): void {
    const movieWasDeleted = this._moviesService.deleteMovie(movieToDelete?.id);
    if(movieWasDeleted) {
      this.movies = this._moviesService.getMovies();
    }
  }
}
