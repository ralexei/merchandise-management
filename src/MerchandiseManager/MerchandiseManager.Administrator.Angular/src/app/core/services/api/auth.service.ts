import { Injectable } from '@angular/core';
import { ApiService } from '../utils';
import { LoginRequest, LoginResult } from '@app/core/models';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private jwtHelper: JwtHelperService,
    private apiService: ApiService) {

  }

  public login(user: LoginRequest): Observable<LoginResult> {
    return this.apiService.post<LoginResult>('/api/auth', user).pipe(
      tap((loginResult: LoginResult) => {
        this.setTokens(loginResult);
      })
    );
  }

  public clearLocalStorage(): void {
    localStorage.removeItem('access-token');
  }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('access-token');
    return token !== null && !this.jwtHelper.isTokenExpired(token);
  }

  private setTokens(tokens: LoginResult): void {
    localStorage.setItem('access-token', tokens.accessToken);
  }

  private getAccessToken(): string {
    return localStorage.getItem('access-token');
  }
}
