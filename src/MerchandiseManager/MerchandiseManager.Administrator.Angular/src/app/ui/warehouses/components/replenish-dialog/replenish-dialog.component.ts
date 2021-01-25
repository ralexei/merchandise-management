import { Component, Inject, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Product, StorageProductsService, StoragesService } from '@app/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-replenish-dialog',
  templateUrl: './replenish-dialog.component.html',
  styleUrls: ['./replenish-dialog.component.scss']
})
export class ReplenishDialogComponent implements OnInit {

  public storages$: Observable<Storage[]>;
  public sourceStorageIdControl: FormControl = new FormControl('');
  public destinationStorageIdControl: FormControl = new FormControl('');

  constructor(
    private storagesService: StoragesService,
    private storageProductsService: StorageProductsService) { }

  ngOnInit(): void {
    this.storages$ = this.storagesService.getAll();
  }
}
