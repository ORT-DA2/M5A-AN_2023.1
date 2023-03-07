import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, of, take } from 'rxjs';
import { Movie } from '../../models/movie';
import { ICreateMovie } from '../../interfaces/create-movie.interface';
import { MoviesService } from '../../services/movies.service';
import { ValidateString } from '../../validators/string.validator';
import { MOVIE_LIST_URL } from '../../utils/routes';

@Component({
  selector: 'app-movie-form',
  templateUrl: './movie-form.component.html',
  styleUrls: ['./movie-form.component.css']
})
export class MovieFormComponent implements OnInit {

  public actualYear = new Date().getFullYear();

  public movieForm = new FormGroup({
    name: new FormControl(undefined, [Validators.required, ValidateString]),
    category: new FormControl(undefined, [Validators.required, ValidateString]),
    director: new FormControl(undefined, [Validators.required, ValidateString]),
    country: new FormControl(undefined, [Validators.required, ValidateString]),
    year: new FormControl(undefined, [Validators.required, Validators.min(1970), Validators.max(this.actualYear)]),
    rating: new FormControl(undefined, [Validators.required, Validators.min(1), Validators.max(5)]),
  });

  public isEditing = false;
  private movieId?: number;

  constructor(
    private _moviesService: MoviesService,
    private _router: Router,
    private _route: ActivatedRoute,
  ) { }

  public get name() { return this.movieForm.get('name'); }

  public get category() { return this.movieForm.get('category'); }

  public get director() { return this.movieForm.get('director'); }

  public get country() { return this.movieForm.get('country'); }

  public get year() { return this.movieForm.get('year'); }

  public get rating() { return this.movieForm.get('rating'); }

  public ngOnInit(): void {
    const id = this._route.snapshot.params?.['id'];
    console.log({id});
    if(!!id && id !== 'new') {
      this.isEditing = true;
      this.movieId = id;
      this._moviesService.getMovieById(id).pipe(
        take(1),
        catchError((err) => {
          console.log({err});
          return of(err);
        }),
      ).subscribe((movie: Movie) => {
        this.setMovie(movie);
      });
    }
    
  }

  public submitMovie(): void {
    if(this.movieForm.valid) {
      if(this.isEditing) {
        this.updateMovie();
      } else {
        this.createMovie();
      }
    }
  }

  private createMovie(): void {
    const movie: ICreateMovie = {
      name: this.movieForm.value.name,
      category: this.movieForm.value.category,
      director: this.movieForm.value.director,
      country: this.movieForm.value.country,
      year: this.movieForm.value.year,
      rating: this.movieForm.value.rating,
    };
    this._moviesService.postMovie(movie)
    .pipe(
      take(1),
      catchError((err) => {
        console.log({err});
        return of(err);
      }),
    )
    .subscribe((movie: Movie) => {
      if(!!movie?.id) {
        alert('Película creada!!');
        this.cleanForm();
        this._router.navigateByUrl(`/${MOVIE_LIST_URL}`);
      }
    });
  }

  private updateMovie(): void {
    if(!!this.movieId) {
      const movie = new Movie(
        this.movieId as number,
        this.movieForm.value.name,
        this.movieForm.value.category,
        this.movieForm.value.director,
        this.movieForm.value.country,
        this.movieForm.value.year,
        this.movieForm.value.rating,
      );
      this._moviesService.putMovie(movie)
      .pipe(
        take(1),
        catchError((err) => {
          console.log({err});
          return of(err);
        }),
      )
      .subscribe((movie: Movie) => {
        if(!!movie?.id) {
          alert('Película modificada!!');
          this._router.navigateByUrl(`/${MOVIE_LIST_URL}`);
        }
      });
    }
  }

  private setMovie(movie: Movie): void {
    this.name?.setValue(movie.name);
    this.category?.setValue(movie.category);
    this.director?.setValue(movie.director);
    this.country?.setValue(movie.country);
    this.year?.setValue(movie.year);
    this.rating?.setValue(movie.rating);
  }

  private cleanForm(): void {
    this.name?.setValue(undefined);
    this.category?.setValue(undefined);
    this.director?.setValue(undefined);
    this.country?.setValue(undefined);
    this.year?.setValue(undefined);
    this.rating?.setValue(undefined);
  }
}
