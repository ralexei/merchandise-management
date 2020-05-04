import { NgModule } from '@angular/core';
import { WarehousesListComponent } from './pages/warehouses-list/warehouses-list.component';
import { RouterModule } from '@angular/router';
import { WarehousesModuleRoutes } from './warehouses.routes';
import { SharedModule } from '@app/shared/shared.module';



@NgModule({
  declarations: [WarehousesListComponent],
  imports: [
    SharedModule,
    RouterModule.forChild(WarehousesModuleRoutes)
  ]
})
export class WarehousesModule { }
