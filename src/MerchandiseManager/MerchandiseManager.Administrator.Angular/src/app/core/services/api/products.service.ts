import { ApiService } from '../utils';
import { Observable } from 'rxjs';
import { FilteredResult, Product } from '../../models';
import { HttpParams } from '@angular/common/http';
import { ProductsSearchModel } from '../../models/api/request-models';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private apiService: ApiService) {

  }

  public getFiltered(request: ProductsSearchModel): Observable<FilteredResult<Product>> {
    let httpParams = new HttpParams();

    Object.keys(request).forEach((key) => {
      if (request[key]) {
        httpParams = httpParams.set(key, request[key].toString());
      }
    });

    return this.apiService.get<FilteredResult<Product>>('/api/products', { params: httpParams });
  }

  public create(product: Product): Observable<Product> {
    return this.apiService.post('/api/products', product);
  }

  public delete(id: string): Observable<void> {
    return this.apiService.delete<void>(`/api/products/${id}`);
  }

  public update(id: string, product: Product): Observable<void> {
    return this.apiService.put<void>(`/api/products/${id}`, product);
  }
}
