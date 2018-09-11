import { Component, OnInit, Renderer2 } from '@angular/core';
import { WebsiteComponent } from '../../../../website.component';
import { OrderCategoryListModel } from './order-category-list.model';
import { TariffCategoryService } from '../../../../../control-panel/financial/tariff-category/tariff-category.service';

@Component({
  selector: 'app-order-category-list',
  templateUrl: './order-category-list.component.html',
  styleUrls: ['./order-category-list.component.scss']
})
export class OrderCategoryListComponent extends WebsiteComponent implements OnInit {

  orderCategories: OrderCategoryListModel[] = [];
  constructor(
    protected renderer: Renderer2,
    private tariffCategoryService: TariffCategoryService
  ) {
    super(renderer);
    this.tariffCategoryService.getAll().subscribe(
      (response) => {
        this.orderCategories = response;
      }
    );
  }

  ngOnInit() {
  }

}
