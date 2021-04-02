import { TokenModel } from './../../../models/token.model';
import { SignInAction } from './../../actions/account-actions/sign-in.actions';
import { Injectable } from '@angular/core';
import { Action, State, StateContext } from '@ngxs/store';
import { UserStateModel } from '../../../models/state-models/user-state.model';
import { SignInRequestModel } from 'src/app/models/request-models/sign-in-request.model';
import { AccountService } from 'src/app/services/account-service';
import { catchError, map } from 'rxjs/operators';
import { empty } from 'rxjs';

@State<UserStateModel>({
  name: 'currentUser',
  defaults: { user: null },
})
@Injectable()
export class AccountState {
  constructor(private _accountService: AccountService) {}

  @Action(SignInAction)
  sigin(context: StateContext<UserStateModel>, model: SignInRequestModel) {
    debugger;
    return this._accountService.signIn(model).pipe(
      map(({ accessToken, refreshToken }: TokenModel) => {
        debugger;
        {
          const state = context.getState();
          context.setState({
            ...state,
            user: { ...state.user, accessToken, refreshToken },
          });
        }
      }),
      catchError((error) => empty)
    );
  }
}
