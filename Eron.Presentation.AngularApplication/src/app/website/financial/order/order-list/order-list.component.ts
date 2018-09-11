import { Component, OnInit, Renderer2 } from '@angular/core';
import { WebsiteComponent } from '../../../website.component';
import { ActivatedRoute } from '@angular/router';
import { OrderCategoryListModel } from '../order-categories/order-category-list/order-category-list.model';
import { TariffCategoryService } from '../../../../control-panel/financial/tariff-category/tariff-category.service';
import { TariffService } from '../../../../control-panel/financial/tariff/tariff.service';
import { OrderClientListModel } from './order-list.model';
import { Common } from '../../../../base/common';
import { SelectListService } from '../../../../control-panel/infrastructure/services/selectList.service';
import { Title } from '@angular/platform-browser';
import { Config } from '../../../../app.config';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent extends WebsiteComponent implements OnInit {
  categoryId: number;
  category: OrderCategoryListModel;
  tariffs: OrderClientListModel[] = [];
  tariffItemTypes: any[];
  constructor(
    protected renderer: Renderer2,
    private route: ActivatedRoute,
    private tariffCategoryService: TariffCategoryService,
    private tariffService: TariffService,
    private selectListService: SelectListService,
    private titleService: Title
  ) {
    super(renderer);

    this.titleService.setTitle(Config.application.name + ' | ' + 'سفارش دهید');

    this.category = {} as OrderCategoryListModel;
    this.selectListService.getSelectList('TariffItemType').subscribe(
      (response) => {
        this.tariffItemTypes = response;

        this.route.params.subscribe(
          param => {
            this.categoryId = param.id;
            this.tariffCategoryService.get(this.categoryId).subscribe(
              (response2) => {
                this.category = response2;
                this.tariffService.getByCategory(this.categoryId).subscribe(
                  (result) => {
                    this.tariffs = result;
                    this.tariffs.forEach(x => {
                      x.slug = x.tariffName.replace(' ', '-');
                      x.imageAddress = Common.getImageAddress(x.imageId);
                      x.tariffItems.forEach(
                        y => {
                          y.typename = this.tariffItemTypes.find(z => z.value === y.tariffItemType.toString()).title;
                        }
                      );
                    });
                  }
                );
              }
            );
          }
        );
      }
    );
  }

  ngOnInit() {
  }

}
