import { ApiService } from '../utils';
import { Observable } from 'rxjs';
import { Store } from '../../models';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StoresService {

  constructor(private apiService: ApiService) {
  }

  public getAll(): Observable<Store[]> {
    return this.apiService.get<Store[]>('/api/stores');
  }

  public create(store: Store): Observable<void> {
    return this.apiService.post<void>('/api/stores', store);
  }
}
