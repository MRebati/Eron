import { Injectable } from '@angular/core';
import { HttpClient } from '../../../base/services/app.http.service';
import { Api } from '../../../base/api';

@Injectable()
export class WishListService {
  constructor(
    private http: HttpClient
  ) {
  }

  getUserWishList() {
    return this.http.get(Api.wishList.default);
  }

  create(productId: number) {
    const model = {
      productId
    };

    return this.http.post(Api.wishList.default, model);
  }

  delete(id: number) {
    return this.http.delete(Api.wishList.default + id);
  }
}
