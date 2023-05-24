import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { EXPECTED_ROLE_KEY } from '../utils/auth.constants';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {
  constructor(
    private _authService: AuthService,
    private _router: Router,
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const expectedRole = route.data[EXPECTED_ROLE_KEY];
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
