import { EditionResponseModel } from './../../../models/response/edition-response.model';
import { Injectable } from '@angular/core';
import { Action, State, StateContext } from '@ngxs/store';
import { EditionService } from '../../../services/edition.service';
import { EditionAction } from './book.actions';
import { tap } from 'rxjs/operators';

@State<EditionResponseModel>({
  name: 'editions',
  defaults: null,
})
@Injectable()
export class EditionState {
  constructor(private _editionService: EditionService) {}

  @Action(EditionAction.FetchAll)
  fetchBooks(
    ctx: StateContext<EditionResponseModel>,
    action: EditionAction.FetchAll
  ) {
    debugger;
    return this._editionService.FetchBooks(action.payload).pipe(
      tap((result) => {
        let state = ctx.getState();
        state = result;
        ctx.patchState(state);
      })
    );
  }
}
