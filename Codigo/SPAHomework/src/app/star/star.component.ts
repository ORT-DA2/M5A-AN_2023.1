import { Component, OnChanges, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-star',
  templateUrl: './star.component.html',
  styleUrls: ['./star.component.scss']
})
export class StarComponent implements OnChanges {
    
  @Input() public rating: number;
  @Output() public ratingClicked: EventEmitter<string> = new EventEmitter<string>();
  starWidth: number = this.setWidth();

  constructor() { 
    this.rating = 5;
  }

  ngOnChanges() :void {
      console.log("OnChanges!");
      console.log(this.rating);
      this.setWidth();
  }

  private setWidth(): number {
    return this.starWidth = this.rating * 100 / 5;
  }

  onClick(): void {
      this.ratingClicked.emit(`El puntaje ${this.rating} fue clickeado!`);
  }
}