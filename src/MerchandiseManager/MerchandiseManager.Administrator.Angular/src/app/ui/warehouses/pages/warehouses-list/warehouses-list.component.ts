import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StoragesService } from '@app/core';
import { faWarehouse } from '@fortawesome/free-solid-svg-icons';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-warehouses-list',
  templateUrl: './warehouses-list.component.html',
  styleUrls: ['./warehouses-list.component.scss']
})
export class WarehousesListComponent implements OnInit {

  faWarehouse = faWarehouse;

  public storages$: Observable<Storage[]>

  constructor(
    private storagesService: StoragesService,
    private router: Router) { }

  ngOnInit(): void {
    this.storages$ = this.storagesService.getAll();
  }

  public openStorageDetails(storageId: string): void {
    this.router.navigate([`warehouses/${storageId}`])
  }
}
