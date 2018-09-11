import { ProductModel } from '../../products/product-list/product-list.model';

export interface ProductCategoryListModel {
  id?: number;
  title?: string;
  description?: string;
  keywords?: string;
  parentId?: number;
  children: ProductCategoryListModel[];
  products: ProductModel[];
}
