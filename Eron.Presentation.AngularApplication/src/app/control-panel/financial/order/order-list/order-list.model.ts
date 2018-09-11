import { OrderStatusType } from '../../../../website/financial/order/order-status.type';
import { DatePeriodType } from '../../../../base/types/DatePeriod.type';
import { PagedListRequest } from '../../../../base/models/pagedListRequest.model';

export interface OrderListRequestModel extends PagedListRequest {
  datePeriod: DatePeriodType;
  orderStatus?: OrderStatusType;
  orderNumber: string;
}
