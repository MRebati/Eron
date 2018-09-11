import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../../../control-panel/financial/products/products.service';
import { ProductModel } from '../../../control-panel/financial/products/product-list/product-list.model';
import { Common } from '../../../base/common';
import { CartService } from '../../financial/cart/cart.service';
import { PubSubService } from 'angular2-pubsub';
import { CartCreateModel } from '../../financial/cart/cart-create/cart-create.model';
import { NotificationService } from '../../../base/services/notification.service';
import { AuthenticationService } from '../../../authentication/auth.service';
import { WishListService } from '../../user/wish-list/wish-list.service';
import { OrderCategoryListModel } from '../../financial/order/order-categories/order-category-list/order-category-list.model';
import { TariffCategoryService } from '../../../control-panel/financial/tariff-category/tariff-category.service';

declare var $: any;

@Component({
  selector: 'app-order-slider',
  templateUrl: './order-slider.component.html',
  styleUrls: ['./order-slider.component.scss']
})
export class OrderSliderComponent implements OnInit {
  categoryList: OrderCategoryListModel[] = [];
  constructor(
    private tariffCategoryService: TariffCategoryService
  ) {
    this.tariffCategoryService.getAll().subscribe(
      (response) => {
        this.categoryList = response;
        this.categoryList.forEach(x => {
          x.imageAddress = Common.getImageAddress(x.imageId);
        });
        $(document).ready(function () {
          $('.order_carousel')
            .owlCarousel({
              itemsCustom: [[320, 1], [600, 2], [768, 3], [992, 5], [1199, 5]],
              lazyLoad: true,
              navigation: true,
              navigationText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
              scrollPerPage: true
            });
        });
      },
      (error) => {
        console.log(error);
      }
    );
  }

  ngOnInit() {
  }
}
