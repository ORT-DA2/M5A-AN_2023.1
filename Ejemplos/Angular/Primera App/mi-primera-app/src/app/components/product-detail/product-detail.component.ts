import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../../../models/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css'],
})
export class ProductDetailComponent implements OnInit {
  constructor(
    private currentRoute: ActivatedRoute,
    private productService: ProductService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.currentRoute.snapshot.params.id;
    this.productService.getProduct(id).subscribe(
      (res) => {
        this.product = res as Product;
      },
      (err) => {
        alert('Algo salió mal...');
      }
    );
  }

  product: Product;

  back() {
    this.router.navigateByUrl('/');
  }
}
