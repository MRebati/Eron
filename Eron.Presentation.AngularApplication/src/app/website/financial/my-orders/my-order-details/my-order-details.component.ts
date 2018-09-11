import { Component, OnInit, ViewChild } from '@angular/core';
import { OrderDetailsModel } from '../../../../control-panel/financial/order/order-details/order-details.model';
import { OrderAssignDesignPriceModel } from '../../../../control-panel/financial/order/order-assign-design-price.model';
import { Modal } from 'ngx-modal';
import { ActivatedRoute } from '@angular/router';
import { OrderService } from '../../order/order.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { Common } from '../../../../base/common';

@Component({
  selector: 'app-my-order-details',
  templateUrl: './my-order-details.component.html',
  styleUrls: ['./my-order-details.component.scss']
})
export class MyOrderDetailsComponent implements OnInit {
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
