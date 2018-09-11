import { ProductModel } from '../../../control-panel/financial/products/product-list/product-list.model';

export interface WishListItemModel {
  id: number;
  userId: string;
  isSold: boolean;
  productId: number;
  product: ProductModel;
}
