import { Component, OnInit, Renderer2 } from '@angular/core';
import { WebsiteComponent } from '../../website.component';
import { ActivatedRoute } from '@angular/router';
import { ProductsService } from '../../../control-panel/financial/products/products.service';
import { ProductModel } from '../../../control-panel/financial/products/product-list/product-list.model';
import { Api } from '../../../base/api';
import { Common } from '../../../base/common';
import { CartService } from '../cart/cart.service';
import { CartCreateModel } from '../cart/cart-create/cart-create.model';
import { PubSubService } from 'angular2-pubsub';
import { NotificationService } from '../../../base/services/notification.service';
import { Config } from '../../../app.config';
import { AuthenticationService } from '../../../authentication/auth.service';
import { WishListService } from '../../user/wish-list/wish-list.service';

declare var $: any;

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent extends WebsiteComponent implements OnInit {
  applicationName: string;
  promotedProducts: ProductModel[] = [];
  relatedProducts: ProductModel[] = [];
  bestSellerProducts: ProductModel[] = [];
  productCode: string;
  model: ProductModel;
  count = 1;
  loadingProduct = true;
  defaultPicture: string;
  constructor(
    protected renderer: Renderer2,
    private activatedRoute: ActivatedRoute,
    private productService: ProductsService,
    private cartService: CartService,
    private pubSubService: PubSubService,
    private notificationService: NotificationService,
    private authService: AuthenticationService,
    private wishListService: WishListService
  ) {

    super(renderer);
    this.applicationName = Config.application.name;
    this.model = {} as ProductModel;
    this.model.imageAddresses = [];
    this.activatedRoute.params.subscribe(
      (param) => {
        this.loadingProduct = true;
        this.productCode = param['productCode'];
        this.getPromotedProducts();
        this.getMainProduct();
        this.getRelatedProducts();
        this.getBestSellerProducts();
      }
    );

  }

  ngOnInit() {
  }

  onAddItemToCart() {
    const authenticated = this.authService.isAuthenticated();
    if (!authenticated) {
      this.pubSubService.$pub('openLoginModal');
    } else {
      const createModel = {
        count: this.count,
        productId: this.model.id
      } as CartCreateModel;
      const exists = this.cartService.itemExists(this.model.id);
      if (!exists) {
        this.cartService.createItem(createModel).subscribe(
          (response) => {
            this.pubSubService.$pub('cartItemCreatedSuccessfully', response);
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

  onAddItemToCartAlter() {

  }

  onAddToWishList() {
    this.wishListService.create(this.model.id).subscribe(
      (response) => {
        this.notificationService.successfulOperationWithAlert('عملیات موفق', 'افزودن محصول به لیست علاقه مندی موفقیت آمیز بود.');
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  onAddToWishListAlter(item: ProductModel) {

  }

  onAddToCompareList() {

  }

  onAddToCompareListAlter(item: ProductModel) {

  }

  onAddQuantity() {
    this.count++;
  }

  onReduceQuantity() {
    this.count--;
  }

  getMainProduct() {
    this.loadingProduct = true;
    this.productService.getByProductCode(this.productCode).subscribe(
      (response) => {
        this.model = response;
        this.model.defaultImageAddress = Common.getImageAddress(this.model.defaultImage);
        this.defaultPicture = this.model.defaultImageAddress;
        this.model.imageAddresses = [];
        this.model.images.forEach(x => {
          this.model.imageAddresses.push(Common.getImageAddress(x));
        });
        this.loadingProduct = false;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getPromotedProducts() {

    this.productService.getPromotedProducts().subscribe(
      (response) => {
        this.promotedProducts = response;
        this.promotedProducts.forEach(x => {
          x.defaultImageAddress = Common.getImageAddress(x.defaultImage);
        });
      },
      (error) => {
        throw error;
      }
    );
  }

  getRelatedProducts() {
    this.productService.getRelatedProducts(this.productCode).subscribe(
      (response: ProductModel[]) => {
        this.relatedProducts = response;
        this.relatedProducts.forEach(x => {
          x.defaultImageAddress = Common.getImageAddress(x.defaultImage);
        });

        $(document).ready(function () {
          $('.owl-carousel.product_carousel, .owl-carousel.latest_category_carousel, .owl-carousel.latest_brands_carousel, .owl-carousel.related_pro').owlCarousel({
            itemsCustom: [[320, 1], [600, 2], [768, 3], [992, 5], [1199, 5]],
            lazyLoad: true,
            navigation: true,
            navigationText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            scrollPerPage: true
          });
        });
      },
      (error) => {
        this.notificationService.serverError();
        console.log(error);
      }
    );
  }

  getBestSellerProducts() {
    this.productService.getBestSellerProducts().subscribe(
      (response: ProductModel[]) => {
        this.bestSellerProducts = response;
        this.bestSellerProducts.forEach(x => {
          x.defaultImageAddress = Common.getImageAddress(x.defaultImage);
        });
      },
      (error) => {
        console.log(error);
        this.notificationService.serverError();
      }
    );
  }

  changePicture(image: string) {
    this.defaultPicture = image;
  }
}
