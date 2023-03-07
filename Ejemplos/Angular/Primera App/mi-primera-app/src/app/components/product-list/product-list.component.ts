import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../../models/product';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
  constructor(private productService: ProductService, private router: Router) {
    this.filterValue = '';
  }

  ngOnInit(): void {

    this.productService.getProducts().subscribe(
      (res) => {
        this.products = res;
      },
      (err) => {
        console.log(err);
        alert('Algo salió mal...');
      }
    );
  }

  products;
  filterValue: string = '';

  deleteProduct(product: Product) {
    this.productService.deleteProduct(product).subscribe(
      (res) => {},
      (err) => {
        alert('Algo salió mal...');
      }
    );
  }

  onProductClick(product: Product) {
    this.router.navigate(['/product', product.id]);
  }

  addProduct() {
    this.router.navigateByUrl('/product/add');
  }
}
