import { trigger, state, style, transition, animate } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FilteredResult, SalesReport, SalesReportsService } from '@app/core';
import { SoldProduct } from '@app/core/models/api/core/sold-product.model';
import { SalesReportsSearch } from '@app/core/models/api/request-models/sales-reports-search.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-sales-reports',
  templateUrl: './sales-reports.component.html',
  styleUrls: ['./sales-reports.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class SalesReportsComponent implements OnInit {

  public columnsToDisplay = [
    'date',
    'totalSum',
    'userSum'
  ];

  public dataSource$: Observable<FilteredResult<SalesReport>>;
  public expandedReport: SalesReport | null;

  private storeId: string;

  constructor(
    private salesReportsService: SalesReportsService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.storeId = this.activatedRoute.snapshot.paramMap.get('id');
    this.fetchSalesReports();
  }

  public getTotalSum(salesReport: SalesReport): number {
    return salesReport.totalSum;
  }

  public getUserSum(salesReport: SalesReport): number {
    return salesReport.userSoldAmount;
  }

  private fetchSalesReports(): void {
    this.dataSource$ = this.salesReportsService.getFiltered(this.storeId, new SalesReportsSearch());
  }
}
