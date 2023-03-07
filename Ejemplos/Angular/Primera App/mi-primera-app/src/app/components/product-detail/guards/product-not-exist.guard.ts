import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from '@angular/router';
import { Observable } from 'rxjs';
import { ProductService } from '../../../services/product.service';

@Injectable({
  providedIn: 'root',
})
export class ProductNotExistGuard implements CanActivate {
  constructor(private productService: ProductService, private router: Router) { }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
      const id = route.params.id as number;
      if(isNaN(id) || !this.productService.existProduct(id)) {
        alert("No existe este producto");
        this.router.navigateByUrl("/");
        return false;
      }
    return true;
  }
}
