import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedMaterialModule } from './shared-material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { ConfirmationDialogComponent } from './components/confirmation-dialog/confirmation-dialog.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [
    ConfirmationDialogComponent
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
    FontAwesomeModule
  ]
})
export class SharedModule { }
