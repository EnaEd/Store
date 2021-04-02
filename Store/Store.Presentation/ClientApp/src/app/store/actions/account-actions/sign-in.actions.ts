import { SignInRequestModel } from '../../../models/request-models/sign-in-request.model';

export class SignInAction {
  static readonly type = '[SignIn] sign-in request';
  constructor(public model: SignInRequestModel) {}
}
