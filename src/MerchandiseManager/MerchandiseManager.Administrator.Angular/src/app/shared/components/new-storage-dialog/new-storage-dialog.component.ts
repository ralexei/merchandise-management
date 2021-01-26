import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-new-storage-dialog',
  templateUrl: './new-storage-dialog.component.html',
  styleUrls: ['./new-storage-dialog.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class NewStorageDialogComponent implements OnInit {

  public formGroup: FormGroup;

  constructor(private matDialogRef: MatDialogRef<NewStorageDialogComponent>) { }

  ngOnInit(): void {
    this.formGroup = new FormGroup({
      name: new FormControl('', [Validators.required]),
      description: new FormControl('')
    });
  }

  public onSubmit(): void {
    this.formGroup.markAllAsTouched();

    if (this.formGroup.valid) {
      this.matDialogRef.close(this.formGroup.getRawValue());
    }
  }

  public cancel(): void {
    this.matDialogRef.close();
  }
}
