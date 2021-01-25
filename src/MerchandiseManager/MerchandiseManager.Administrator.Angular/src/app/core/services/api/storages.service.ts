import { ApiService } from '../utils';
import { Observable } from 'rxjs';
import { FilteredResult, StorageProduct } from '../../models';
import { HttpParams } from '@angular/common/http';
import { ProductsSearchModel } from '../../models/api/request-models';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StoragesService {

  constructor(private apiService: ApiService) {
  }

  public getAll(): Observable<Storage[]> {
    return this.apiService.get<Storage[]>('/api/storages');
  }
}
