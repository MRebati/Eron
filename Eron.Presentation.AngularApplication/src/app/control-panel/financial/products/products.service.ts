
import { Injectable } from '@angular/core';
import { HttpClient } from '../../../base/services/app.http.service';
import { ProductCreateModel } from './product-create/productCreate.model';
import { Api } from '../../../base/api';
import { ToastsManager } from 'ng2-toastr/src/toast-manager';
import { ProductUpdateModel } from './product-update/product-update.model';


@Injectable()
export class ProductsService {
  constructor(private http: HttpClient, public toastr: ToastsManager) {
  }

  saveProduct(model: ProductCreateModel) {
    return this.http.post(Api.product.default, model);
  }

  updateProduct(model: ProductUpdateModel) {
    return this.http.put(Api.product.default, model);
  }

  getProductsByCategory(id: number) {
    return this.http.get(Api.product.category + id);
  }

  getByProductCode(productCode: string) {
    return this.http.get(Api.product.productCode + productCode);
  }

  getByProductCodeForUpdate(productCode: string) {
    return this.http.get(Api.product.productCodeForUpdate + productCode);
  }

  getAllProducts() {
    return this.http.get(Api.product.default);
  }

  getPromotedProducts() {
    return this.http.get(Api.product.promotion);
  }

  getRelatedProducts(productCode: string) {
    return this.http.get(Api.product.related + productCode);
  }

  getBestSellerProducts() {
    return this.http.get(Api.product.bestSeller);
  }

  getAllProductsAsPagedList(filter: any) {
    return this.http.post(Api.product.getAllAsPagedList, filter);
  }
}
