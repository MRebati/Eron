import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { InvoiceModel } from '../invoice.model';
import { ShopService } from '../../../../control-panel/financial/shop/shop.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { SelectListItem } from '../../../../base/models/SelectList.model';
import { SelectListService } from '../../../../control-panel/infrastructure/services/selectList.service';
import { InvoiceService } from '../invoice.service';

@Component({
  selector: 'app-invoice-payment-send',
  templateUrl: './invoice-payment-send.component.html',
  styleUrls: ['./invoice-payment-send.component.scss']
})
export class InvoicePaymentSendComponent implements OnInit {
  item: InvoiceModel;
  banks: SelectListItem[] = [];
  loading = true;
  invoiceNumber: string;
  bankName = '';
  loadingBank: boolean;
  bankUrl: string;
  bankRefId: string;
  constructor(
    public shopService: ShopService,
    private invoiceService: InvoiceService,
    private activatedRoute: ActivatedRoute,
    private notificationService: NotificationService,
    private selectListService: SelectListService
  ) {
    this.item = {} as InvoiceModel;
    this.activatedRoute.params.subscribe(
      param => {
        this.invoiceNumber = param['id'];
        shopService.getInvoiceByNumber(this.invoiceNumber).subscribe(
          (response) => {

            this.item = response;
            this.selectListService.getSelectList('BankNameType').subscribe(
              (bankSelectResponse) => {
                this.banks = bankSelectResponse;
                this.loading = false;
              }
            );
          },
          (error) => {
            this.notificationService.serverError(error);
          }
        );
      }
    );
  }

  ngOnInit() {

  }

  sendToBank() {
    this.invoiceService.createReference(this.invoiceNumber).subscribe(
      (response) => {
        this.bankRefId = response;
        console.log(this.bankRefId);
        // window.location.href = this.bankRefId;
        if (response.hasError) {
          this.notificationService.error(response.error, 'مشکلی پیش آمده');
        } else {
          window.location.href = response.response;
        }
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
