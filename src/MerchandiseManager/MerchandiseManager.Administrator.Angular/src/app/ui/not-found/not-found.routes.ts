import { Routes } from '@angular/router';
import { NotFoundPageComponent } from './pages';

export const NotFoundRoutes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: NotFoundPageComponent
  }
];
