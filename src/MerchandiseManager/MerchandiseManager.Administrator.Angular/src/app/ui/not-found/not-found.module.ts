import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { NotFoundPageComponent } from './pages';
import { NotFoundRoutes } from './not-found.routes';
import { SharedModule } from '@app/shared/shared.module';

@NgModule({
  declarations: [NotFoundPageComponent],
  imports: [
    SharedModule,
    RouterModule.forChild(NotFoundRoutes)
  ]
})
export class NotFoundModule { }
