import { Component, OnInit, OnDestroy } from '@angular/core';
import { TariffCategoryListModel } from './tariff-category-list.model';
import { Subscription } from 'rxjs/Subscription';
import { BreadCrump } from '../../../../base/models/breadCrump.model';
import { PubSubService } from 'angular2-pubsub';
import { NotificationService } from '../../../../base/services/notification.service';
import { TariffCategoryService } from '../tariff-category.service';
import { UrlNamePair } from '../../../../base/models/urlNamePair.model';
import { TariffCategoryOrderModel } from './tariff-category-order.model';

@Component({
  selector: 'tariff-category-list',
  templateUrl: './tariff-category-list.component.html',
  styleUrls: ['./tariff-category-list.component.scss']
})
export class TariffCategoryListComponent implements OnInit, OnDestroy {

  list: TariffCategoryListModel[] = [];
  listSubscriber: Subscription;
  deleteSubscriber: Subscription;
  breadCrump: BreadCrump;
  constructor(
    public subService: PubSubService,
    private notificationService: NotificationService,
    private productCategoryService: TariffCategoryService
  ) {
    this.breadCrump = {
      Title: 'تعرفه ها',
      DarkBackground: true,
      FirstNode: new UrlNamePair('داشبورد', '/controlpanel/dashboard'),
      ThirdNode: new UrlNamePair('مدیریت مجموعه تعرفه ها'),
    } as BreadCrump;

    this.loadList();

    this.listSubscriber = this.subService.$sub('productCategoryCreateSuccess').subscribe(
      (response) => {
        this.onListAddItem(response);
      },
      (error) => {
        this.notificationService.serverError();
        console.log(error);
      }
    );

    this.deleteSubscriber = this.subService.$sub('deleteTariffCategorySuccess').subscribe(
      (response) => {
        this.loadList();
      }
    );
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.listSubscriber.unsubscribe();
    this.deleteSubscriber.unsubscribe();
  }

  onListAddItem(model: TariffCategoryListModel) {
    this.list.push(model);
  }

  onMenuListChanges($event) {
    const model: TariffCategoryOrderModel[] = $event;
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

  loadList() {
    this.productCategoryService.getAll().subscribe(
      (response: TariffCategoryListModel[]) => {
        this.list = response;
      },
      (error) => {
        this.notificationService.serverError();
      }
    );
  }

}
