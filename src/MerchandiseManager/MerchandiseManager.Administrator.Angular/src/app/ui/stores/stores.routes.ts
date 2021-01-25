import { Routes } from '@angular/router';
import { AuthGuard } from '@app/core';

export const StoresModuleRoutes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    canActivate: [AuthGuard],
    component:
  },
  {
    path: ':id',
    canActivate: [AuthGuard],
    component:
  }
];
