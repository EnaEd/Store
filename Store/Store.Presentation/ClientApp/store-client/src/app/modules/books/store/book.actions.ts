import { EditionRequestModel } from '../../../models/request/edition-request.model';

export namespace EditionAction {
  export class FetchAll {
    static readonly type = '[Edition Action] get edition';
    constructor(public payload: EditionRequestModel) {}
  }
}
