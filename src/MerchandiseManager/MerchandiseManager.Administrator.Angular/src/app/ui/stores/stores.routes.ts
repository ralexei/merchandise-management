import { Routes } from '@angular/router';
import { AuthGuard } from '@app/core';
import { StoreDetailsComponent } from './pages/store-details/store-details.component';
import { StoresListComponent } from './pages/stores-list/stores-list.component';

export const StoresModuleRoutes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    canActivate: [AuthGuard],
    component: StoresListComponent
  },
  {
    path: ':id',
    canActivate: [AuthGuard],
    component: StoreDetailsComponent
  }
];
