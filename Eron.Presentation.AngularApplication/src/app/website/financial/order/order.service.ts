import { Injectable } from '@angular/core';
import { HttpClient } from '../../../base/services/app.http.service';
import { OrderItemCreateModel } from './order-item/order-item.model';
import { Api } from '../../../base/api';
import { OrderDesignPriceModel } from './order.changeDesignPrice.model';
import { OrderListRequestModel } from '../../../control-panel/financial/order/order-list/order-list.model';

@Injectable()
export class OrderService {
  constructor(
    private http: HttpClient
  ) {
  }

  getAllOrders(filter: OrderListRequestModel) {
    return this.http.post(Api.order.pagedList, filter);
  }

  getUserOrders() {
    return this.http.get(Api.order.userAll);
  }

  getOrderByNumber(orderNumber: string) {
    return this.http.get(Api.order.getByNumber + orderNumber);
  }

  createOrder(model: OrderItemCreateModel) {
    return this.http.post(Api.order.default, model);
  }

  addDesignPrice(model: OrderDesignPriceModel) {
    return this.http.post(Api.order.addDesignPrice, model);
  }

  cancelOrders(arg0: any): any {
    throw new Error('Method not implemented.');
  }

  changeStateOfOrderList(model: any) {
    return this.http.post(Api.order.changeStateOfOrderList, model);
  }

  changeDesignPrice(model: any) {
    return this.http.post(Api.order.assignDesignPrice, model);
  }
}
