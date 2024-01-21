import { ApiService } from '../utils';
import { Observable } from 'rxjs';
import { FilteredResult, StorageProduct } from '../../models';
import { HttpParams } from '@angular/common/http';
import { ProductsSearchModel } from '../../models/api/request-models';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StoreProductsService {

  constructor(private apiService: ApiService) {
  }

  public getFiltered(storeId: string, request: any): Observable<FilteredResult<StorageProduct>> {
    let httpParams = new HttpParams();

    Object.keys(request).forEach((key) => {
      if (request[key]) {
        httpParams = httpParams.set(key, request[key].toString());
      }
    });

    return this.apiService.get<FilteredResult<StorageProduct>>(`/api/stores/${storeId}/products`, { params: httpParams });
  }
}
