import { Component, OnInit } from '@angular/core';
import { SelectListService } from '../../../infrastructure/services/selectList.service';
import { CommonService } from '../../../infrastructure/services/common.service';
import { ShopService } from '../shop.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { PagedListResult } from '../../../../base/models/PagedListResponse.model';
import { InvoiceModel } from '../../../../website/financial/invoices/invoice.model';
import { DatePeriodType } from '../../../../base/types/DatePeriod.type';
import { SelectListItem } from '../../../../base/models/SelectList.model';
import { BreadCrump } from '../../../../base/models/breadCrump.model';
import { UrlNamePair } from '../../../../base/models/urlNamePair.model';
import { Modal } from 'ngx-modal';
import { ViewChild } from '@angular/core';


declare var $: any;
@Component({
  selector: 'app-shop-list',
  templateUrl: './shop-list.component.html',
  styleUrls: ['./shop-list.component.scss']
})
export class ShopListComponent implements OnInit {
  @ViewChild(Modal) changeStatusModal;
  pageSize = 20;
  filter: any = {
    invoiceStatus: 1,
    pageSize: this.pageSize,
    datePeriod: 0,
    pageNumber: 1
  };
  invoiceStatusList: SelectListItem[] = [];
  invoiceItemList: PagedListResult<InvoiceModel>;
  selection: InvoiceModel[] = [];
  breadCrump: BreadCrump;
  InvoiceStatusChangeDescription: string;
  InvoiceStatusChangeId: number;
  constructor(
    private selectListService: SelectListService,
    public shopService: ShopService,
    private notificationService: NotificationService
  ) {

    this.breadCrump = {
      Title: 'فروشگاه',
      DarkBackground: true,
      FirstNode: new UrlNamePair('داشبورد', '/controlpanel/dashboard'),
      ThirdNode: new UrlNamePair('مدیریت فروشگاه')
    } as BreadCrump;

    this.selectListService.getSelectList('InvoiceStatusType').subscribe(
      (response) => {
        this.invoiceStatusList = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );

    this.invoiceItemList = {
      result: []
    } as PagedListResult<InvoiceModel>;

    this.loadInvoiceItems();
  }

  ngOnInit() {
  }

  onPageChange($event) {
    this.filter.pageNumber = $event;
    this.loadInvoiceItems();
  }

  onDatePeriodFilterChange(datePeriodType: DatePeriodType) {
    this.filter.datePeriod = datePeriodType;
    this.loadInvoiceItems();
  }

  onInvoiceStatusFilterChange() {
    this.loadInvoiceItems();
  }

  onInvoiceNumberFilterChange() {
    this.loadInvoiceItems();
  }

  selectionChanged() {
    this.selection = this.invoiceItemList.result.filter(x => x.selected);
  }

  loadInvoiceItems() {
    this.shopService.getAllProductInvoices(this.filter).subscribe(
      (response) => {
        this.invoiceItemList = response;
        this.selection = [];
        $(document).ready(function () {
          $('span.pie').peity('pie', {
            fill: ['#1ab394', '#d7d7d7', '#ffffff']
          });
        });
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  onInvoiceStatusChange() {
    const model = {
      invoices: this.invoiceItemList.result.filter(x => x.selected).map(x => x.invoiceNumber),
      invoiceStatus: this.InvoiceStatusChangeId,
      description: this.InvoiceStatusChangeDescription
    };
    this.shopService.updateStateOfInvoiceList(model).subscribe(
      (response) => {
        this.notificationService.successfulOperation('تغییر وضعیت فاکتور (های) انتخابی');
        this.changeStatusModal.close();
        this.loadInvoiceItems();
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

}
