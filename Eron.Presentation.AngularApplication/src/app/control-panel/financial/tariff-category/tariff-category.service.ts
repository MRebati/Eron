import { HttpClient } from '../../../base/services/app.http.service';
import { Injectable } from '@angular/core';
import { Api } from '../../../base/api';
import { TariffCategoryCreateModel } from './tariff-category-create/tariff-category-create.model';
import { TariffCategoryUpdateModel } from './tariff-category-update/tariff-category-update.model';

@Injectable()
export class TariffCategoryService {
  constructor(
    private http: HttpClient
  ) {
  }
  get(id: number) {
    return this.http.get(Api.tariffCategory.default + id);
  }

  getAll() {
    return this.http.get(Api.tariffCategory.default);
  }

  getFlatCategories() {
    return this.http.get(Api.tariffCategory.getFlat);
  }

  getAllFullCategories() {
    return this.http.get(Api.tariffCategory.getFull);
  }

  create(model: TariffCategoryCreateModel) {
    return this.http.post(Api.tariffCategory.default, model);
  }

  update(model: TariffCategoryUpdateModel) {
    return this.http.put(Api.tariffCategory.default, model);
  }

  delete(id: number) {
    return this.http.delete(Api.tariffCategory.default + id);
  }

  reOrderItems(model: any) {
    return this.http.post(Api.tariffCategory.reOrder, model);
  }
}
