import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ICreateMovie } from '../../interfaces/create-movie.interface';
import { MoviesService } from '../../services/movies.service';
import { ValidateString } from '../../validators/string.validator';

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

  constructor(
    private _moviesService: MoviesService,
    private _router: Router,
  ) { }

  public get name() { return this.movieForm.get('name'); }

  public get category() { return this.movieForm.get('category'); }

  public get director() { return this.movieForm.get('director'); }

  public get country() { return this.movieForm.get('country'); }

  public get year() { return this.movieForm.get('year'); }

  public get rating() { return this.movieForm.get('rating'); }

  public ngOnInit(): void {
  }

  public createMovie(): void {
    console.log(this.movieForm);
    console.log({valid: this.movieForm.valid});
    if(this.movieForm.valid) {
      const movie: ICreateMovie = {
        name: this.movieForm.value.name,
        category: this.movieForm.value.category,
        director: this.movieForm.value.director,
        country: this.movieForm.value.country,
        year: this.movieForm.value.year,
        rating: this.movieForm.value.rating,
      };
      console.log({movie});
      const movieId = this._moviesService.postMovie(movie);
      console.log({movieId});
      if(!!movieId) {
        alert('Película creada!!');
        this._router.navigateByUrl('/movies');
      }
    }
  }
}
