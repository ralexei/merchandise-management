import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { ActivatedRoute } from '@angular/router';
import { CategoryFlat, FilteredResult, StorageProduct, StorageProductsService, SnackBarService, Product, ProductsSearchModel } from '@app/core';
import { CategoryService } from '@app/core/services/api/category.service';
import { ConfirmationDialogComponent } from '@app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { ReplenishDialogComponent } from '@app/ui/products/components/replenish-dialog/replenish-dialog.component';
import { Observable, Subject } from 'rxjs';
import { takeUntil, share, tap } from 'rxjs/operators';

@Component({
  templateUrl: './store-details.component.html',
  styleUrls: ['./store-details.component.scss']
})
export class StoreDetailsComponent implements OnInit {

  public storageId: string;

  constructor(private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.storageId = this.route.snapshot.paramMap.get('id');
  }
}
