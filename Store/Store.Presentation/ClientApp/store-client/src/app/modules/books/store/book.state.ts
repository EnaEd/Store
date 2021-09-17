import { PrintingEditionModel } from './../../../models/printing-edition.model';
import { EditionResponseModel } from './../../../models/response/edition-response.model';
import { Injectable } from '@angular/core';
import {
  Action,
  createSelector,
  Selector,
  State,
  StateContext,
} from '@ngxs/store';
import { EditionService } from '../../../services/edition.service';
import { EditionAction } from './book.actions';
import { catchError, tap } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { of } from 'rxjs';
import { title } from 'process';

@State<EditionResponseModel>({
  name: 'editions',
  defaults: null,
})
@Injectable()
export class EditionState {
  constructor(
    private _editionService: EditionService,
    private _toast: ToastrService
  ) {}
  // selectors
  static editions() {
    return createSelector([EditionState], (state: EditionResponseModel) => {
      return state.data;
    });
  }

  // actions
  @Action(EditionAction.FetchAll)
  fetchBooks(
    ctx: StateContext<EditionResponseModel>,
    action: EditionAction.FetchAll
  ) {
    return this._editionService.FetchBooks(action.payload).pipe(
      tap((result) => {
        let state = ctx.getState();
        state = result;
        ctx.patchState(state);
      }),
      catchError(async (error) => this._toast.error(error.message))
    );
  }
}
