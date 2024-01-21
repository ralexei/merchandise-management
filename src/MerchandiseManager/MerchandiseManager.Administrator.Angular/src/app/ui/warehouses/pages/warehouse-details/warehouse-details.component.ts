import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { ActivatedRoute } from '@angular/router';
import { CategoryFlat, FilteredResult, Product, ProductsService, SnackBarService, AuthService, ProductsSearchModel, StorageProductsService, StorageProduct } from '@app/core';
import { CategoryService } from '@app/core/services/api/category.service';
import { ConfirmationDialogComponent } from '@app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { CreateProductDialogComponent } from '@app/ui/products/components/create-product-dialog/create-product-dialog.component';
import { EditProductDialogComponent } from '@app/ui/products/components/edit-product-dialog/edit-product-dialog.component';
import { Observable, Subject } from 'rxjs';
import { takeUntil, share, tap } from 'rxjs/operators';
import { ReplenishDialogComponent } from '../../components/replenish-dialog/replenish-dialog.component';

@Component({
  selector: 'app-warehouse-details',
  templateUrl: './warehouse-details.component.html',
  styleUrls: ['./warehouse-details.component.scss']
})
export class WarehouseDetailsComponent implements OnInit {

  public storageId: string | null = null;

  constructor(private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.storageId = this.route.snapshot.paramMap.get('id');
  }
}
