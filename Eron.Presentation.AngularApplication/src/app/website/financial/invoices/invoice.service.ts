import { Injectable } from '@angular/core';
import { HttpClient } from '../../../base/services/app.http.service';
import { Api } from '../../../base/api';


@Injectable()
export class InvoiceService {
  createReference(invoiceNumber: any): any {
    return this.http.get(Api.invoice.createReference + invoiceNumber);
  }
  constructor(private http: HttpClient) {
  }

  getInvoices() {
    return this.http.get(Api.invoice.default);
  }

  getAllInvoicesAsPagedList(filters: any) {
    return this.http.post(Api.invoice.getAllInvoices, filters);
  }

  getUserInvoices() {
    return this.http.get(Api.invoice.default);
  }

  getUserInvoice(invoiceNumber: string) {
    return this.http.get(Api.invoice.getByNumber);
  }

  createInvoiceForOrders(orderNumbers: string[]) {
    return this.http.post(Api.invoice.postByOrder, orderNumbers);
  }

  createInvoiceForCart() {
    return this.http.post(Api.invoice.postByCart, null);
  }

  createPaymentByBankName(bankName: string, invoiceNumber: string) {
    const dataObj = {
      bankName,
      invoiceNumber
    };
    return this.http.post(Api.invoice.createReference, dataObj);
  }
}
