import { Component, OnInit } from '@angular/core';
import { BreadCrump } from '../../../../base/models/breadCrump.model';
import { UrlNamePair } from '../../../../base/models/urlNamePair.model';
import { Subscription } from 'rxjs/Subscription';
import { PubSubService } from 'angular2-pubsub';
import { OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';
import { NotificationService } from '../../../../base/services/notification.service';
import { ProductCategoryListModel } from './product-category-list.model';
import { ProductCategoryService } from '../product-category.service';
import { ProductCategoryOrderModel } from './product-category-order.model';

@Component({
  selector: 'product-category-list',
  templateUrl: './product-category-list.component.html',
  styleUrls: ['./product-category-list.component.scss']
})
export class ProductCategoryListComponent implements OnInit, OnDestroy {
  list: ProductCategoryListModel[] = [];
  listSubscriber: Subscription;
  deleteSubscriber: Subscription;
  breadCrump: BreadCrump;
  constructor(
    private subService: PubSubService,
    private notificationService: NotificationService,
    private productCategoryService: ProductCategoryService
  ) {
    this.breadCrump = {
      Title: 'محصولات',
      DarkBackground: true,
      FirstNode: new UrlNamePair('داشبورد', '/controlpanel/dashboard'),
      ThirdNode: new UrlNamePair('مدیریت مجموعه محصولات'),
    } as BreadCrump;

    this.productCategoryService.getAll().subscribe(
      (response: ProductCategoryListModel[]) => {
        this.list = response;
      },
      (error) => {
        this.notificationService.serverError();
      }
    );

    this.listSubscriber = this.subService.$sub('productCategoryCreateSuccess').subscribe(
      (response) => {
        this.onListAddItem(response);
      },
      (error) => {
        this.notificationService.serverError();
        console.log(error);
      }
    );

    this.deleteSubscriber = this.subService.$sub('deleteProductCategorySuccess').subscribe(
      (response) => {
        console.log(response);
        this.productCategoryService.getAll().subscribe(
          (response2: ProductCategoryListModel[]) => {
            this.list = response;
          },
          (error) => {
            this.notificationService.serverError();
          }
        );
      }
    );
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.listSubscriber.unsubscribe();
  }

  onListAddItem(model: ProductCategoryListModel) {
    this.list.push(model);
  }

  onMenuListChanges($event) {
    const model: ProductCategoryOrderModel[] = $event;
    this.productCategoryService.reOrderItems(model).subscribe(
      (response) => {
        this.notificationService.successfulOperation('تغییرات مجموعه ها');
      },
      (error) => {
        this.notificationService.serverError();
        console.log(error);
      }
    );
  }
}
