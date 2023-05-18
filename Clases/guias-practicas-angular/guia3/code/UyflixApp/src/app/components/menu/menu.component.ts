import { Component } from '@angular/core';
import { ADD_MOVIE_URL, MOVIE_LIST_URL } from '../../utils/routes';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent {
  public movieListUrl = `/${MOVIE_LIST_URL}`;
  public addMovieUrl = `/${ADD_MOVIE_URL}`;
}
