import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthService } from '../api';

@Injectable()
export class AuthorizationInterceptor implements HttpInterceptor {

  constructor(
    private router: Router,
    private authService: AuthService
  ) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    req = this.addAuthenticationToken(req);
    return next.handle(req).pipe(
      catchError((error: any) => {
        if (error instanceof HttpErrorResponse && error.status === 401) {
          return this.handle401();
        } else {
          return throwError(error);
        }
      })
    );
  }

  handle401(): Observable<HttpEvent<any>> {
    this.authService.clearLocalStorage();
    this.router.navigateByUrl('/authentication');

    return;
  }

  addAuthenticationToken(request: HttpRequest<any>) {
    const token = localStorage.getItem('access-token');

    return request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
  }
}
