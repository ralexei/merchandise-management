import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot
} from '@angular/router';

import { AuthService } from '../api';

@Injectable({
  providedIn: 'root'
})
export class NotAuthenticatedGuard implements CanActivate {

  constructor(private router: Router, private authenticationService: AuthService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this.authenticationService.isAuthenticated()) {
      this.router.navigate(['/'], { queryParams: { returnUrl: state.url } });
      return false;
    } else {
      return true;
    }
  }
}
