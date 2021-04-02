import { Component, OnInit } from '@angular/core';
import { Store } from '@ngxs/store';
import { SignInRequestModel } from 'src/app/models/request-models/sign-in-request.model';
import { SignInAction } from 'src/app/store/actions/account-actions/sign-in.actions';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss'],
})
export class SignInComponent implements OnInit {
  constructor(private _store: Store) {}

  ngOnInit(): void {}

  SignInClick() {
    this._store.dispatch(
      new SignInAction({
        email: 'devacccom@outlook.com',
        password: '1234567890Test!',
      })
    );
  }
}
