import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Movie } from '../../models/movie';

@Component({
  selector: 'app-movie-item',
  templateUrl: './movie-item.component.html',
  styleUrls: ['./movie-item.component.scss']
})
export class MovieItemComponent {
  @Input() public movie: Movie | undefined;
  @Output() public delete: EventEmitter<Movie> = new EventEmitter<Movie>();

  public onDelete(): void {
    this.delete.emit(this.movie);
  }
}
