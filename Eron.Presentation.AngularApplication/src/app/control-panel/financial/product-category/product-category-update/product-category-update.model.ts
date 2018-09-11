export interface ProductCategoryUpdateModel {
  id: number;
  title: string;
  description: string;
  slug: string;
  keywords: string;
  promoted: boolean;
  viewOnHomePage: boolean;
}
