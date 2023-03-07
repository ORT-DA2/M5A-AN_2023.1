import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Beer } from 'src/Models/Beer';
import { BeersService } from '../services/beers.service';

@Component({
  selector: 'app-detail-beer',
  templateUrl: './detail-beer.component.html',
  styleUrls: ['./detail-beer.component.css'],
})
export class DetailBeerComponent implements OnInit {
  beer: Beer;
  constructor(
    private beersService: BeersService,
    private currentRoute: ActivatedRoute
  ) {
    this.beer = null;
  }

  ngOnInit(): void {
    const id = +this.currentRoute.snapshot.params.id;
    this.beersService.getBeerById(id).subscribe(
      res => {
        this.beer = res;
      },
      err => {
        alert('Ups algo salió mal...');
        console.log(err);
      }
    );
  }
}
