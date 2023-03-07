import { Injectable } from '@angular/core';
import { ICreateMovie } from '../interfaces/create-movie.interface';
import { Movie } from '../models/movie';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  private _movies: Movie[] | undefined;
  constructor() { 
    this._movies = this.initializeMovies();
  }

  public getMovies(): Movie[] {
    return this._movies ?? [];
  }

  public getMovieById(id: number): Movie | undefined {
    return this._movies?.find((movie) => movie.id.toString() === id?.toString());
  }

  public postMovie(movieToAddDto: ICreateMovie): number {
    if(!this._movies) this._movies = [];
    const max = Math.max(...this._movies.map(movie => movie?.id));
    const id = max + 1;
    const movieToAdd = new Movie(id, movieToAddDto.name, movieToAddDto.category,
      movieToAddDto.director, movieToAddDto.country, movieToAddDto.year, movieToAddDto.rating);
    this._movies.push(movieToAdd);
    return id;
  }

  public putMovie(movieToUpdate: Movie): Movie | undefined {
    this._movies = this._movies?.map(movie => {
      if(movie.id === movieToUpdate.id) {
        return {
          ...movie,
          name: movieToUpdate.name,
          category: movieToUpdate.category,
          director: movieToUpdate.director,
          country: movieToUpdate.country,
          year: movieToUpdate.year,
          rating: movieToUpdate.rating,
        };
      }
      return movie;
    });
    return this._movies?.find((movie) => movie.id === movieToUpdate.id);
  }

  public deleteMovie(movieId: number): boolean {
    const movie = this._movies?.find(movie => movie.id === movieId);
    if(!!movie) {
      this._movies = this._movies?.filter(movie => movie.id !== movieId);
      return true;
    }
    return false;
  }

  private initializeMovies(): Movie[] {
    return [
      new Movie(1, "La Era de Hielo", "Animada", "Chris Wedge y Carlos Saldanha", "Estados Unidos", 2002, 5),
      new Movie(2, "El Aro", "Terror", "Gore Verbinski", "Estados Unidos", 2002, 4),
      new Movie(3, "Rápido y Furioso", "Acción", "Rob Cohen", "Estados Unidos", 2001, 3),
      new Movie(4, "Joker", "Suspenso", "Todd Phillips", "Estados Unidos", 2019, 4),
      new Movie(5, "Bajocero", "Suspenso", "Lluís Quílez", "España", 2021, 2),
    ];
  }
}
