import { Component, OnInit, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { FilteredResult, Category, SnackBarService, ProductsService, Product, PrintRequest, CategoryFlat } from '@app/core';
import { Observable, Subject } from 'rxjs';
import { AddBarcodeDialogComponent } from '../add-barcode-dialog/add-barcode-dialog.component';
import { PrintBarcodeDialogComponent } from '../print-barcode-dialog/print-barcode-dialog.component';
import { takeUntil } from 'rxjs/operators';
import { CategoryService } from '@app/core/services/api/category.service';

@Component({
  selector: 'app-create-product-dialog',
  templateUrl: './create-product-dialog.component.html',
  styleUrls: ['./create-product-dialog.component.scss']
})
export class CreateProductDialogComponent implements OnInit, OnDestroy {

  public categoryListFilter: FormControl = new FormControl('');
  public newCategoryControl: FormControl = new FormControl('', Validators.required);

  public filteredFlattenedCategories: CategoryFlat[];
  public flattenedCategories: FilteredResult<CategoryFlat>;

  public createProductForm: FormGroup;
  public barcodes: string[] = [];

  public loading = false;
  public isNewCategoryInputVisible = false;

  private ngDestroy$: Subject<void> = new Subject<void>();

  constructor(
    private dialogRef: MatDialogRef<CreateProductDialogComponent>,
    private categoriesService: CategoryService,
    private productsService: ProductsService,
    private snackBarService: SnackBarService,
    private changeDetectorRef: ChangeDetectorRef,
    private dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.createProductForm = new FormGroup({
      productName: new FormControl('', [Validators.required, Validators.maxLength(128)]),
      productDescription: new FormControl(''),
      retailSellPrice: new FormControl(''),
      wholesaleSellPrice: new FormControl(''),
      buyPrice: new FormControl(''),
      categoryId: new FormControl('', [Validators.required])
    });

    this.categoryListFilter.valueChanges
      .pipe(takeUntil(this.ngDestroy$))
      .subscribe((term: string) => {
        this.filterCategories(term);
      });

    this.fetchFlattenedCategories();
  }

  public onClose(): void {
    this.dialogRef.close();
  }

  public onSubmit(): void {
    this.createProductForm.markAllAsTouched();
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

  public cancelCategoryCreation(): void {
    this.isNewCategoryInputVisible = false;
  }

  public showNewCategoryInput(): void {
    this.isNewCategoryInputVisible = true;
  }

  public saveNewCategory(): void {
    if (this.newCategoryControl.valid) {

      this.loading = true;
      const newCategory = new Category(this.newCategoryControl.value, this.createProductForm.get('categoryId').value);

      this.categoriesService.create(newCategory)
        .pipe(takeUntil(this.ngDestroy$))
        .subscribe(
          (createdCategory: Category) => {
            this.fetchFlattenedCategories();
            this.loading = false;
            this.isNewCategoryInputVisible = false;
            this.createProductForm.get('categoryId').setValue(createdCategory.id);
            this.snackBarService.openSuccess('Группа успешно добавлена!');
          },
          (err: any) => {
            this.loading = false;
            this.snackBarService.openError('Не удалось добавить новую группу');
          }
        );
    }
  }

  public viewBarcode(product: Product, barcode: string): void {
    this.dialog.open(PrintBarcodeDialogComponent, { data: { product, barcode } })
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

  public getProductInfo(): Product {
    return this.createProductForm.getRawValue() as Product;
  }

  public getCategoryNestingPadding(nestingLevel: number): any {
    return nestingLevel * 16;
  }

  public getCurrentCategoryName(): any {
    return this.flattenedCategories.data.find(f => f.id === this.createProductForm.get('categoryId').value).name;
  }

  private fetchFlattenedCategories(): void {
    this.categoriesService.getAllFlattened()
      .pipe(takeUntil(this.ngDestroy$))
      .subscribe(
        (categories: FilteredResult<CategoryFlat>) => {
          this.flattenedCategories = categories;
          this.filteredFlattenedCategories = this.flattenedCategories.data;
        },
        (err: any) => {

        }
      );
  }

  private filterCategories(term: string): any {
    if (!this.flattenedCategories.data) {
      return;
    }

    if (!term) {
      this.filteredFlattenedCategories = this.flattenedCategories.data;

      return;
    }

    this.filteredFlattenedCategories = this.flattenedCategories.data.filter(f => f.name.toLowerCase().indexOf(term.toLowerCase()) > -1);
    this.changeDetectorRef.detectChanges();
  }

  ngOnDestroy(): void {
    this.ngDestroy$.next();
  }
}
