import { ApiService } from '../utils';
import { Observable } from 'rxjs';
import { Warehouse } from '../../models';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WarehousesService {

  constructor(private apiService: ApiService) {
  }

  public getAll(): Observable<Warehouse[]> {
    return this.apiService.get<Warehouse[]>('/api/warehouses');
  }

  public create(warehouse: Warehouse): Observable<void> {
    return this.apiService.post<void>('/api/warehouses', warehouse);
  }
}
