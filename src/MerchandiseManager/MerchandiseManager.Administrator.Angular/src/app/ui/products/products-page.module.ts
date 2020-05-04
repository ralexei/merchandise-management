import { NgModule } from '@angular/core';
import { ProductsPageComponent } from './pages/products-page/products-page.component';
import { RouterModule } from '@angular/router';
import { ProductsPageRouting } from './products-page.routing';
import { SharedModule } from '@app/shared/shared.module';
import { CreateProductDialogComponent } from './components/create-product-dialog/create-product-dialog.component';
import { CategoriesTreeComponent } from './components/categories-tree/categories-tree.component';
import { AddBarcodeDialogComponent } from './components/add-barcode-dialog/add-barcode-dialog.component';
import { PrintBarcodeDialogComponent } from './components/print-barcode-dialog/print-barcode-dialog.component';
import { EditProductDialogComponent } from './components/edit-product-dialog/edit-product-dialog.component';

@NgModule({
  declarations: [
    ProductsPageComponent,
    CreateProductDialogComponent,
    CategoriesTreeComponent,
    AddBarcodeDialogComponent,
    PrintBarcodeDialogComponent,
    EditProductDialogComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(ProductsPageRouting)
  ],
  entryComponents: [
    CreateProductDialogComponent,
    AddBarcodeDialogComponent,
    PrintBarcodeDialogComponent
  ]
})
export class ProductsPageModule { }
