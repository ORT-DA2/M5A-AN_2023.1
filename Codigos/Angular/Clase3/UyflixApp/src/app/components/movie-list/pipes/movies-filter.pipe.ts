import { Pipe, PipeTransform } from '@angular/core';  // 1) imports
import { Movie } from '../../../models/movie';

// 2) Nos creamos nuestra propia clase MoviesFilterPipe y la decoramos con el decorator @Pipe
@Pipe({
  name: 'moviesFilter'
})
export class MoviesFilterPipe implements PipeTransform { // 3) Implementamos la interfaz PipeTransform

  // 4) Implementamos el método transform de la interfaz PipeTransform
  transform(movies: Movie[] | undefined, filterValue: string): Movie[] {
    // 5) Escribimos el código para filtrar las películas
    // El primer parámetro (movies) es la lista de películas que vamos a transformar
    // El segundo parámetro (filterValue) es el criterio que vamos a utilizar para transformar
    // en este caso vamos a estar filtrando las películas por ese filterValue
    // El retorno es la lista de películas filtradas por filterValue
    if(!movies) {
      return [];
    }
    return movies.filter((movie) => movie.name.toLowerCase().includes(filterValue.toLowerCase()));
  }
}
