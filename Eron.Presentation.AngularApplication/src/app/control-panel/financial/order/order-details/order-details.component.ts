import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrderService } from '../../../../website/financial/order/order.service';
import { OrderDetailsModel } from './order-details.model';
import { Common } from '../../../../base/common';
import { NullTemplateVisitor } from '@angular/compiler';
import { NotificationService } from '../../../../base/services/notification.service';
import { OrderAssignDesignPriceModel } from '../order-assign-design-price.model';
import { ViewChild } from '@angular/core';
import { Modal } from 'ngx-modal';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss']
})
export class OrderDetailsComponent implements OnInit {
  model: OrderDetailsModel;
  changeModel: OrderAssignDesignPriceModel;
  orderNumber: string;
  loading = true;
  @ViewChild('assignDesignPriceModal') assignDesignPriceModal: Modal;
  constructor(
    private activatedRoute: ActivatedRoute,
    private orderService: OrderService,
    private notificationService: NotificationService
  ) {

    this.model = {
      user: null,
      invoiceNumber: null
    } as OrderDetailsModel;

    this.changeModel = {} as OrderAssignDesignPriceModel;
    this.activatedRoute.params.subscribe(
      param => {
        this.orderNumber = param['id'];
        this.orderService.getOrderByNumber(this.orderNumber).subscribe(
          (response) => {
            this.model = response;
            this.model.invoiceNumber = this.model.invoiceNumber || null;
            this.model.user = this.model.user || null;
            this.model.imageAddresses = [];
            this.model.imageIds.forEach(x => {
              this.model.imageAddresses.push(Common.getImageAddress(x));
            });
            this.loading = false;
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

  onChangeDesignPrice() {
    this.changeModel.id = this.model.id;
    this.orderService.changeDesignPrice(this.changeModel).subscribe(
      (response) => {
        this.notificationService.successfulOperation('ثبت قیمت طراحی');
        this.assignDesignPriceModal.close();
        this.model.designPrice = this.changeModel.designPrice;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

}
