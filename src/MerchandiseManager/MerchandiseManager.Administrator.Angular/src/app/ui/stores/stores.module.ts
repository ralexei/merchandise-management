import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@app/shared/shared.module';
import { StoresListComponent } from './pages/stores-list/stores-list.component';
import { StoresModuleRoutes } from './stores.routes';
import { StoreDetailsComponent } from './pages/store-details/store-details.component';
import { SalesReportsComponent } from './pages/sales-reports/sales-reports.component';

@NgModule({
  declarations: [
    StoresListComponent,
    StoreDetailsComponent,
    SalesReportsComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(StoresModuleRoutes)
  ]
})
export class StoresModule { }
