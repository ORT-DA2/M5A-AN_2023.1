import { Pipe, PipeTransform } from '@angular/core';
import { Product } from 'src/models/product';

@Pipe({
  name: 'filterProducts',
  pure: false
})
export class FilterProductsPipe implements PipeTransform {

  transform(list: Array<Product>, filter: string): Array<Product> {
    return list.filter((p) =>
      p.name.toLowerCase().includes(filter.toLowerCase())
    );
  }

}
