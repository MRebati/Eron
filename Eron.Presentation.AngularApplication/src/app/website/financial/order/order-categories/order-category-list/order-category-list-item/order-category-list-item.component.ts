import { Component, OnInit, Input } from '@angular/core';
import { OrderCategoryListModel } from '../order-category-list.model';
import { TariffCategoryService } from '../../../../../../control-panel/financial/tariff-category/tariff-category.service';
import { Common } from '../../../../../../base/common';

@Component({
  selector: '[app-order-category-list-item]',
  templateUrl: './order-category-list-item.component.html',
  styleUrls: ['./order-category-list-item.component.scss']
})
export class OrderCategoryListItemComponent implements OnInit {

  @Input() category: OrderCategoryListModel;
  constructor(
  ) {
  }

  ngOnInit() {
    if (this.category.imageId === '00000000-0000-0000-0000-000000000000' || this.category.imageId == null) {
      this.category.imageAddress = Common.getDefaultImageAddress('OrderCategory');
    } else {
      this.category.imageAddress = Common.getImageAddress(this.category.imageId);
    }

  }

}
