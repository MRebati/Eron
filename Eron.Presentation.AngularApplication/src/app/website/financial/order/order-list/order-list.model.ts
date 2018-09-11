import { TariffUnitType } from '../../../../base/types/TariffUnit.type';

export interface OrderClientListModel {
  id: number;
  tariffName: string;
  slug: string;
  tariffItems: any[];
  imageId: string;
  imageAddress: string;
  tariffPrice: number;
  categoryId: number;
  unitType: TariffUnitType;
  unitTypeTitle: string;
  designPrice: number;
}
