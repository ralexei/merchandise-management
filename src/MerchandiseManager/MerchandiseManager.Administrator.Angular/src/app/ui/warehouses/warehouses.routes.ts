import { Routes } from '@angular/router';
import { AuthGuard } from '@app/core';
import { WarehousesListComponent } from './pages/warehouses-list/warehouses-list.component';

export const WarehousesModuleRoutes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    canActivate: [AuthGuard],
    component: WarehousesListComponent
  }
];
