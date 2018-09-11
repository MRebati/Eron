export interface ProductCreateModel {
  productName: string;
  productPrice: string;
  productCode: string;
  productCategoryId: number;
  shortDescription: string;
  longDescription: string;
  properties: any[];
  images: any[];
  defaultImage: string;
}
