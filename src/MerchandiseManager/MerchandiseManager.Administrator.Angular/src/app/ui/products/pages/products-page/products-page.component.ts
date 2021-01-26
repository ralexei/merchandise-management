import { Component, OnInit, ViewChild, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { ProductsService } from '@app/core/services/api';
import { Observable, Subject } from 'rxjs';
import { FilteredResult, Product, LoginRequest, LoginResult, Category, CategoryFlat, ProductsSearchModel } from '@app/core/models';
import { AuthService } from '@app/core/services/api/auth.service';
import { MatPaginator } from '@angular/material/paginator';
import { share, takeUntil, tap } from 'rxjs/operators';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { CreateProductDialogComponent } from '../../components/create-product-dialog/create-product-dialog.component';
import { CategoryService } from '@app/core/services/api/category.service';
import { SnackBarService } from '@app/core';
import { ConfirmationDialogComponent } from '@app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { webSocket, WebSocketSubject } from 'rxjs/webSocket';
import { SignalRPrinterService } from '@app/core/services/signalr/signalr-printer.service';
import { EditProductDialogComponent } from '../../components/edit-product-dialog/edit-product-dialog.component';
import { ReplenishDialogComponent } from '../../components/replenish-dialog/replenish-dialog.component';

@Component({
  selector: 'app-products-page',
  templateUrl: './products-page.component.html',
  styleUrls: ['./products-page.component.scss']
})
export class ProductsPageComponent implements OnInit, OnDestroy {

  @ViewChild(MatPaginator)
  public paginator: MatPaginator;

  public headerSearchFormGroup: FormGroup;

  public categorySelect: FormControl = new FormControl('');
  public categoryListFilter: FormControl = new FormControl('');

  public filteredFlattenedCategories: CategoryFlat[];
  public flattenedCategories: FilteredResult<CategoryFlat>;
  public products$: Observable<FilteredResult<Product>>;

  public loading = true;

  public ngDestroy$: Subject<void> = new Subject<void>();

  public displayedColumns = [
    'actions',
    'productName',
    'retailSellPrice',
    'wholesaleSellPrice',
    'buyPrice'
  ];

  constructor(
    private productsService: ProductsService,
    private categoriesService: CategoryService,
    private changeDetectorRef: ChangeDetectorRef,
    private snackbarService: SnackBarService,
    authService: AuthService,
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
  }

  public pageChanged(event: any): void {
    this.fetchProducts(this.paginator.pageIndex, this.paginator.pageSize);
  }

  public openAddDialog(): void {
    this.dialog.open(CreateProductDialogComponent,
    {
        minWidth: '300px',
        maxWidth: '500px',
        // height: '95%'
    })
    .afterClosed()
    .subscribe(
      (createdProduct: Product) => {
        if (createdProduct) {
          this.fetchProducts(this.paginator.pageIndex, this.paginator.pageSize);
        }
      }
    );
  }

  public editProduct(product: Product): void {
    this.dialog.open(EditProductDialogComponent,
      {
          minWidth: '300px',
          maxWidth: '500px',
          data: product
          // height: '95%'
      })
      .afterClosed()
      .subscribe(
        (editedProduct: Product) => {
          if (editedProduct) {
            this.fetchProducts(this.paginator.pageIndex, this.paginator.pageSize);
          }
        }
      );
  }

  public deleteProduct(id: string): void {
    this.dialog
      .open(ConfirmationDialogComponent, { data: 'Вы уверены?' })
      .afterClosed()
      .subscribe(
        (result) => {
          if (result) {
            this.loading = true;
            this.productsService.delete(id)
              .pipe(takeUntil(this.ngDestroy$))
              .subscribe(
                () => {
                  this.fetchProducts(0, this.paginator.pageSize);
                  this.snackbarService.openSuccess('Удалено');
                },
                (err) => {
                  this.snackbarService.openError('Не удалось удалить');
                }
              );
          }
        }
      );
  }

  public addToStorage(product: Product): void {
    this.dialog
      .open(ReplenishDialogComponent,
        {
            minWidth: '300px',
            maxWidth: '300px',
            data: product
            // height: '95%'
        })
      .afterClosed()
      .subscribe();
  }

  public search(): void {
    this.paginator.pageIndex = 0;
    this.fetchProducts(0, this.paginator.pageSize);
  }

  public getCategoryNestingPadding(nestingLevel: number): any {
    return nestingLevel * 16;
  }

  private subscribeToCategoryChange(): void {
    this.categorySelect.valueChanges
      .pipe(takeUntil(this.ngDestroy$))
        .subscribe((term: string) => {
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

    this.products$ = this.productsService.getFiltered(filterRequest)
      .pipe(
        share(),
        tap((t) => { this.loading = false; })
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
        (err: any) => {

        }
      );
  }

  ngOnDestroy(): void {
    this.ngDestroy$.next(null);
  }
}
