import { Routes } from '@angular/router';
import { ProductsPageComponent } from './pages/products-page/products-page.component';
import { AuthGuard } from '@app/core';

export const ProductsPageRouting: Routes = [
  {
    path: '',
    pathMatch: 'full',
    canActivate: [AuthGuard],
    component: ProductsPageComponent
  }
];
