import { Component, OnInit, ChangeDetectorRef, ViewChild, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { CategoryFlat, FilteredResult, StorageProduct, StorageProductsService, SnackBarService, ProductsSearchModel } from '@app/core';
import { CategoryService } from '@app/core/services/api/category.service';
import { Observable, Subject } from 'rxjs';
import { takeUntil, share, tap } from 'rxjs/operators';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-storage-products-list',
  templateUrl: './storage-products-list.component.html',
  styleUrls: ['./storage-products-list.component.scss']
})
export class StorageProductsListComponent implements OnInit {

  @Input()
  public storageId: string;

  @ViewChild(MatPaginator)
  public paginator: MatPaginator;

  public headerSearchFormGroup: FormGroup;

  public categorySelect: FormControl = new FormControl('');
  public categoryListFilter: FormControl = new FormControl('');
  public onlyOutOfStockControl: FormControl = new FormControl();

  public filteredFlattenedCategories: CategoryFlat[];
  public flattenedCategories: FilteredResult<CategoryFlat>;
  public products$: Observable<FilteredResult<StorageProduct>>;

  public loading = true;

  public ngDestroy$: Subject<void> = new Subject<void>();

  public displayedColumns = [
    'actions',
    'productName',
    'retailSellPrice',
    'wholesaleSellPrice',
    'buyPrice',
    'totalCount'
  ];

  constructor(
    private storageProductsService: StorageProductsService,
    private categoriesService: CategoryService,
    private changeDetectorRef: ChangeDetectorRef,
    private snackbarService: SnackBarService,
    private dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.headerSearchFormGroup = new FormGroup({
      productNameContains: new FormControl(''),
      retailSellPriceMin: new FormControl(''),
      retailSellPriceMax: new FormControl(''),
      wholesaleSellPriceMin: new FormControl(''),
      wholesaleSellPriceMax: new FormControl(''),
      buyPriceMin: new FormControl(''),
      buyPriceMax: new FormControl('')
    });

    this.fetchProducts();
    this.fetchFlattenedCategories();

    this.categoryListFilter.valueChanges
      .pipe(takeUntil(this.ngDestroy$))
      .subscribe((term: string) => {
        this.filterCategories(term);
      });

    this.subscribeToCategoryChange();
    this.subscribeToOnlyOutOfStockChange();
  }

  public subscribeToOnlyOutOfStockChange() {
    this.onlyOutOfStockControl.valueChanges
      .subscribe(() => {
        this.fetchProducts(0, this.paginator.pageSize);
      });
  }

  public pageChanged(): void {
    this.fetchProducts(this.paginator.pageIndex, this.paginator.pageSize);
  }

  public deleteProduct(id: string): void {
    this.dialog
    .open(ConfirmationDialogComponent, { data: 'Вы уверены?' })
    .afterClosed()
    .subscribe(
      (result) => {
        if (result) {
          this.loading = true;
          this.storageProductsService.delete(this.storageId, id)
            .pipe(takeUntil(this.ngDestroy$))
            .subscribe(
              () => {
                this.fetchProducts(0, this.paginator.pageSize);
                this.snackbarService.openSuccess('Удалено');
              },
              () => {
                this.snackbarService.openError('Не удалось удалить');
              }
            );
        }
      }
    );
  }

  public search(): void {
    this.paginator.pageIndex = 0;
    this.fetchProducts(0, this.paginator.pageSize);
  }

  public getCategoryNestingPadding(nestingLevel: number): any {
    return nestingLevel * 16;
  }

  public isOutOfStock(row: StorageProduct) {
    return row.productsAmount <= 0;
  }

  private subscribeToCategoryChange(): void {
    this.categorySelect.valueChanges
      .pipe(takeUntil(this.ngDestroy$))
        .subscribe(() => {
          this.fetchProducts(0, this.paginator.pageSize);
        });
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

  private fetchProducts(page = 0, pageSize = 10): void {
    this.loading = true;

    if (this.paginator && pageSize === 10) {
      pageSize = this.paginator.pageSize;
    }

    const filterRequest = this.headerSearchFormGroup.getRawValue() as ProductsSearchModel;
    filterRequest.page = page;
    filterRequest.pageSize = pageSize;
    filterRequest.categoryId = this.categorySelect.value;
    filterRequest.onlyOutOfStock = this.onlyOutOfStockControl.value;

    this.products$ = this.storageProductsService.getFiltered(this.storageId, filterRequest)
      .pipe(
        share(),
        tap(() => { this.loading = false; })
      );
  }

  private fetchFlattenedCategories(): void {
    this.categoriesService.getAllFlattened()
      .pipe(takeUntil(this.ngDestroy$))
      .subscribe(
        (categories: FilteredResult<CategoryFlat>) => {
          this.flattenedCategories = categories;
          this.filteredFlattenedCategories = this.flattenedCategories.data;
        },
        () => {

        }
      );
  }

  ngOnDestroy(): void {
    this.ngDestroy$.next(null);
  }
}
