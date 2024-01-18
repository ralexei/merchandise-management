import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


export const AppModuleRouting: Routes = [
  {
    path: '',
    redirectTo: 'products',
    pathMatch: 'full'
  },
  {
    path: 'products',
    loadChildren: () => import('./ui/products/products-page.module')
      .then(t => t.ProductsPageModule)
  },
  {
    path: 'auth',
    loadChildren: () => import('./ui/auth/auth.module')
      .then(t => t.AuthModule)
  },
  {
    path: 'warehouses',
    loadChildren: () => import('./ui/warehouses/warehouses.module')
      .then(t => t.WarehousesModule)
  },
  {
    path: 'stores',
    loadChildren: () => import('./ui/stores/stores.module')
      .then(t => t.StoresModule)
  },
  {
    path: '404',
    loadChildren: () => import('./ui/not-found/not-found.module')
      .then(t => t.NotFoundModule)
  },
  {
    path: '**',
    redirectTo: '404'
  }
];

