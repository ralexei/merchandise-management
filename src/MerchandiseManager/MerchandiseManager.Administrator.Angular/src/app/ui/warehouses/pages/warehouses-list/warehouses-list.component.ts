import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { SnackBarService, Warehouse, WarehousesService } from '@app/core';
import { NewStorageDialogComponent } from '@app/shared/components/new-storage-dialog/new-storage-dialog.component';
import { faPlus, faWarehouse } from '@fortawesome/free-solid-svg-icons';
import { Observable, Subject } from 'rxjs';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-warehouses-list',
  templateUrl: './warehouses-list.component.html',
  styleUrls: ['./warehouses-list.component.scss']
})
export class WarehousesListComponent implements OnInit, OnDestroy {

  faWarehouse = faWarehouse;
  faPlus = faPlus;
  
  public warehouses$?: Observable<Warehouse[]>

  public isLoading: boolean = false;

  private ngDestroy$: Subject<void> = new Subject<void>();

  constructor(
    private warehousesService: WarehousesService,
    private snackBarService: SnackBarService,
    private matDialog: MatDialog,
    private router: Router) { }

  ngOnInit(): void {
    this.fetchWarehouses();
  }

  public openWarehouseDetails(warehouseId: string): void {
    this.router.navigate([`warehouses/${warehouseId}`])
  }

  public addWarehouse(): void {
    this.matDialog
      .open(NewStorageDialogComponent)
      .afterClosed()
      .subscribe((storage) => {
        if (storage) {
          this.isLoading = true;
          this.warehousesService.create(storage)
            .pipe(
              finalize(() => {
                this.isLoading = false;
              })
            )
            .subscribe(() => {
              this.snackBarService.openSuccess('Склад добавлен успешно!');
              this.fetchWarehouses();
            },
            (err: any) => {
              this.snackBarService.openError('Возникла ошибка при добавлении склада!');
            });
        }
      });
  }

  private fetchWarehouses(): void {
    this.warehouses$ = this.warehousesService.getAll();
  }

  ngOnDestroy(): void {
    this.ngDestroy$.next();
  }
}
