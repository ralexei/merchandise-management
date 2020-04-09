import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  public baseUrl: string;

  constructor(private httpClient: HttpClient) {
    this.baseUrl = environment.baseApiUrl;
  }

  public get<T>(path: string, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    },
    params?: HttpParams | {
      [param: string]: string | string[];
    }
  }): Observable<T> {
    return this.httpClient.get<T>(this.baseUrl + path, options);
  }

  public post<T>(path: string, body: any, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    }
  }): Observable<T> {
    return this.httpClient.post<T>(this.baseUrl + path, body, options);
  }

  public delete<T>(path: string): Observable<T> {
    return this.httpClient.delete<T>(this.baseUrl + path);
  }

  public put<T>(path: string, body: any, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    },
    params?: HttpParams | {
      [param: string]: string | string[];
    }
  }): Observable<T> {
    return this.httpClient.put<T>(this.baseUrl + path, body, options);
  }
}
