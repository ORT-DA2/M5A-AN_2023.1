import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { ValidateString } from '../../validators/string.validator';
import { ICreateMovie } from '../../interfaces/create-movie.interface';
import { MoviesService } from '../../services/movies.service';

@Component({
  selector: 'app-movie-form',
  templateUrl: './movie-form.component.html',
  styleUrls: ['./movie-form.component.scss']
})
export class MovieFormComponent {
  public actualYear = new Date().getFullYear();

  public movieForm = new FormGroup({
      name: new FormControl<string | undefined>(undefined, [Validators.required, ValidateString]),
      category: new FormControl<string | undefined>(undefined, [Validators.required, ValidateString]),
      director: new FormControl<string | undefined>(undefined, [Validators.required, ValidateString]),
      country: new FormControl<string | undefined>(undefined, [Validators.required, ValidateString]),
      year: new FormControl<number | undefined>(undefined, [Validators.required, Validators.min(1970), Validators.max(this.actualYear)]),
      rating: new FormControl<number | undefined>(undefined, [Validators.required, Validators.min(1), Validators.max(5)]),
  });

  constructor(
    private _location: Location,
    private _moviesService: MoviesService,
  ) { }

  public get name() { return this.movieForm.get('name'); }

  public get category() { return this.movieForm.get('category'); }

  public get director() { return this.movieForm.get('director'); }

  public get country() { return this.movieForm.get('country'); }

  public get year() { return this.movieForm.get('year'); }

  public get rating() { return this.movieForm.get('rating'); }

  public createMovie(): void {
    if(this.movieForm.valid) {
      const movie: ICreateMovie = {
        name: this.movieForm.value.name as string,
        category: this.movieForm.value.category as string,
        director: this.movieForm.value.director as string,
        country: this.movieForm.value.country as string,
        year: this.movieForm.value.year as number,
        rating: this.movieForm.value.rating as number,
      };
      const movieId = this._moviesService.postMovie(movie);
      if(!!movieId) {
        alert('Película creada!!');
        this._location.back();
      }
    }
  }
}
