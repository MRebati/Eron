import { Component, OnInit, Input } from '@angular/core';
import { ProductCategoryListModel } from '../product-category-list.model';
import { NotificationService } from '../../../../../base/services/notification.service';
import { Api } from '../../../../../base/api';

@Component({
  // tslint:disable-next-line:component-selector
  selector: '[app-product-category-list-item]',
  templateUrl: './product-category-list-item.component.html',
  styleUrls: ['./product-category-list-item.component.scss']
})
export class ProductCategoryListItemComponent implements OnInit {

  @Input() item: ProductCategoryListModel;
  @Input() itemList: ProductCategoryListModel[];
  children: ProductCategoryListModel[];
  constructor(
    private notificationService: NotificationService
  ) { }

  ngOnInit() {
  }

  onDelete() {
    this.notificationService.deleteConfirmationAlert(
      'مجموعه محصولات ' + this.item.title,
      this.item.id,
      Api.productCategory.default,
      'deleteProductCategorySuccess');
  }

}
