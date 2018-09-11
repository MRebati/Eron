export interface InvoiceItemModel {
  id: number;
  count: number;
  description: string;
  orderId?: string;
  cartItemId?: number;
  productPriceId?: string;
  tariffPriceId?: string;
  invoiceId: number;
}
