import { Component, OnInit } from '@angular/core';
import { SelectListService } from '../../../infrastructure/services/selectList.service';
import { CommonService } from '../../../infrastructure/services/common.service';
import { ServerDataSource } from 'ng2-smart-table/lib/data-source/server/server.data-source';
import { Http } from '@angular/http';
import { Api } from '../../../../base/api';
import { LocalDataSource } from 'ng2-smart-table/lib/data-source/local/local.data-source';
import { OrderService } from '../../../../website/financial/order/order.service';
import { OrderListRequestModel } from './order-list.model';
import { DatePeriodType } from '../../../../base/types/DatePeriod.type';
import { OrderStatusType } from '../../../../website/financial/order/order-status.type';
import { NotificationService } from '../../../../base/services/notification.service';
import { ViewChild } from '@angular/core';
import { Modal } from 'ngx-modal';

declare var $: any;
@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent implements OnInit {
  defaultPageSize = 20;
  pageNumber = 1;
  filter: OrderListRequestModel;
  orderNumberfilterargs: any = {};
  orderItemList: any = {};
  orderStatusChangeId: number;
  orderStatusChangeDescription: string;
  @ViewChild(Modal) changeStatusModal;
  constructor(
    private commonService: CommonService,
    private notificationService: NotificationService,
    private orderService: OrderService) {

    this.filter = {
      datePeriod: DatePeriodType.Day,
      pageSize: this.defaultPageSize,
      pageNumber: this.pageNumber,
    } as OrderListRequestModel;
    this.orderService.getAllOrders(this.filter).subscribe(
      (response) => {

        this.orderItemList = response;

        $(document).ready(function () {
          $('span.pie').peity('pie', {
            fill: ['#1ab394', '#d7d7d7', '#ffffff']
          });
        });
        // this.source.load(response);
      }
    );
  }

  ngOnInit() {
  }

  onOrderNumberFilterChange() {
    this.onFilterChange();
  }

  onOrderStatusFilterChange() {
    this.onFilterChange();
  }

  onDatePeriodFilterChange(datePeriod: number) {
    this.filter.datePeriod = datePeriod;
    this.onFilterChange();
  }

  onFilterChange() {
    this.orderService.getAllOrders(this.filter).subscribe(
      (response) => {

        this.orderItemList = response;

        // $(document).ready(function () {
        //   $('span.pie').peity('pie', {
        //     fill: ['#1ab394', '#d7d7d7', '#ffffff']
        //   });
        // });
      }
    );
  }

  onPageChange($event) {
    this.filter.pageNumber = $event;
    this.pageNumber = $event;
    this.onFilterChange();
  }

  onOrderStatusChange() {
    const model = {
      orders: this.orderItemList.result.filter(x => x.selected).map(x => x.orderNumber),
      orderStatus: this.orderStatusChangeId,
      description: this.orderStatusChangeDescription
    };

    this.orderService.changeStateOfOrderList(model).subscribe(
      (response) => {
        this.notificationService.successfulOperation('تغییر وضعیت فاکتور (های) انتخابی');
        this.changeStatusModal.close();
        this.onFilterChange();
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }
}
