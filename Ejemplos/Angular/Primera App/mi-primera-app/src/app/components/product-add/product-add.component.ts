import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Product } from '../../../models/product';
import { ProductService } from '../../services/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css'],
})
export class ProductAddComponent {
  constructor(private productService: ProductService, private router: Router) {}

  productForm = new FormGroup({
    name: new FormControl(''),
    cost: new FormControl(0),
  });

  createProduct() {
    const product = new Product(
      this.productForm.value.name,
      this.productForm.value.cost as number
    );
    this.productService.postProduct(product).subscribe(
      (res) => {
        this.router.navigateByUrl('');
      },
      (err) => {
        alert('Algo salió mal...');
      }
    );
  }
}
