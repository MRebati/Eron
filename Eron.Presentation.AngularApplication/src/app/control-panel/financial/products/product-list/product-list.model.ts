export interface ProductModel {
  id: number;
  name: string;
  productCode: string;
  images: string[];
  existsInShop: boolean;
  imageAddresses: string[];
  defaultImage: string;
  defaultImageAddress: string;
  properties: ProductPropertyModel[];
  prices: ProductPriceModel[];
  price: number;
  categoryId: number;
  shortDescription: string;
  longDescription: string;
  categoryName: string;
  parentCategories: string[];
}

export interface ProductPropertyModel {
  id: number;
  propertyName: string;
  propertyValue: string;
  productPropertyNameId: number;
}

export interface ProductPriceModel {
  isValid: boolean;
  productId: number;
  price: number;
  description: string;
}
