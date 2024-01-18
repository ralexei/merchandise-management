import { Routes } from '@angular/router';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { NotAuthenticatedGuard } from '@app/core';

export const AuthModuleRoutes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    canActivate: [NotAuthenticatedGuard],
    component: LoginPageComponent
  }
];
