import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ProductCategoryCreateModel } from './product-category-create.model';
import { ProductCategoryService } from '../product-category.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { PubSubService } from 'angular2-pubsub';

declare var $: any;

@Component({
  selector: 'product-category-create',
  templateUrl: './product-category-create.component.html',
  styleUrls: ['./product-category-create.component.scss']
})
export class ProductCategoryCreateComponent implements OnInit {
  model: ProductCategoryCreateModel;
  submitting: boolean;
  constructor(
    private productCategoryService: ProductCategoryService,
    private notificationService: NotificationService,
    private pubService: PubSubService
  ) {
    this.model = {} as ProductCategoryCreateModel;
  }

  ngOnInit() {
  }

  save(keywordsInput) {
    this.submitting = true;
    $(keywordsInput).importTags('');
    // todo: check enhacement column in artin backbone board
    // [trello: 'https://trello.com/c/DB8t9vIj/14-tagsinput-directive-which-used-in-product-category-create-component-requires-to-trigger-restart-event-independently' ]
    // this.restart.next({});

    this.productCategoryService.create(this.model).subscribe(
      (response) => {
        this.submitting = false;
        this.pubService.$pub('productCategoryCreateSuccess', response);
      },
      (error) => {
        this.submitting = false;
        this.notificationService.serverError();
        console.log(error);
      }
    );

    this.restartModel();
  }

  restartModel() {
    this.model = {} as ProductCategoryCreateModel;
  }
}
