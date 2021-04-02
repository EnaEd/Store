import { TokenModel } from './../models/token.model';
import { environment } from './../../environments/environment';
import { HttpService } from './http-service';
import { Injectable } from '@angular/core';
import { SignInRequestModel } from '../models/request-models/sign-in-request.model';
import { Observable } from 'rxjs';

@Injectable()
export class AccountService {
  constructor(private _client: HttpService) {}
  signIn(requestModel: SignInRequestModel): Observable<TokenModel> {
    return this._client.post(
      `${environment.apiUrl}/api/account/signin`,
      requestModel
    ) as Observable<TokenModel>;
  }
}
