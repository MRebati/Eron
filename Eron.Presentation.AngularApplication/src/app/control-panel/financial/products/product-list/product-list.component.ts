import { Component, OnInit } from '@angular/core';
import { CommonService } from '../../../infrastructure/services/common.service';
import { BreadCrump } from '../../../../base/models/breadCrump.model';
import { UrlNamePair } from '../../../../base/models/urlNamePair.model';
import { Button } from '../../../../base/models/button.model';
import { ServerDataSource } from 'ng2-smart-table/lib/data-source/server/server.data-source';
import { Http } from '@angular/http';
import { Api } from '../../../../base/api';
import { ProductModel } from './product-list.model';
import { PagedListResult } from '../../../../base/models/PagedListResponse.model';
import { Config } from '../../../../app.config';
import { ProductsService } from '../products.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { setTimeout, setInterval } from 'core-js/library/web/timers';
import { PubSubService } from 'angular2-pubsub';

@Component({
  selector: 'product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  breadCrump: BreadCrump;
  productItemList: PagedListResult<ProductModel>;
  filter: any;

  defaultPageSize = 20;
  pageNumber = 1;
  loadSubscriber: Subscription;
  deleteSubscription: Subscription;
  constructor(
    private productService: ProductsService,
    private notificationService: NotificationService,
    private router: Router,
    private pubSubService: PubSubService
  ) {

    //#region BreadCrump

    this.breadCrump = {
      Title: 'محصولات',
      DarkBackground: true,
      FirstNode: new UrlNamePair('داشبورد', '/controlpanel/dashboard'),
      SecondNode: new UrlNamePair('مدیریت محصولات'),
      ThirdNode: new UrlNamePair('لیست همه'),
      Button: [
        {
          ButtonText: 'ثبت محصول جدید',
          ButtonClass: 'btn btn-success btn-outline',
          ButtonIconClass: 'fa fa-save',
          Url: '/controlpanel/products/create'
        } as Button
      ]
    } as BreadCrump;

    //#endregion BreadCrump

    this.productItemList = {
      result: []
    } as PagedListResult<ProductModel>;

    this.filter = {
      pageSize: this.defaultPageSize,
      pageNumber: this.pageNumber,
      availability: '',
      productName: '',
      productCode: ''
    };

    this.loadProductList();

    //#region Delete Subscription

    this.deleteSubscription = this.pubSubService.$sub('deleteSuccess').subscribe(
      (response) => {
        this.loadProductList();
      }
    );

    //#endregion
  }

  ngOnInit() {
  }

  loadProductList() {
    this.loadSubscriber = this.productService.getAllProductsAsPagedList(this.filter).subscribe(
      (response) => {
        this.productItemList = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  onUpdate(item: ProductModel) {
    this.router.navigateByUrl('/controlpanel/products/update/' + item.productCode);
  }

  onDelete(item: ProductModel) {
    this.notificationService.deleteConfirmationAlert(
      'محصول کد' + item.productCode,
      item.id,
      Api.product.default,
      'deleteSuccess');
  }

  onPageChange($event) {
    this.filter.pageNumber = $event;
    this.pageNumber = $event;

    if (typeof (this.loadSubscriber) !== 'undefined') {
      this.loadSubscriber.unsubscribe();
    }
    this.loadProductList();
  }

  onFilterChange() {
    if (typeof (this.loadSubscriber) !== 'undefined') {
      this.loadSubscriber.unsubscribe();
    }
    setTimeout(this.loadProductList(), 20000);
  }
}
