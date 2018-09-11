import { Component, OnInit } from '@angular/core';
import { Config } from '../../../app.config';
import { WebsiteComponent } from '../../website.component';
import { Renderer2 } from '@angular/core';
import { CartListModel } from './cart-list/cart-list.model';
import { CartService } from './cart.service';
import { Common } from '../../../base/common';
import { Subscription } from 'rxjs/Subscription';
import { PubSubService } from 'angular2-pubsub';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent extends WebsiteComponent implements OnInit {

  cartItemDeleteSubscription: Subscription;
  applicationName: string;
  facebookAddress: string;
  facebookName: string;
  cartItemList: CartListModel[] = [];
  totalPrice = 0;

  constructor(
    protected renderer: Renderer2,
    private cartService: CartService,
    private pubSubService: PubSubService
  ) {
    super(renderer);
    this.applicationName = Config.application.name;
    this.facebookAddress = Config.application.social.facebook.address;
    this.facebookName = Config.application.social.facebook.address;

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
  }

  ngOnInit() {
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
}
