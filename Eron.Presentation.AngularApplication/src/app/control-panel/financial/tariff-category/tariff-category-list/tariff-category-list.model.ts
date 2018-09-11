export interface TariffCategoryListModel {
  id?: number;
  title?: string;
  description?: string;
  keywords?: string;
  slug?: string;
  parentId?: number;
  children: TariffCategoryListModel[];
}
