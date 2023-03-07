import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../../services/movies.service';
import { Movie } from '../../models/movie';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {

  public filterValue: string = '';
  public movies: Movie[] = [];

  constructor(
    private _moviesService: MoviesService,
    private _router: Router,
  ) { }

  public ngOnInit(): void {
    // cuando inicia el componente llamo al servicio para obtener las películas
    this.movies = this._moviesService.getMovies();
  }

  public navigateToAddMovie() {
    console.log('going to navigate to /movies/new');
    this._router.navigateByUrl('/movies/new');
  }

  public deleteMovie(movieToDelete: Movie): void {
    // voy a borrar la película
    const deleted = this._moviesService.deleteMovie(movieToDelete?.id);
    if(deleted) { // si se borró correctamente actualizo la lista de películas
      this.movies = this._moviesService.getMovies();
    }
  }
}
