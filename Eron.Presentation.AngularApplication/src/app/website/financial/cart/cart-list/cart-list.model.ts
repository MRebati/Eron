export interface CartListModel {
  id: number;
  productId: number;
  productName: string;
  count: number;
  productPrice: number;
  productImage: string;
  productImageAddress: string;
  productCode: string;
  userId: string;
  isSold: boolean;
  isLocal: boolean;
}
