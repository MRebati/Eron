import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductCategoryCreateModel } from '../product-category-create/product-category-create.model';
import { ProductCategoryService } from '../product-category.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { PubSubService } from 'angular2-pubsub';
import { ProductCategoryUpdateModel } from '../product-category-update/product-category-update.model';
import { Router, ActivatedRoute } from '@angular/router';

declare var $: any;

@Component({
  selector: 'app-product-category-details',
  templateUrl: './product-category-details.component.html',
  styleUrls: ['./product-category-details.component.scss']
})
export class ProductCategoryDetailsComponent implements OnInit {
  model: ProductCategoryUpdateModel = {} as ProductCategoryUpdateModel;
  submitting: boolean;
  @ViewChild('keywordsInput') keywordsInput;
  constructor(
    private productCategoryService: ProductCategoryService,
    private notificationService: NotificationService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private pubService: PubSubService
  ) {
    this.activatedRoute.params.subscribe(
      param => {
        const productCategoryId = Number.parseInt(param['id']);
        this.productCategoryService.get(productCategoryId).subscribe(
          (response) => {
            this.model = response;
            const keywordsInput = this.keywordsInput.nativeElement;
            $(keywordsInput).importTags('');
            $(keywordsInput).importTags(response.keywords);
          },
          (error) => {
            this.notificationService.serverError(error);
          }
        );
      }
    );
  }

  ngOnInit() {
  }
}
