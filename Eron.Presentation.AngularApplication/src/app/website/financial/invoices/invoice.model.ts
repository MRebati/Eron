import { InvoiceItemModel } from './invoiceItem.model';
import { InvoiceType } from '../../../base/types/Invoice.type';

export interface InvoiceModel {
  id: number;
  expireDateTime: Date;
  expired: boolean;
  paid: boolean;
  amount: number;
  referenceId: string;
  invoiceNumber: string;
  invoiceItems: InvoiceItemModel[];
  totalCount: number;
  progress: number;
  progressString: string;
  type: InvoiceType;
  selected: boolean;
}
