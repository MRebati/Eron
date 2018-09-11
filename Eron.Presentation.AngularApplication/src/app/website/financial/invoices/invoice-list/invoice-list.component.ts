import { Component, OnInit } from '@angular/core';
import { InvoiceModel } from '../invoice.model';
import { InvoiceService } from '../invoice.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { Title } from '@angular/platform-browser';
import { Config } from '../../../../app.config';
import * as moment from 'moment';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html',
  styleUrls: ['./invoice-list.component.scss']
})
export class InvoiceListComponent implements OnInit {
  currentDate = new Date();
  p: any;
  invoiceStatusFilter: any;
  invoiceNumberfilterargs: any = {};
  invoiceNumberFilter: string;
  filterargs: any = {};
  invoiceItemList: InvoiceModel[] = [];
  constructor(
    private invoiceService: InvoiceService,
    private notificationService: NotificationService,
    private titleService: Title
  ) {

    this.titleService.setTitle(Config.defaultTitle + 'فاکتور ها');

    invoiceService.getUserInvoices().subscribe(
      (response) => {
        this.invoiceItemList = response;
      },
      (error) => {
        notificationService.serverError(error);
      }

    );
  }

  ngOnInit() {
    console.log(this.currentDate);
  }

  ngOnFilterChange($event) {
    if ($event === '') {
      this.filterargs = {};
    } else {
      const invoicetype = Number.parseInt($event);
      switch (invoicetype) {
        case 1:
          this.filterargs = {
            paid: true
          };
          break;

        case 2:
          this.filterargs = {
            paid: false
          };
          break;

        case 3:
          this.filterargs = {
            expired: true
          };
          break;
      }
    }
  }

  ngOnInvoiceNumberFilterChange($event) {
    if ($event === '') {
      this.invoiceNumberfilterargs = {};
    } else {
      this.invoiceNumberfilterargs = {
        invoiceNumber: this.invoiceNumberFilter
      };
    }
  }

  isExpired(invoice: InvoiceModel) {
    // your date logic here, recommend moment.js;
    return moment(invoice.expireDateTime).isBefore(moment(this.currentDate));
    // // or without using moment.js:
    // return invoice.expireDateTime.getTime() < this.currentDate.getTime();
    // // or using Date
    // return new Date(invoice.expireDateTime).valueOf() < new Date(this.currentDate).valueOf();
  }

}
