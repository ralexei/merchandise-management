import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { FormControl, Validators } from '@angular/forms';
import { ConfirmationDialogComponent } from '@app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-print-barcode-dialog',
  templateUrl: './print-barcode-dialog.component.html',
  styleUrls: ['./print-barcode-dialog.component.scss']
})
export class PrintBarcodeDialogComponent implements OnInit, OnDestroy {

  public barcodesCountControl: FormControl = new FormControl(1, Validators.required);

  private ngDestroy$: Subject<void> = new Subject<void>();

  constructor(
    private matDialog: MatDialog,
    public dialogRef: MatDialogRef<PrintBarcodeDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string) { }

  ngOnInit(): void {
  }

  public deleteBarcode(): void {
    this.matDialog
      .open(ConfirmationDialogComponent, { data: 'Удалить?'})
      .afterClosed()
      .pipe(takeUntil(this.ngDestroy$))
      .subscribe(
        (result) => {
          if (result) {
            this.dialogRef.close(this.data);
          }
        }
      );
  }

  public printBarcode(): void {
    // Print barcode
  }

  ngOnDestroy(): void {
    this.ngDestroy$.next();
  }
}
