import { Component, OnInit } from '@angular/core';
import { faWarehouse } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-warehouses-list',
  templateUrl: './warehouses-list.component.html',
  styleUrls: ['./warehouses-list.component.scss']
})
export class WarehousesListComponent implements OnInit {

  faWarehouse = faWarehouse;

  constructor() { }

  ngOnInit(): void {
  }

  ping() {
  }
}
