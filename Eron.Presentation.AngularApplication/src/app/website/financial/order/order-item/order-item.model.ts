export interface OrderItemCreateModel {
  tariffId: number;
  count: number;
  imageIds: string[];
  hasDesignOrder: boolean;
  designPrice: number;
  description: string;
}
