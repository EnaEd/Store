import { PaginationRequestModel } from './pagination-request.model';
import { EditionType } from '../../enums/edition-type.enum';
import { PayStatus } from '../../enums/pay-status.enum';
import { CurrencyTypeEnum } from '../../enums/currency-type.enum';

export class EditionRequestModel extends PaginationRequestModel {
  title: string;
  author: string;
  description: string;
  orderByDesc: boolean;
  price: PriceRangeModel;
  status: PayStatus;
  type: EditionType;
  currency: CurrencyTypeEnum;

  constructor(
    price: PriceRangeModel = new PriceRangeModel(0, 10000),
    pageNumber: number = 1,
    pageSize: number = 10
  ) {
    super();
    this.price = price;
    this.pageNumber = pageNumber;
    this.pageSize = pageSize;
  }
}
class PriceRangeModel {
  minPrice: number;
  maxPrice: number;
  constructor(min: number = 0, max: number = 10) {
    this.minPrice = min;
    this.maxPrice = max;
  }
}
