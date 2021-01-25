import { Routes } from '@angular/router';
import { AuthGuard } from '@app/core';
import { WarehouseDetailsComponent } from './pages/warehouse-details/warehouse-details.component';
import { WarehousesListComponent } from './pages/warehouses-list/warehouses-list.component';

export const WarehousesModuleRoutes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    canActivate: [AuthGuard],
    component: WarehousesListComponent
  },
  {
    path: ':id',
    canActivate: [AuthGuard],
    component: WarehouseDetailsComponent
  }
];
