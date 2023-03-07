import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HomeworksService } from '../services/homeworks.service';

@Injectable({
  providedIn: 'root'
})
export class HolaGuard implements CanActivate {

  constructor(private _homeworks: HomeworksService) {

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this._homeworks.get(route.params['id'])
      .pipe(map(x => x != null));
  }
}
