import { OrderStatusType } from '../../../../website/financial/order/order-status.type';
import { UserModel } from '../../../../base/models/user.model';
import { EronFile } from '../../../../base/models/EronFile.model';

export interface OrderDetailsModel {
  id: string;
  orderNumber: string;
  description: string;
  approved: boolean;
  count: number;
  tariffId: number;
  price: number;
  invoiceId: number;
  invoiceNumber: string;
  userId: string;
  orderStatus: OrderStatusType;
  imageIds: string[];
  imageAddresses: string[];
  hasDesignOrder: boolean;
  designPrice: number;
  finalPrice: number;
  tariffName: string;
  quantity: number;
  selected: boolean;
  user: UserModel;
}
