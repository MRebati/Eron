import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InvoiceModel } from '../invoice.model';
import { ShopService } from '../../../../control-panel/financial/shop/shop.service';
import { NotificationService } from '../../../../base/services/notification.service';

@Component({
  selector: 'app-invoice-details',
  templateUrl: './invoice-details.component.html',
  styleUrls: ['./invoice-details.component.scss']
})
export class InvoiceDetailsComponent implements OnInit {
  item: InvoiceModel;
  loading = true;
  constructor(
    public shopService: ShopService,
    private activatedRoute: ActivatedRoute,
    private notificationService: NotificationService
  ) {
    this.item = {} as InvoiceModel;
    this.activatedRoute.params.subscribe(
      param => {
        const invoiceNumber = param['id'];
        shopService.getInvoiceByNumber(invoiceNumber).subscribe(
          (response) => {
            this.loading = false;
            this.item = response;
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
}
