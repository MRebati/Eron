import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductCategoryService } from '../product-category.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { PubSubService } from 'angular2-pubsub';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductCategoryUpdateModel } from './product-category-update.model';

declare var $: any;

@Component({
  selector: 'product-category-update',
  templateUrl: './product-category-update.component.html',
  styleUrls: ['./product-category-update.component.scss']
})
export class ProductCategoryUpdateComponent implements OnInit {
  model: ProductCategoryUpdateModel;
  submitting: boolean;
  @ViewChild('keywordsInput') keywordsInput;
  constructor(
    private productCategoryService: ProductCategoryService,
    private notificationService: NotificationService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private pubService: PubSubService
  ) {
    this.restartModel();
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

  save(keywordsInput) {
    this.submitting = true;
    $(keywordsInput).importTags('');
    // todo: check enhacement column in artin backbone board
    // [trello: 'https://trello.com/c/DB8t9vIj/14-tagsinput-directive-which-used-in-product-category-create-component-requires-to-trigger-restart-event-independently' ]
    // this.restart.next({});

    this.productCategoryService.update(this.model).subscribe(
      (response) => {
        this.submitting = false;
        // this.pubService.$pub('productCategoryUpdateSuccess', response);
        this.router.navigateByUrl('/controlpanel/productcategories');
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
    this.model = {} as ProductCategoryUpdateModel;
  }
}
