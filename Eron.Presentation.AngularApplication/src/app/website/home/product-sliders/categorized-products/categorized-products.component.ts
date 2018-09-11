import { Component, OnInit } from '@angular/core';
import { AfterViewInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { ProductCategoryListModel } from '../../../../control-panel/financial/product-category/product-category-list/product-category-list.model';
import { ProductCategoryService } from '../../../../control-panel/financial/product-category/product-category.service';
import { ProductModel } from '../../../../control-panel/financial/products/product-list/product-list.model';
import { CartService } from '../../../financial/cart/cart.service';
import { PubSubService } from 'angular2-pubsub';
import { CartCreateModel } from '../../../financial/cart/cart-create/cart-create.model';
import { NotificationService } from '../../../../base/services/notification.service';
import { AuthenticationService } from '../../../../authentication/auth.service';

@Component({
  selector: 'app-categorized-products',
  templateUrl: './categorized-products.component.html',
  styleUrls: ['./categorized-products.component.scss']
})
export class CategorizedProductsComponent implements OnInit, AfterViewInit {

  categories: ProductCategoryListModel[] = [];
  constructor(
    productCategoryService: ProductCategoryService,
    private cartService: CartService,
    private pubService: PubSubService,
    public notificationService: NotificationService,
    private authService: AuthenticationService
  ) {
    productCategoryService.getAllFullCategories().subscribe(
      (response) => {
        this.categories = response;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    $('#product-tab .tab_content').addClass('deactive');
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
