import { Injectable } from '@angular/core';
import { Product } from '../../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductServicesService {

  constructor() {
    this.products = this.initializateProducts();
  }

  products: Product[];

  getProducts() {
    return this.products;
  }

  deleteProduct(product: Product) {
    const id =this.products.indexOf(product, 0);
    if(id === -1) alert("No existe producto")
    else this.products.splice(id, 1);
  }


  // generacion de datos
  initializateProducts(){
    let tv = new Product('Smart TV', 600);
    tv.id = 1;
    let notebook = new Product('Notebook', 1400);
    notebook.id = 2;
    let keyboard = new Product('Teclado mécanico', 250);
    keyboard.id = 3;

    return new Array<Product>(tv, notebook, keyboard);
  }
}
