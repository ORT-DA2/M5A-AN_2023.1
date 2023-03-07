import { Pipe, PipeTransform } from '@angular/core';
import { Product } from 'src/models/product';

@Pipe({
  name: 'filter',
  pure: false
})
export class FilterPipe implements PipeTransform {
  transform(list: Array<Product>, filter: string, msg: string): Array<Product> {
    return list.filter((p) =>
      p.name.toLowerCase().includes(filter.toLowerCase())
    );
  }
}
