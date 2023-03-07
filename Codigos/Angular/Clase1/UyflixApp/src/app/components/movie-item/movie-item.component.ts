import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Movie } from '../../models/movie';

@Component({
  selector: 'app-movie-item',
  templateUrl: './movie-item.component.html',
  styleUrls: ['./movie-item.component.css']
})
export class MovieItemComponent implements OnInit {

  @Input() public movie: Movie | undefined;
  @Output() public delete: EventEmitter<Movie> = new EventEmitter<Movie>();
  constructor() { }

  public ngOnInit(): void {
  }

  public onDelete(): void {
    this.delete.emit(this.movie);
  }
}
