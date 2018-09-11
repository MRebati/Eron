import { Component, OnInit, Input } from '@angular/core';
import { ProductModel } from '../../../../control-panel/financial/products/product-list/product-list.model';
import { Api } from '../../../../base/api';
import { CartService } from '../../cart/cart.service';
import { CartCreateModel } from '../../cart/cart-create/cart-create.model';
import { NotificationService } from '../../../../base/services/notification.service';
import { PubSubService } from 'angular2-pubsub';
import { WishListService } from '../../../user/wish-list/wish-list.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {

  @Input() index;
  @Input() item: ProductModel;
  constructor(
    private cartService: CartService,
    private notificationService: NotificationService,
    private pubService: PubSubService,
    private wishListService: WishListService
  ) { }

  ngOnInit() {
    this.item.imageAddresses = [];
    this.item.defaultImageAddress = Api.common.image + this.item.defaultImage;
    this.item.images.forEach(x => {
      this.item.imageAddresses.push(Api.common.image + x);
    });
  }

  onAddToCart(model: ProductModel) {
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
    }else {
      this.notificationService.duplicationRestriction('امکان ثبت مجدد آیتم در سبد وجود ندارد',
      'آیتم انتخابی قبلا در سبد خرید شما درج شده، امکان ثبت مجدد آن مقدور نمی باشد');
    }
  }

  onAddToWishList(item: ProductModel) {
    this.wishListService.create(this.item.id).subscribe(
      (response) => {
        this.notificationService.successfulOperationWithAlert('عملیات موفق', 'افزودن محصول به لیست علاقه مندی موفقیت آمیز بود.');
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  onAddToCompareList(item: ProductModel) {
  }
}
