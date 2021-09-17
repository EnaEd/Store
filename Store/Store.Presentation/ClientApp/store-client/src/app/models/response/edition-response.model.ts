import { PrintingEditionModel } from './../printing-edition.model';
import { PaginatonResponseModel } from './pagination-response.model';
export class EditionResponseModel extends PaginatonResponseModel {
  data: PrintingEditionModel[];
}
