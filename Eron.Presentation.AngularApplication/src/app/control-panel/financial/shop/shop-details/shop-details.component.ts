import { Component, OnInit, Input } from '@angular/core';
import { InvoiceModel } from '../../../../website/financial/invoices/invoice.model';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { NotificationService } from '../../../../base/services/notification.service';

@Component({
  selector: 'app-shop-details',
  templateUrl: './shop-details.component.html',
  styleUrls: ['./shop-details.component.scss']
})
export class ShopDetailsComponent implements OnInit {
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
        shopService.getInvoiceByNumberAsAdmin(invoiceNumber).subscribe(
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
