import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {
  constructor(
    private _authService: AuthService,
    private _router: Router,
  ) {}

  canActivate(route: ActivatedRouteSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const expectedRole = route.data['expectedRole'];
    if (!this._authService.isAuthenticated()) {
      this._router.navigateByUrl(''); // deberían redireccionar al login
      return false;
    }
    if (!this._authService.isAuthorized(expectedRole)) {
      this._router.navigateByUrl('');
      return false;
    }
    return true;
  }
}
