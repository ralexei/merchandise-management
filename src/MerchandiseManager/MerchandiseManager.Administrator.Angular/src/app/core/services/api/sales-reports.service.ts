import { HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { SalesReport } from "@app/core/models";
import { SalesReportsSearch } from "@app/core/models/api/request-models/sales-reports-search.model";
import { FilteredResult } from "@app/core/models/api/response-models/filtered-result.model";
import { Observable } from "rxjs";
import { ApiService } from "../utils/api.service";

@Injectable({
  providedIn: 'root'
})
export class SalesReportsService {
  constructor(private api: ApiService) {
  }

  public getFiltered(storeId: string, request: SalesReportsSearch): Observable<FilteredResult<SalesReport>> {
    let httpParams = new HttpParams();

    Object.keys(request).forEach((key) => {
      const requestKey = key as keyof typeof request;
      if (request[requestKey]) {
        httpParams = httpParams.set(key, request[requestKey]!.toString());
      }
    });

    return this.api.get<FilteredResult<SalesReport>>(`/api/sales-reports/${storeId}`, { params: httpParams });
  }
}
