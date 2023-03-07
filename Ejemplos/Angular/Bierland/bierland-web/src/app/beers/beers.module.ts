import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListBeersComponent } from './list-beers/list-beers.component';
import { DetailBeerComponent } from './detail-beer/detail-beer.component';
import { BeerNotExistGuard } from './guards/beer-not-exist.guard';

@NgModule({
  declarations: [ListBeersComponent, DetailBeerComponent],
  imports: [
    CommonModule
  ],
  exports: [DetailBeerComponent, ListBeersComponent],
  providers: []
})
export class BeersModule { }
