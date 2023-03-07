import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from '@angular/router';
import { Observable } from 'rxjs';
import { BeersService } from '../services/beers.service';

@Injectable({
  providedIn: 'root',
})
export class BeerNotExistGuard implements CanActivate {
  constructor(private router: Router, private beersService: BeersService) {}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    let id = +route.url[1].path;
    if (isNaN(id) || id < 1) {
      alert('Ups no existe esta cerveza, esperemos que pronto la inventen...');
      this.router.navigate(['/beers']);
      return false;
    }
    return true;
  }
}
