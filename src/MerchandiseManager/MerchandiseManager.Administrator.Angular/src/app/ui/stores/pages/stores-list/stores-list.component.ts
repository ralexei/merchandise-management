import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Store, StoresService, SnackBarService } from '@app/core';
import { NewStorageDialogComponent } from '@app/shared/components/new-storage-dialog/new-storage-dialog.component';
import { faStore, faPlus } from '@fortawesome/free-solid-svg-icons';
import { Observable, Subject } from 'rxjs';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-stores-list',
  templateUrl: './stores-list.component.html',
  styleUrls: ['./stores-list.component.scss']
})
export class StoresListComponent implements OnInit, OnDestroy {

  faStore = faStore;
  faPlus = faPlus;
  
  public stores$: Observable<Store[]>

  public isLoading: boolean;

  private ngDestroy$: Subject<void> = new Subject<void>();

  constructor(
    private storesService: StoresService,
    private snackBarService: SnackBarService,
    private matDialog: MatDialog,
    private router: Router) { }

  ngOnInit(): void {
    this.fetchStores();
  }

  public openStoreDetails(storeId: string): void {
    this.router.navigate([`stores/${storeId}`])
  }

  public addStore(): void {
    this.matDialog
      .open(NewStorageDialogComponent)
      .afterClosed()
      .subscribe((storage) => {
        if (storage) {
          this.isLoading = true;
          this.storesService.create(storage)
            .pipe(
              finalize(() => {
                this.isLoading = false;
              })
            )
            .subscribe(() => {
              this.snackBarService.openSuccess('Склад добавлен успешно!');
              this.fetchStores();
            },
            (err: any) => {
              this.snackBarService.openError('Возникла ошибка при добавлении склада!');
            });
        }
      });
  }

  private fetchStores(): void {
    this.stores$ = this.storesService.getAll();
  }

  ngOnDestroy(): void {
    this.ngDestroy$.next(null);
  }
}
