import { Component, OnInit } from '@angular/core';
import { Store } from '@ngxs/store';
import { EditionRequestModel } from '../../../models/request/edition-request.model';
import { EditionAction } from '../store/book.actions';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
})
export class BooksComponent implements OnInit {
  constructor(private _store: Store) {}

  ngOnInit(): void {
    this._store.dispatch(new EditionAction.FetchAll(new EditionRequestModel()));
  }
}
