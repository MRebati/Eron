import { ProductModel } from '../../control-panel/financial/products/product-list/product-list.model';
import { TariffCategoryDetailsModel } from '../../control-panel/financial/tariff-category/tariff-category-details/tariff-category-details.model';
import { Tariff } from '../../control-panel/financial/tariff/tariff.model';
import { PageListModel } from '../../control-panel/base/page/page-list/page-list.model';
import { ProductCategoryModel } from '../financial/products/product.model';

export interface SearchResponseModel {
  productCategories: ProductCategoryModel[];
  products: ProductModel[];
  tariffCategories: TariffCategoryDetailsModel[];
  tariffs: Tariff[];
  pages: PageListModel[];
}
