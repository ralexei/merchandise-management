import { Component, OnInit, Input, ChangeDetectorRef, OnDestroy, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Product, ProductsService, SnackBarService, CategoryFlat, FilteredResult, Category, Barcode } from '@app/core';
import { MatDialogRef, MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CategoryService } from '@app/core/services/api/category.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { AddBarcodeDialogComponent } from '../add-barcode-dialog/add-barcode-dialog.component';
import { PrintBarcodeDialogComponent } from '../print-barcode-dialog/print-barcode-dialog.component';

@Component({
  selector: 'app-edit-product-dialog',
  templateUrl: './edit-product-dialog.component.html',
  styleUrls: ['./edit-product-dialog.component.scss']
})
export class EditProductDialogComponent implements OnInit, OnDestroy {

  public editProductForm: FormGroup;

  public categoryListFilter: FormControl = new FormControl('');
  public newCategoryControl: FormControl = new FormControl('', Validators.required);

  public filteredFlattenedCategories: CategoryFlat[];
  public flattenedCategories: FilteredResult<CategoryFlat>;

  public barcodes: Barcode[] = [];

  private ngDestroy$: Subject<void> = new Subject<void>();

  public loading = false;
  public isNewCategoryInputVisible = false;

  constructor(
    private dialogRef: MatDialogRef<EditProductDialogComponent>,
    private categoriesService: CategoryService,
    private productsService: ProductsService,
    private snackBarService: SnackBarService,
    private changeDetectorRef: ChangeDetectorRef,
    private dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) public product: Product) {
  }

  ngOnInit(): void {
    this.initFormGroup();
    this.subscribeToCategorySearchInput();
    this.fetchFlattenedCategories();
  }

  public onClose(): void {
    this.dialogRef.close();
  }

  public onSubmit(): void {
    this.editProductForm.markAllAsTouched();
    if (this.editProductForm.valid) {
      const request = this.editProductForm.getRawValue() as Product;

      request.barcodes = this.barcodes;
      this.loading = true;
      this.productsService.update(this.product.id, request)
        .pipe(takeUntil(this.ngDestroy$))
        .subscribe(
          () => {
            this.snackBarService.openSuccess('Товар успешно отредактирован!');
            this.loading = true;
            this.dialogRef.close(request);
          },
          (err: any) => {
            this.snackBarService.openError('Ошибка при редактировании товара');
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
            this.barcodes.push({
              rawCode: barcode
            } as Barcode);
          }
        }
      );
  }

  public viewBarcode(barcode: string): void {
    this.dialog.open(PrintBarcodeDialogComponent, { data: { product: this.product, barcode } })
    .afterClosed()
    .pipe(takeUntil(this.ngDestroy$))
    .subscribe(
      (data) => {
        if (data) {
          const barcodeIndex = this.barcodes.findIndex(f => f.rawCode == barcode);

          if (barcodeIndex !== -1) {
            this.barcodes.splice(barcodeIndex, 1);
          }
        }
      }
    );
  }

  public getCategoryNestingPadding(nestingLevel: number): any {
    return nestingLevel * 16;
  }

  public getCurrentCategoryName(): any {
    return this.flattenedCategories.data.find(f => f.id === this.editProductForm.get('categoryId').value).name;
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
      const newCategory = new Category(this.newCategoryControl.value, this.editProductForm.get('categoryId').value);

      this.categoriesService.create(newCategory)
        .pipe(takeUntil(this.ngDestroy$))
        .subscribe(
          (createdCategory: Category) => {
            this.fetchFlattenedCategories();
            this.loading = false;
            this.editProductForm.get('categoryId').setValue(createdCategory.id);
            this.isNewCategoryInputVisible = false;
            this.snackBarService.openSuccess('Группа успешно добавлена!');
          },
          (err: any) => {
            this.loading = false;
            this.snackBarService.openError('Не удалось добавить новую группу');
          }
        );
    }
  }

  private initFormGroup(): void {
    this.barcodes = this.product.barcodes;
    this.editProductForm = new FormGroup({
      productName: new FormControl(this.product.productName, [Validators.required, Validators.maxLength(128)]),
      productDescription: new FormControl(this.product.productDescription),
      retailSellPrice: new FormControl(this.product.retailSellPrice),
      wholesaleSellPrice: new FormControl(this.product.wholesaleSellPrice),
      buyPrice: new FormControl(this.product.buyPrice),
      categoryId: new FormControl(this.product.categoryId, [Validators.required])
    });
  }

  private subscribeToCategorySearchInput(): void {
    this.categoryListFilter.valueChanges
    .pipe(takeUntil(this.ngDestroy$))
    .subscribe((term: string) => {
      this.filterCategories(term);
    });
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
