import { Injectable } from '@angular/core';
import { USER_ROLE_KEY, USER_TOKEN_KEY } from '../utils/auth.constants';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  public getToken(): string | null {
    return sessionStorage.getItem(USER_TOKEN_KEY);
  }

  public setToken(token: string): void {
    sessionStorage.setItem(USER_TOKEN_KEY, token);
  }

  public removeToken(): void {
    sessionStorage.removeItem(USER_TOKEN_KEY);
  }

  public getUserRole(): string | null {
    return sessionStorage.getItem(USER_ROLE_KEY);
  }

  public setUserRole(userRole: string): void {
    sessionStorage.setItem(USER_ROLE_KEY, userRole);
  }

  public removeUserRole(): void {
    sessionStorage.removeItem(USER_ROLE_KEY);
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
