import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Product } from '../../../models/product';

@Component({
  selector: 'app-product-row',
  templateUrl: './product-row.component.html',
  styleUrls: ['./product-row.component.css'],
})
export class ProductRowComponent {
  constructor() {}

  @Input() product: Product;

  @Output() delete = new EventEmitter<Product>();

  onDelete() {
    this.delete.emit(this.product);
  }
}
