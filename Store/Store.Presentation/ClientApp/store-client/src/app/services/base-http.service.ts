import { HttpClient } from '@angular/common/http';
import { Type } from '@angular/compiler';
import { Observable } from 'rxjs';

export class BaseHttpService {
  constructor(private _httpClient: HttpClient) {}

  get<Type>(route: string): Observable<Type> {
    let result = this._httpClient.get(route) as Observable<Type>;
    return result;
  }
  post<TIn, TOut>(route: string, body: TIn): Observable<TOut> {
    let result = this._httpClient.post(route, body) as Observable<TOut>;
    return result;
  }
}
