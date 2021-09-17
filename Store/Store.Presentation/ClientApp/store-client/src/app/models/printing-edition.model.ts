import { CurrencyTypeEnum } from '../enums/currency-type.enum';
import { EditionType } from '../enums/edition-type.enum';
import { PayStatus } from '../enums/pay-status.enum';
import { AuthorModel } from './author.model';
export class PrintingEditionModel {
  title: string;
  description: string;
  price: number;
  status: PayStatus;
  editionType: EditionType;
  currency: CurrencyTypeEnum;
  authors: AuthorModel[];
}
