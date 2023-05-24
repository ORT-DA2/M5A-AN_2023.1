import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { ValidateString } from '../../validators/string.validator';
import { ICreateMovie } from '../../interfaces/create-movie.interface';
import { MoviesService } from '../../services/movies.service';
import { catchError, of, take } from 'rxjs';
import { Movie } from '../../models/movie';
import { ROUTE_ID_PARAM, SEGMENTS } from '../../utils/routes';

@Component({
  selector: 'app-movie-form',
  templateUrl: './movie-form.component.html',
  styleUrls: ['./movie-form.component.scss']
})
export class MovieFormComponent implements OnInit {
  public actualYear = new Date().getFullYear();

  public movieForm = new FormGroup({
      name: new FormControl<string | undefined>(undefined, [Validators.required, ValidateString]),
      category: new FormControl<string | undefined>(undefined, [Validators.required, ValidateString]),
      director: new FormControl<string | undefined>(undefined, [Validators.required, ValidateString]),
      country: new FormControl<string | undefined>(undefined, [Validators.required, ValidateString]),
      year: new FormControl<number | undefined>(undefined, [Validators.required, Validators.min(1970), Validators.max(this.actualYear)]),
      rating: new FormControl<number | undefined>(undefined, [Validators.required, Validators.min(1), Validators.max(5)]),
  });

  public isEditing = false;
  private movieId?: number;

  constructor(
    private _location: Location,
    private _moviesService: MoviesService,
    private _route: ActivatedRoute,
  ) { }

  public get name() { return this.movieForm.get('name'); }

  public get category() { return this.movieForm.get('category'); }

  public get director() { return this.movieForm.get('director'); }

  public get country() { return this.movieForm.get('country'); }

  public get year() { return this.movieForm.get('year'); }

  public get rating() { return this.movieForm.get('rating'); }

  public ngOnInit(): void {
    const id = this._route.snapshot.params?.[ROUTE_ID_PARAM];
    if(!!id && id !== SEGMENTS.NEW) {
      this.isEditing = true;
      this.movieId = id;
      this._moviesService.getMovieById(id).pipe(
        take(1),
        catchError((err: any) => {
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
    if(this.movieForm.valid) {
      const movie: ICreateMovie = {
        name: this.movieForm.value.name as string,
        category: this.movieForm.value.category as string,
        director: this.movieForm.value.director as string,
        country: this.movieForm.value.country as string,
        year: this.movieForm.value.year as number,
        rating: this.movieForm.value.rating as number,
      };
      this._moviesService.postMovie(movie)
      .pipe(
        take(1),
        catchError((err: any) => {
          console.log({err});
          return of(err);
        }),
      )
      .subscribe((movie: Movie) => {
        if(!!movie?.id) {
          alert('Película creada!!');
          this.cleanForm();
          this._location.back();
        }
      });
    }
  }

  private updateMovie(): void {
    if(!!this.movieId) {
      const movie = new Movie(
        this.movieId as number,
        this.movieForm.value.name as string,
        this.movieForm.value.category as string,
        this.movieForm.value.director as string,
        this.movieForm.value.country as string,
        this.movieForm.value.year as number,
        this.movieForm.value.rating as number,
      );
      this._moviesService.putMovie(movie)
      .pipe(
        take(1),
        catchError((err: any) => {
          console.log({err});
          return of(err);
        }),
      )
      .subscribe((movie: Movie) => {
        if(!!movie?.id) {
          alert('Película modificada!!');
          this._location.back();
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
