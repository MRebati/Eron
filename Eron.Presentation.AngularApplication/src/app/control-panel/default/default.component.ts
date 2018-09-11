import { Component, OnInit, AfterViewInit, AfterViewChecked } from '@angular/core';
import { SelectListItem } from '../../base/models/SelectList.model';
import { SelectListService } from '../infrastructure/services/selectList.service';
import { NotificationService } from '../../base/services/notification.service';
import { InvoiceModel } from '../../website/financial/invoices/invoice.model';
import { PagedListResult } from '../../base/models/PagedListResponse.model';
import { InvoiceService } from '../../website/financial/invoices/invoice.service';
import { Subscription } from 'rxjs/Subscription';
import { InsightsService } from '../../base/services/insights.service';

declare var $: any;

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'default',
  templateUrl: './default.component.html',
  styleUrls: ['./default.component.scss']
})

export class DefaultComponent implements OnInit, AfterViewInit {
  financialDashboard: boolean;

  constructor() {
    this.financialDashboard = false;
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
  }
}
