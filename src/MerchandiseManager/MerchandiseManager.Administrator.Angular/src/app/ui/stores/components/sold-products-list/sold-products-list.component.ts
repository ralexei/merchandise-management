import { Component, Input, OnInit } from '@angular/core';
import { SalesReport } from '@app/core';

@Component({
  selector: 'app-sold-products-list',
  templateUrl: './sold-products-list.component.html',
  styleUrls: ['./sold-products-list.component.scss']
})
export class SoldProductsListComponent implements OnInit {

  @Input()
  public salesReport: SalesReport;

  public displayedColumns = [
    'productName',
    'sellPrice',
    'sellAmount',
    'total'
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
