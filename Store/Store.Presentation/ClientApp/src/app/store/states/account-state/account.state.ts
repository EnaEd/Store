import { SignInAction } from './../../actions/account-actions/sign-in.actions';
import { Injectable } from '@angular/core';
import { Action, State, StateContext } from '@ngxs/store';
import { UserStateModel } from '../../../models/state-models/user-state.model';
import { SignInRequestModel } from 'src/app/models/request-models/sign-in-request.model';

@State<UserStateModel>({
  name: 'currentUser',
  defaults: { user: null },
})
@Injectable()
export class AccountState {
  constructor() {}

  @Action(SignInAction)
  sigin(context: StateContext<UserStateModel>, model: SignInRequestModel) {
    debugger;
  }
}
