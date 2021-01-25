import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SnackBarService, StorageProductsService, StoragesService } from '@app/core';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-replenish-dialog',
  templateUrl: './replenish-dialog.component.html',
  styleUrls: ['./replenish-dialog.component.scss']
})
export class ReplenishDialogComponent implements OnInit {

  public storages$: Observable<Storage[]>;
  public destinationStorageIdControl: FormControl = new FormControl('', [Validators.required]);
  public amountControl: FormControl = new FormControl('', [Validators.required]);

  private ngDestroy$: Subject<void> = new Subject<void>();

  constructor(
    private dialogRef: MatDialogRef<ReplenishDialogComponent>,
    private storagesService: StoragesService,
    private storageProductsService: StorageProductsService,
    private snackbarService: SnackBarService,
    @Inject(MAT_DIALOG_DATA) public productId: string) { }

  ngOnInit(): void {
    this.storages$ = this.storagesService.getAll();
  }

  public onSubmit(): void {
    if (this.destinationStorageIdControl.valid && this.amountControl.valid) {
      this.storageProductsService.replenish(this.destinationStorageIdControl.value, this.productId, this.amountControl.value as number)
        .pipe(takeUntil(this.ngDestroy$))
        .subscribe(
          () => {
            this.snackbarService.openSuccess('Товар успешно добавлен!');
            this.dialogRef.close();
          },
          (err: any) => {
            this.snackbarService.openError('Ошибка');
          }
        );;
    }
  }
}
