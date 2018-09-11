import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../../../../control-panel/financial/products/products.service';
import { ProductModel } from '../../../../control-panel/financial/products/product-list/product-list.model';
import { Common } from '../../../../base/common';
import { CartService } from '../../../financial/cart/cart.service';
import { PubSubService } from 'angular2-pubsub';
import { CartCreateModel } from '../../../financial/cart/cart-create/cart-create.model';
import { NotificationService } from '../../../../base/services/notification.service';
import { AuthenticationService } from '../../../../authentication/auth.service';
import { WishListService } from '../../../user/wish-list/wish-list.service';

declare var $: any;

@Component({
  selector: 'app-best-selling-products',
  templateUrl: './best-selling-products.component.html',
  styleUrls: ['./best-selling-products.component.scss']
})
export class BestSellingProductsComponent implements OnInit {
  productList: ProductModel[];
  constructor(
    private productService: ProductsService,
    private cartService: CartService,
    private pubService: PubSubService,
    private notificationService: NotificationService,
    private authService: AuthenticationService,
    private wishListService: WishListService
  ) {
    this.productService.getAllProducts().subscribe(
      (response) => {
        this.productList = response;
        this.productList.forEach(x => {
          x.defaultImageAddress = Common.getImageAddress(x.defaultImage);
        });
        $(document).ready(function () {
          $('.product_carousel')
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

  onAddToWishList(item) {
    this.wishListService.create(item.id).subscribe(
      (response) => {
        this.notificationService.successfulOperationWithAlert('عملیات موفق', 'افزودن محصول به لیست علاقه مندی موفقیت آمیز بود.');
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

}
