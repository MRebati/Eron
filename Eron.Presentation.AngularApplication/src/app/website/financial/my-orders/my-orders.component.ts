import { Component, OnInit } from '@angular/core';
import { WebsiteComponent } from '../../website.component';
import { Renderer2 } from '@angular/core';
import { OrderService } from '../order/order.service';
import { MyOrdersListModel } from './my-orders.model';
import { Title } from '@angular/platform-browser';
import { Config } from '../../../app.config';
import { AfterViewInit } from '@angular/core';
import { PubSubService } from 'angular2-pubsub';
import { Subscription } from 'rxjs/Subscription';
import { OnDestroy } from '@angular/core';
import { OrderStatusType } from '../order/order-status.type';
import { InvoiceService } from '../invoices/invoice.service';
import { InvoiceModel } from '../invoices/invoice.model';
import { Router } from '@angular/router';
import { NotificationService } from '../../../base/services/notification.service';

@Component({
  selector: 'app-my-orders',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.scss']
})
export class MyOrdersComponent extends WebsiteComponent implements OnInit {
  totalPrice = 0;
  selectionTotalPrice = 0;
  orderItemList: MyOrdersListModel[] = [];
  filterargs: any = {};
  orderNumberfilterargs: any = {};
  ordertypeFilter: any = '';
  orderNumberFilter: string;
  showCancelButton = false;
  showInvoiceCreateButton = false;
  showUndoCancelButton = false;
  loading: boolean;
  constructor(
    protected renderer: Renderer2,
    private titleService: Title,
    private orderService: OrderService,
    private invoiceService: InvoiceService,
    private subService: PubSubService,
    private router: Router,
    private notificationService: NotificationService
  ) {
    super(renderer);
    this.loading = true;
    this.titleService.setTitle(Config.defaultTitle + 'سفارشات من');
    this.orderService.getUserOrders().subscribe(
      (response) => {
        this.orderItemList = response;
        this.loading = false;
        this.orderItemList.forEach(x => {
          x.selected = false;
          this.totalPrice = this.totalPrice + x.finalPrice;
          if (x.selected) {
            this.selectionTotalPrice = this.selectionTotalPrice + x.finalPrice;
          }
        });
      },
      (error) => {
        this.loading = false;
        this.notificationService.serverError(error);
      }
    );
  }

  ngOnInit() {
  }

  onSubmitInvoice() {
    const selectedItems = this.orderItemList.filter(x => x.selected);
    const idList = selectedItems.map(x => x.orderNumber);
    this.invoiceService.createInvoiceForOrders(idList).subscribe(
      (response: InvoiceModel) => {
        const invoiceNumber = response.invoiceNumber;
        this.notificationService.successfulOperation('صدور فاکتور');
        this.router.navigateByUrl('/invoices');
      },
    (error) => {
      this.loading = false;
      this.notificationService.serverError(error);
    }
    );
    console.log(selectedItems);
  }

  selectionChanged($event) {
    this.selectionTotalPrice = 0;
    this.orderItemList.filter(x => x.selected).forEach(
      x => {
        this.selectionTotalPrice += x.finalPrice;
      }
    );
  }

  onCancelSelection() {
    this.orderService.cancelOrders(this.orderItemList.filter(x => x.selected));
  }

  checkButtons() {

    this.showCancelButton = false;
    this.showInvoiceCreateButton = false;
    this.showUndoCancelButton = false;

    switch (Number.parseInt(this.ordertypeFilter)) {
      case OrderStatusType.NeedInvoice:
        this.showInvoiceCreateButton = true;
        break;

      case OrderStatusType.Received:
        this.showCancelButton = true;
        break;

      case OrderStatusType.Canceled:
        this.showUndoCancelButton = true;
        break;

      case OrderStatusType.CanceledByAdmin:
        break;

      default:
        this.showCancelButton = false;
        this.showInvoiceCreateButton = false;
        this.showUndoCancelButton = false;
        break;
    }
  }

  ngOnFilterChange($event) {
    if ($event === '') {
      this.filterargs = {};
    } else {
      this.filterargs = {
        orderStatus: this.ordertypeFilter
      };
    }

    this.checkButtons();
  }

  ngOnOrderNumberFilterChange($event) {
    if ($event === '') {
      this.orderNumberfilterargs = {};
    } else {
      this.orderNumberfilterargs = {
        orderNumber: this.orderNumberFilter
      };
    }
  }
}
