export interface ProductUpdateModel {
  id: number;
  productName: string;
  productPrice: string;
  productCode: string;
  productCategoryId: number;
  shortDescription: string;
  longDescription: string;
  properties: any[];
  images: any[];
  defaultImage: string;
  existsInShop: boolean;
}
