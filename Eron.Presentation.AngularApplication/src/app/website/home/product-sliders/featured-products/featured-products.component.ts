import { Component, OnInit } from '@angular/core';
import { AfterViewInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { ProductCategoryService } from '../../../../control-panel/financial/product-category/product-category.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { Common } from '../../../../base/common';
import { ProductCategoryListModel } from '../../../../control-panel/financial/product-category/product-category-list/product-category-list.model';
import { ProductModel } from '../../../../control-panel/financial/products/product-list/product-list.model';
import { PubSubService } from 'angular2-pubsub';
import { CartService } from '../../../financial/cart/cart.service';
import { CartCreateModel } from '../../../financial/cart/cart-create/cart-create.model';
import { AuthenticationService } from '../../../../authentication/auth.service';

declare var $: any;

@Component({
  selector: 'app-featured-products',
  templateUrl: './featured-products.component.html',
  styleUrls: ['./featured-products.component.scss']
})
export class FeaturedProductsComponent implements OnInit, AfterViewInit {

  categories: ProductCategoryListModel[] = [];

  constructor(
    private productCategoryService: ProductCategoryService,
    private notificationService: NotificationService,
    private cartService: CartService,
    private pubService: PubSubService,
    private authService: AuthenticationService
  ) {
    productCategoryService.getHomePageCategories().subscribe(
      (response) => {
        this.categories = response;

        this.categories.forEach(item => {
          item.products.forEach(product => {
            product.defaultImageAddress = Common.getImageAddress(product.defaultImage);
          });

          const category = item;
          $(document).ready(function () {

            $('.latest_category_carousel-' + category.id).each(function () {
              const that = $(this);
              $(that).owlCarousel({
                itemsCustom: [[320, 1], [600, 2], [768, 3], [992, 5], [1199, 5]],
                lazyLoad: true,
                navigation: true,
                navigationText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
                scrollPerPage: true
              });
            });
          });
        });


      },
      (error) => {
        console.log(error);
        notificationService.serverError();
      }
    );
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
  }

  onAddToCart(model: ProductModel) {
    const authenticated = this.authService.isAuthenticated();
    if (!authenticated) {
      this.pubService.$pub('openLoginModal');
    } else {
      const itemExists = this.cartService.itemExists(model.id);
      if (!itemExists) {
        this.pubService.$pub('cartItemCreateProcessBegin');
        this.cartService.createItem({
          productId: model.id
        } as CartCreateModel)
          .subscribe(
          (response) => {
            this.pubService.$pub('cartItemCreatedSuccessfully', response);
          },
          (error) => {
            console.log(error);
            this.notificationService.serverError();
          }
          );
      } else {
        this.notificationService.duplicationRestriction('امکان ثبت مجدد آیتم در سبد وجود ندارد',
          'آیتم انتخابی قبلا در سبد خرید شما درج شده، امکان ثبت مجدد آن مقدور نمی باشد');
      }
    }
  }
}
