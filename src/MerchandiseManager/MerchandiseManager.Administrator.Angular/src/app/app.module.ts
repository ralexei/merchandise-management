import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/shared.module';
import { RouterModule } from '@angular/router';
import { AppModuleRouting } from './app-routing.module';
import { CoreModule } from './core/core.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { WarehouseDetailsComponent } from './ui/warehouses/pages/warehouse-details/warehouse-details.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    NoopAnimationsModule,
    SharedModule,
    CoreModule,
    RouterModule.forRoot(AppModuleRouting)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
