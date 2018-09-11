import { Component, OnInit, Renderer2 } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Common } from '../../../../base/common';

import { WebsiteComponent } from '../../../website.component';

import { TariffService } from '../../../../control-panel/financial/tariff/tariff.service';
import { TariffCategoryService } from '../../../../control-panel/financial/tariff-category/tariff-category.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { OrderService } from '../order.service';
import { SelectListService } from '../../../../control-panel/infrastructure/services/selectList.service';
import { SelectList } from '../../../../control-panel/infrastructure/models/selectList.model';
import { EronFile } from '../../../../base/models/EronFile.model';
import { FileService } from '../../../../base/services/file.service';
import { OrderItemCreateModel } from './order-item.model';
import { OrderCategoryListModel } from '../order-categories/order-category-list/order-category-list.model';
import { OrderClientListModel } from '../order-list/order-list.model';
import { Title } from '@angular/platform-browser';
import { Config } from '../../../../app.config';
import { AuthenticationService } from '../../../../authentication/auth.service';
import { TariffUnitType } from '../../../../base/types/TariffUnit.type';
import { PubSubService } from 'angular2-pubsub';


@Component({
  selector: 'app-order-item',
  templateUrl: './order-item.component.html',
  styleUrls: ['./order-item.component.scss']
})
export class OrderItemComponent extends WebsiteComponent implements OnInit {
  categoryId: number;
  category: OrderCategoryListModel;
  tariff: OrderClientListModel;
  tariffId: number;
  tariffTypes: any[];
  fileList: EronFile[] = [];
  loading = true;
  hasDesignRequest = false;
  power = 1;
  finalPrice = 0;
  quantity = 1;
  authenticated: boolean;
  orderModel: OrderItemCreateModel;
  constructor(
    protected renderer: Renderer2,
    private activatedRoute: ActivatedRoute,
    private tariffService: TariffService,
    private tariffCategoryService: TariffCategoryService,
    private notificationService: NotificationService,
    private selectListService: SelectListService,
    private fileService: FileService,
    private orderService: OrderService,
    private router: Router,
    private titleService: Title,
    private authService: AuthenticationService,
    private pubSubService: PubSubService
  ) {
    super(renderer);

    this.titleService.setTitle(Config.application.name + ' | ' + 'سفارش دهید');
    this.authenticated = authService.isAuthenticated();
    this.category = {} as OrderCategoryListModel;
    this.tariff = {} as OrderClientListModel;

    //#region orderModel set

    this.orderModel = {} as OrderItemCreateModel;
    this.orderModel.imageIds = [];
    this.orderModel.count = 1;

    //#endregion orderModel set

    this.activatedRoute.params.subscribe(
      param => {
        this.tariffId = param.id;
        this.selectListService.getSelectList('TariffItemType').subscribe(
          (tariffItemType) => {
            this.tariffTypes = tariffItemType;
            this.tariffService.getById(this.tariffId).subscribe(
              (response) => {
                this.tariff = response;
                this.tariff.slug = this.tariff.tariffName.replace(' ', '-');
                this.tariff.slug = this.tariff.tariffName.replace('--', '-');
                this.tariff.slug = this.tariff.tariffName.replace('--', '-');
                this.tariff.imageAddress = Common.getImageAddress(this.tariff.imageId);
                this.finalPrice = this.tariff.tariffPrice * this.orderModel.count;
                this.orderModel.tariffId = this.tariff.id;
                this.checkTariffUnits();

                this.tariffCategoryService.get(this.tariff.categoryId).subscribe(
                  (response2) => {
                    this.category = response2;
                    this.categoryId = this.category.id;
                    this.loading = false;
                  }
                );
              }
            );
          }
        );

      });
  }

  ngOnInit() {
  }

  onSubmit() {
    if (!this.authenticated) {
      this.pubSubService.$pub('openLoginModal');
    } else {
      if (this.fileList.length === 0) {
        this.notificationService.warningWithAlert('فایلی انتخاب نشده است', 'لطفا فایل طرح خود را آپلود کرده و مجددا تلاش نمائید');
      } else {

        this.orderService.createOrder(this.orderModel).subscribe(
          (response) => {
            this.notificationService.successfulOperation('ثبت سفارش');
            this.notificationService.info('برای پرداخت و پیگیری وضعیت سفارش خود به بخش سفارشات من در بالای صفحه مراجعه کنید', 'توجه!');
            this.router.navigateByUrl('/orders');
          },
          (error) => {
            this.notificationService.serverError(error);
          }
        );
      }
    }
  }

  onAddQuantity() {
    this.orderModel.count++;
    this.quantity = this.orderModel.count * this.power;
    this.updatePrice();
  }

  onReduceQuantity() {
    if (this.orderModel.count !== 1) {
      this.orderModel.count--;
      this.quantity = this.orderModel.count * this.power;
      this.updatePrice();
    }
  }

  onDesignRequest() {
    this.hasDesignRequest = true;
  }

  onOrderDesignChange() {
    if (this.orderModel.hasDesignOrder) {
      this.finalPrice += this.tariff.designPrice;
      this.orderModel.designPrice = this.tariff.designPrice;
    } else {
      this.finalPrice -= this.tariff.designPrice;
      this.orderModel.designPrice = 0;
    }
  }

  checkDesignOrder() {
    if (this.orderModel.hasDesignOrder) {
      this.finalPrice += this.tariff.designPrice;
      this.orderModel.designPrice = this.tariff.designPrice;
    }
  }

  updatePrice() {
    this.finalPrice = this.tariff.tariffPrice * this.orderModel.count;
    this.checkDesignOrder();
  }

  onUploadSuccess($event) {
    $event[1].forEach(item => {
      const newFile = {
        name: item.fileName,
        id: item.id,
        imageAddress: Common.getImageAddress(item.id)
      } as EronFile;
      this.fileList.push(newFile);
      this.orderModel.imageIds.push(item.id);
      if (this.fileList.length === 1) {
        this.fileList[0].selected = true;
      }
    });
  }

  onUploadError($event) {
    console.log($event);
  }

  onRemoveFile($event) {
    const index = this.fileList.findIndex(x => x.name === $event.name);
    const currentRow = this.fileList[index];
    const orderModelImagesIndex = this.orderModel.imageIds.findIndex(x => x === currentRow.id);

    this.fileService.deleteFile(currentRow.id);

    this.fileList.splice(index, 1);
    this.orderModel.imageIds.splice(orderModelImagesIndex, 1);
  }

  private checkTariffUnits() {
    this.tariff.tariffItems.forEach(
      x => {
        // 3 = تعداد
        if (x.tariffItemType === 3) {
          this.power = Number.parseInt(x.name);
          this.quantity = this.power * this.orderModel.count;
        }

        x.typeName = this.tariffTypes.find(z => z.value === x.tariffItemType.toString()).title;
      }
    );

    switch (this.tariff.unitType) {
      case TariffUnitType.Kilo:
        this.tariff.unitTypeTitle = 'کیلو';
        break;
      case TariffUnitType.Meter:
        this.tariff.unitTypeTitle = 'متر';
        break;
      case TariffUnitType.Number:
        this.tariff.unitTypeTitle = 'تعداد';
        break;
    }
  }
}
