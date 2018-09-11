import { Injectable } from '@angular/core';
import { Api } from '../../../base/api';
import { HttpClient } from '../../../base/services/app.http.service';

import { ProductCategoryCreateModel } from './product-category-create/product-category-create.model';
import { ProductCategoryUpdateModel } from './product-category-update/product-category-update.model';


@Injectable()
export class ProductCategoryService {

  constructor(
    private http: HttpClient
  ) { }

  get(id: number) {
    return this.http.get(Api.productCategory.default + id);
  }

  getAll() {
    return this.http.get(Api.productCategory.default);
  }

  getHomePageCategories() {
    return this.http.get(Api.productCategory.getHome);
  }

  getFlatCategories() {
    return this.http.get(Api.productCategory.getFlat);
  }

  getAllFullCategories() {
    return this.http.get(Api.productCategory.getFull);
  }

  create(model: ProductCategoryCreateModel) {
    return this.http.post(Api.productCategory.default, model);
  }

  update(model: ProductCategoryUpdateModel) {
    return this.http.put(Api.productCategory.default, model);
  }

  delete(id: number) {
    return this.http.delete(Api.productCategory.default + id);
  }

  reOrderItems(model: any) {
    return this.http.post(Api.productCategory.reOrder, model);
  }
}
