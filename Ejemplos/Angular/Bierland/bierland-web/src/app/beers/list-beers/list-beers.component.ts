import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Beer } from '../../../Models/Beer';
import { BeersService } from '../services/beers.service';

@Component({
  selector: 'app-list-beers',
  templateUrl: './list-beers.component.html',
  styleUrls: ['./list-beers.component.css'],
})
export class ListBeersComponent implements OnInit {
  beers;
  Arr = Array;
  constructor(private beersService: BeersService, private router: Router) {
    this.beers = new Array();
  }

  ngOnInit(): void{
    this.beersService.getBeers().subscribe(
      res => {
        this.beers = res;
      },
      err => {
        alert('Ups algo salió mal...');
        console.log(err);
      }
    );
  }

  getDetail(id: number): void {
    this.router.navigate(['/detail-beer', id]);
  }
}
