import { Routes } from '@angular/router';
import { ProductsPageComponent } from './pages/products-page/products-page.component';

export const ProductsPageRouting: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: ProductsPageComponent
  }
];
