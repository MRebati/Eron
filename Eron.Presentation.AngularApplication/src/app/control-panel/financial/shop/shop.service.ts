import { Injectable } from '@angular/core';
import { HttpClient } from '../../../base/services/app.http.service';
import { Api } from '../../../base/api';
import { InvoiceModel } from '../../../website/financial/invoices/invoice.model';

@Injectable()
export class ShopService {
  /**
   *
   */
  constructor(
    public http: HttpClient
  ) {
  }

  currentInvoiceItem: InvoiceModel;

  getAllProductInvoices(filter: any) {
    return this.http.post(Api.invoice.getProductInvoices, filter);
  }

  getInvoiceByNumber(invoiceNumber: string) {
    return this.http.get(Api.invoice.getByNumber + invoiceNumber);
  }

  getInvoiceByNumberAsAdmin(invoiceNumber: string) {
    return this.http.get(Api.invoice.getByNumberAsAdmin + invoiceNumber);
  }

  updateStateOfInvoiceList(model: any) {
    return this.http.post(Api.invoice.updateStateOfInvoiceList, model);
  }
}
