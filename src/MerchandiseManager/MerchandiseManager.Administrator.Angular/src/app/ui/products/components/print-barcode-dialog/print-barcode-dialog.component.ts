import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { FormControl, Validators } from '@angular/forms';
import { ConfirmationDialogComponent } from '@app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { SignalRPrinterService } from '@app/core/services/signalr/signalr-printer.service';
import { Product, PrintRequest, PrintingProductInfo } from '@app/core/models';
import { SnackBarService } from '@app/core';

@Component({
  selector: 'app-print-barcode-dialog',
  templateUrl: './print-barcode-dialog.component.html',
  styleUrls: ['./print-barcode-dialog.component.scss']
})
export class PrintBarcodeDialogComponent implements OnInit, OnDestroy {

  public barcodesCountControl: FormControl = new FormControl(1, Validators.required);

  public connectedToSocket = false;

  private ngDestroy$: Subject<void> = new Subject<void>();

  constructor(
    private matDialog: MatDialog,
    private snackbarService: SnackBarService,
    private signalrPrinterService: SignalRPrinterService,
    public dialogRef: MatDialogRef<PrintBarcodeDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.signalrPrinterService.startConnection()
      .then(() => {
        this.connectedToSocket = true;
        this.snackbarService.openSuccess('Подключение к принтеру прошло успешно!');
      })
      .catch(() => this.snackbarService.openError('Не удалось подключиться к принтеру'));
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
    if (this.connectedToSocket && this.barcodesCountControl.valid) {
      const req = new PrintRequest();

      req.barcodeToPrint = this.data.barcode;
      req.labelsCount = this.barcodesCountControl.value as number;
      req.printingProduct = new PrintingProductInfo();
      req.printingProduct.price = this.data.product.retailSellPrice;
      req.printingProduct.productName = this.data.product.productName;

      this.signalrPrinterService.printLabel(req);
    }
  }

  public close(): void {
    this.dialogRef.close();
  }

  ngOnDestroy(): void {
    this.ngDestroy$.next();
  }
}
