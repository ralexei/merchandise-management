import { ApiService } from '../utils';
import { Observable } from 'rxjs';
import { FilteredResult, StorageProduct } from '../../models';
import { HttpParams } from '@angular/common/http';
import { ProductsSearchModel } from '../../models/api/request-models';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageProductsService {

  constructor(private apiService: ApiService) {
  }

  public getFiltered(storageId: string, request: ProductsSearchModel): Observable<FilteredResult<StorageProduct>> {
    let httpParams = new HttpParams();

    Object.keys(request).forEach((key) => {
      if (request[key]) {
        httpParams = httpParams.set(key, request[key].toString());
      }
    });

    return this.apiService.get<FilteredResult<StorageProduct>>(`/api/storage-products/${storageId}`, { params: httpParams });
  }

  public delete(storageId: string, productId: string) {
    return this.apiService.delete<void>(`/api/storage-products/${storageId}/${productId}`);
  }


  public replenish(storageId: string, productId: string, amount: number): Observable<void> {
    const dict: Dictionary = {};

    dict[productId] = amount;

    return this.apiService.post<void>('/api/storage-products', {
      products: dict,
      destinationStorageId: storageId
    });
  }
}

type Dictionary = {
  [key: string]: any
}
