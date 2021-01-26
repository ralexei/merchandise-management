import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedMaterialModule } from './shared-material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { ConfirmationDialogComponent } from './components/confirmation-dialog/confirmation-dialog.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NewStorageDialogComponent } from './components/new-storage-dialog/new-storage-dialog.component';
import { StorageProductsListComponent } from './components/storage-products-list/storage-products-list.component';

@NgModule({
  declarations: [
    ConfirmationDialogComponent,
    NewStorageDialogComponent,
    StorageProductsListComponent
  ],
  imports: [
    CommonModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    SharedMaterialModule,
    FontAwesomeModule
  ],
  exports: [
    CommonModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    SharedMaterialModule,
    FontAwesomeModule,
    StorageProductsListComponent
  ]
})
export class SharedModule { }
