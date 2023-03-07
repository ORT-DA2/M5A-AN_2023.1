import { Component, OnInit } from '@angular/core';
import { ADD_MOVIE_URL, MOVIE_LIST_URL } from '../../utils/routes';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  public movieListUrl = `/${MOVIE_LIST_URL}`;
  public addMovieUrl = `/${ADD_MOVIE_URL}`;

  constructor() { }

  ngOnInit(): void {
  }

}
