import { NgModule } from '@angular/core';
import { WarehousesListComponent } from './pages/warehouses-list/warehouses-list.component';
import { RouterModule } from '@angular/router';
import { WarehousesModuleRoutes } from './warehouses.routes';
import { SharedModule } from '@app/shared/shared.module';
import { WarehouseDetailsComponent } from './pages/warehouse-details/warehouse-details.component';
import { ReplenishDialogComponent } from './components/replenish-dialog/replenish-dialog.component';



@NgModule({
  declarations: [
    WarehousesListComponent,
    WarehouseDetailsComponent,
    ReplenishDialogComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(WarehousesModuleRoutes)
  ]
})
export class WarehousesModule { }
