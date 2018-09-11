import { OrderStatusType } from '../order/order-status.type';

export interface MyOrdersListModel {
  orderNumber: string;
  selected: boolean;
  approved: boolean;
  price: number;
  hasDesignOrder: boolean;
  designPrice: number;
  finalPrice: number;
  tariffId?: number;
  tariffName: string;
  count: number;
  quantity: number;
  orderStatus: OrderStatusType;
  invoiceNumber: string;
  invoiceId?: number;
}
