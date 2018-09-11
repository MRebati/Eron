import { Injectable } from '@angular/core';
import { NotificationService } from '../../../base/services/notification.service';
import { HttpClient } from '../../../base/services/app.http.service';
import { Api } from '../../../base/api';
import { CartCreateModel } from './cart-create/cart-create.model';
import { CartListModel } from './cart-list/cart-list.model';

@Injectable()
export class CartService {
  constructor(
    private notificationService: NotificationService,
    private http: HttpClient
  ) {
  }
  private currentItems: CartListModel[];

  getItems() {
    return this.http.get(Api.cart.default);
  }

  createItem(item: CartCreateModel) {
    return this.http.post(Api.cart.default, item);
  }

  updateItem(item: CartListModel) {
    return this.http.put(Api.cart.default, item);
  }

  removeItem(id: number) {
    return this.http.delete(Api.cart.default + id);
  }

  setCurrentItems(list: CartListModel[]) {
    this.currentItems = list;
  }

  getCurrentItems() {
    return this.currentItems;
  }

  itemExists(productId) {
    return this.currentItems.filter(x =>  x.productId === productId).length > 0;
  }
}
