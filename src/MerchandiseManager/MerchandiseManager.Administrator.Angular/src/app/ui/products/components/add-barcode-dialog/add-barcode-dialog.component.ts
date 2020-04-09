import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-barcode-dialog',
  templateUrl: './add-barcode-dialog.component.html',
  styleUrls: ['./add-barcode-dialog.component.scss']
})
export class AddBarcodeDialogComponent implements OnInit {

  public barcodeControl: FormControl = new FormControl('', Validators.required);

  constructor(
    private dialogRef: MatDialogRef<AddBarcodeDialogComponent>
  ) { }

  ngOnInit(): void {
  }

  public submit(): void {
    if (this.barcodeControl.valid) {
      this.dialogRef.close(this.barcodeControl.value);
    }
  }

  public cancel(): void {
    this.dialogRef.close();
  }
}
