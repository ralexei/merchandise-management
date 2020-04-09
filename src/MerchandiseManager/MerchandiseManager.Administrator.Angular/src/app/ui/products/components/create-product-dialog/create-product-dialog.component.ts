import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { FilteredResult, Category, SnackBarService, ProductsService, Product } from '@app/core';
import { CategoryService } from '@app/core/services/api/category.service';
import { Observable, Subject } from 'rxjs';
import { AddBarcodeDialogComponent } from '../add-barcode-dialog/add-barcode-dialog.component';
import { PrintBarcodeDialogComponent } from '../print-barcode-dialog/print-barcode-dialog.component';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-create-product-dialog',
  templateUrl: './create-product-dialog.component.html',
  styleUrls: ['./create-product-dialog.component.scss']
})
export class CreateProductDialogComponent implements OnInit, OnDestroy {

  public categories$: Observable<FilteredResult<Category>>;
  public createProductForm: FormGroup;
  public barcodes: string[] = [];

  public loading = false;

  private ngDestroy$: Subject<void> = new Subject<void>();

  constructor(
    private dialogRef: MatDialogRef<CreateProductDialogComponent>,
    private productsService: ProductsService,
    private snackBarService: SnackBarService,
    private dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.createProductForm = new FormGroup({
      productName: new FormControl('', [Validators.required, Validators.maxLength(128)]),
      productDescription: new FormControl(''),
      retailSellPrice: new FormControl(''),
      wholesaleSellPrice: new FormControl(''),
      buyPrice: new FormControl(''),
      categoryId: new FormControl('', Validators.required)
    });
  }

  public onClose(): void {
    this.dialogRef.close();
  }

  public onSubmit(): void {
    if (this.createProductForm.valid) {

      const request = this.createProductForm.getRawValue() as Product;

      request.barcodes = this.barcodes;

      this.loading = true;
      this.productsService.create(request)
      .pipe(takeUntil(this.ngDestroy$))
      .subscribe(
        (createdProduct: Product) => {
          this.snackBarService.openSuccess('Товар успешно добавлен!');
          this.loading = true;
          this.dialogRef.close(createdProduct);
        },
        (err: any) => {
          this.snackBarService.openError('Ошибка при добавлении товара');
          this.loading = false;
        }
      );
    }
  }

  public categorySelected(category: Category): void {
    this.createProductForm.get('categoryId').setValue(category.id);
  }

  public addBarcode(): void {
    this.dialog.open(AddBarcodeDialogComponent)
      .afterClosed()
      .pipe(takeUntil(this.ngDestroy$))
      .subscribe(
        (barcode: string) => {
          if (barcode) {
            this.barcodes.push(barcode);
          }
        }
      );
  }

  public viewBarcode(barcode: string): void {
    this.dialog.open(PrintBarcodeDialogComponent, { data: barcode })
    .afterClosed()
    .pipe(takeUntil(this.ngDestroy$))
    .subscribe(
      (data) => {
        if (data) {
          const barcodeIndex = this.barcodes.indexOf(barcode);

          if (barcodeIndex !== -1) {
            this.barcodes.splice(barcodeIndex, 1);
          }
        }
      }
    );
  }

  ngOnDestroy(): void {
    this.ngDestroy$.next();
  }
}
