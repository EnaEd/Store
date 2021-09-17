import { PrintingEditionModel } from './../../../models/printing-edition.model';
import { EditionState } from './../store/book.state';
import { Component, OnInit } from '@angular/core';
import { Select, Store } from '@ngxs/store';
import { EditionRequestModel } from '../../../models/request/edition-request.model';
import { EditionAction } from '../store/book.actions';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
})
export class BooksComponent implements OnInit {
  @Select(EditionState.editions()) editions$: Observable<
    PrintingEditionModel[]
  >;

  constructor(private _store: Store) {}

  ngOnInit(): void {
    this._store.dispatch(new EditionAction.FetchAll(new EditionRequestModel()));
  }
}
