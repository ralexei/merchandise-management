import { Injectable } from '@angular/core';
import { ApiService } from '../utils';
import { Observable } from 'rxjs';
import { FilteredResult, Category, CategoryFlat } from '@app/core/models';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(private api: ApiService) {
  }

  public getAll(): Observable<FilteredResult<Category>> {
    return this.api.get<FilteredResult<Category>>('/api/categories');
  }

  public getAllFlattened(): Observable<FilteredResult<CategoryFlat>> {
    return this.api.get<FilteredResult<CategoryFlat>>('/api/flattened-categories');
  }

  public create(category: Category): Observable<Category> {
    return this.api.post<Category>('/api/categories', category);
  }

  public delete(id: string): Observable<Category> {
    return this.api.delete(`/api/categories/${id}`);
  }
}
