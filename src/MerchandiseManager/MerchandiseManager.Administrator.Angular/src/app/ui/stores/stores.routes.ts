import { Routes } from '@angular/router';
import { AuthGuard } from '@app/core';
import { SalesReportsComponent } from './pages/sales-reports/sales-reports.component';
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
  },
  {
    path: ':id/sales-reports',
    canActivate: [AuthGuard],
    component: SalesReportsComponent
  }
];
