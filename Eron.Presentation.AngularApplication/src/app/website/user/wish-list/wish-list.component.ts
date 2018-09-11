import { Component, OnInit } from '@angular/core';
import { ProvinceService } from '../../../base/services/province.service';
import { UserService } from '../../../control-panel/base/user/user.service';
import { NotificationService } from '../../../base/services/notification.service';
import { UserModel } from '../user.model';
import { WishListService } from './wish-list.service';
import { WishListItemModel } from './wish-list.model';

@Component({
  selector: 'app-wish-list',
  templateUrl: './wish-list.component.html',
  styleUrls: ['./wish-list.component.scss']
})
export class WishListComponent implements OnInit {
  itemList: WishListItemModel[] = [];
  constructor(
    public notificationService: NotificationService,
    public wishListService: WishListService
  ) {
    this.wishListService.getUserWishList().subscribe(
      (response) => {
        this.itemList = response;
        this.itemList.forEach(x => {
          x.product.price = x.product.prices.filter(y => y.isValid)[0].price;
        });
      }
    );
  }

  ngOnInit() {
  }

  onDelete(item: WishListItemModel, index: number) {
    this.wishListService.delete(item.id).subscribe(
      (response) => {
        this.notificationService.successfulOperation('حذف آیتم از لیست علاقه مندی ها');
        this.itemList.splice(index, 1);
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }
}
