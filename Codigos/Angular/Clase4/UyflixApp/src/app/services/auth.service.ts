import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _userTokenKey = 'userToken';
  private _userRoleKey = 'userRole';

  constructor() { }

  public getToken(): string | null {
    return sessionStorage.getItem(this._userTokenKey);
  }

  public setToken(token: string): void {
    sessionStorage.setItem(this._userTokenKey, token);
  }

  public removeToken(): void {
    sessionStorage.removeItem(this._userTokenKey);
  }

  public getUserRole(): string | null {
    return sessionStorage.getItem(this._userRoleKey);
  }

  public setUserRole(userRole: string): void {
    sessionStorage.setItem(this._userRoleKey, userRole);
  }

  public removeUserRole(): void {
    sessionStorage.removeItem(this._userRoleKey);
  }

  public isAuthenticated(): boolean {
    const token = this.getToken();
    if(!token) {
      return false;
    }
    return true;
  }

  public isAuthorized(role: string): boolean {
    const userRole = this.getUserRole();
    if(!userRole || userRole?.toLowerCase() !== role?.toLowerCase()) {
      return false;
    }
    return true;
  }
}
