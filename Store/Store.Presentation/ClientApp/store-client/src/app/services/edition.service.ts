import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EditionRequestModel } from '../models/request/edition-request.model';
import { EditionResponseModel } from '../models/response/edition-response.model';
import { BaseHttpService } from './base-http.service';
// export class EditionService extends BaseHttpService {
//   FetchBooks(body: EditionRequestModel): Observable<EditionResponseModel> {
//     debugger;
//     return this.post(
//       'https://localhost:5001/api/printingedition/getedition',
//       body
//     );
//   }
// }
@Injectable()
export class EditionService {
  constructor(private _httpClient: HttpClient) {}
  FetchBooks(body: EditionRequestModel): Observable<EditionResponseModel> {
    let result = this._httpClient.post(
      'https://localhost:5001/api/printingedition/getedition',
      body
    ) as Observable<EditionResponseModel>;
    return result;
  }
}
