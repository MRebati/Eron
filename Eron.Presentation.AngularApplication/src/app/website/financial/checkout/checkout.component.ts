import { Component, OnInit, Renderer2 } from '@angular/core';
import { UserService } from '../../../control-panel/base/user/user.service';
import { NotificationService } from '../../../base/services/notification.service';
import { CartService } from '../cart/cart.service';
import { CartListModel } from '../cart/cart-list/cart-list.model';
import { Common } from '../../../base/common';
import { PubSubService } from 'angular2-pubsub';
import { WebsiteComponent } from '../../website.component';
import { UserModel } from '../../user/user.model';
import { ProvinceService } from '../../../base/services/province.service';
import { InvoiceService } from '../invoices/invoice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent extends WebsiteComponent implements OnInit {
  noCompleteUserDetails: boolean;
  cartItemList: CartListModel[] = [];
  provinceList: any[] = [];
  cityList: any[] = [];
  totalPrice = 0;
  readTerms: boolean;
  user: UserModel;
  constructor(
    private userService: UserService,
    private cartService: CartService,
    private notificationService: NotificationService,
    private pubSubService: PubSubService,
    private invoiceService: InvoiceService,
    public provinceService: ProvinceService,
    private router: Router,
    protected renderer: Renderer2
  ) {
    super(renderer);
    this.user = {} as UserModel;
    this.cartService.getItems().subscribe(
      (response) => {
        this.cartItemList = response;
        this.cartItemList.forEach(x => {
          x.productImageAddress = Common.getImageAddress(x.productImage);
          this.totalPrice += x.count * x.productPrice;
        });
        this.cartService.setCurrentItems(this.cartItemList);
      },
      (error) => {
        console.log(error);
      }
    );

    this.provinceList = this.provinceService.getProvincesList();
    this.user = {} as UserModel;
    this.userService.getUserInfo().subscribe(
      (response) => {
        this.user = response;
        this.provinceChanged();
        this.user.cityName = response.cityName;
      }
    );

    userService.userInfoIsComplete().subscribe(
      (response) => {
        this.noCompleteUserDetails = !response;
      },
      (error) => {
        notificationService.serverError();
        console.log(error);
      }
    );
  }

  ngOnInit() {
  }

  provinceChanged() {
    this.cityList = this.provinceService.getCityByName(this.user.provinceName);
  }

  onCountChange(item?: any) {
    this.totalPrice = 0;
    this.cartItemList.forEach(x => {
      this.totalPrice += x.count * x.productPrice;
    });
    if (item != null) {
      this.cartService.updateItem(item).subscribe();
    }
  }

  onRemoveItemFromCart(id: number, index: number) {
    this.cartService.removeItem(id).subscribe(
      (response) => {
        this.cartItemList.splice(index, 1);
        this.onCountChange();
        this.pubSubService.$pub('cartItemDeletedSuccessfully', { id: id, index: index });
      },
      (error) => {
        console.log(error);
      }
    );
  }

  onReadTermChange($event) {
    this.readTerms = !this.readTerms;
  }

  checkCoupon() {

  }

  checkVoucher() {

  }

  onSubmit() {
    this.userService.updateUser(this.user).subscribe(
      (response) => {
        this.invoiceService.createInvoiceForCart().subscribe(
          (response2) => {
            this.router.navigateByUrl('/invoices');
          },
          (error) => {
            this.notificationService.serverError(error);
          }
        );
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

}
