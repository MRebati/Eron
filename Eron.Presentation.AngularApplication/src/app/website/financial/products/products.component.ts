import { Component, OnInit, AfterViewInit, Renderer2 } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ActivatedRouteSnapshot } from '@angular/router';
import { ProductCategoryService } from '../../../control-panel/financial/product-category/product-category.service';
import { ProductCategoryListModel } from '../../../control-panel/financial/product-category/product-category-list/product-category-list.model';
import { WebsiteComponent } from '../../website.component';
import { ProductModel } from '../../../control-panel/financial/products/product-list/product-list.model';
import { ProductsService } from '../../../control-panel/financial/products/products.service';
import { NotificationService } from '../../../base/services/notification.service';
import { Common } from '../../../base/common';


declare var $: any;

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent extends WebsiteComponent implements OnInit, AfterViewInit {
  p: any;
  categoryName: string;
  categoryId: number;
  category: ProductCategoryListModel;
  bestSellerProducts: ProductModel[] = [];
  promotedProducts: ProductModel[] = [];
  constructor(
    private activatedRoute: ActivatedRoute,
    private productCategoryService: ProductCategoryService,
    private productService: ProductsService,
    private notificationService: NotificationService,
    protected renderer: Renderer2
  ) {
    super(renderer);

    this.activatedRoute.params.subscribe(
      param => {
        this.categoryId = param['categoryId'];
        this.categoryName = param['categoryName'];
        this.getBestSellerProducts();
        this.getPromotedProducts();
        this.productCategoryService.get(this.categoryId).subscribe(
          (response) => {
            this.category = response;
          },
          (error) => {
            console.log(error);
          }
        );
      }
    );
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    $(document).ready(function () {

      /*---------------------------------------------------
    Product List
----------------------------------------------------- */
      $('#list-view').on('click', function () {
        $('.products-category > .clearfix.visible-lg-block').remove();
        $('#content .product-layout').attr('class', 'product-layout product-list col-xs-12');
        localStorage.setItem('display', 'list');
        $('.btn-group').find('#list-view').addClass('selected');
        $('.btn-group').find('#grid-view').removeClass('selected');
        return false;
      });

      $(document).on('click', '#grid-view', function (e) {
        $('#content .product-layout').attr('class', 'product-layout product-grid col-lg-3 col-md-3 col-sm-4 col-xs-12');
        let $screensize = $(window).width();
        $screensize = $(window).width();
        if ($screensize > 1199) {
          $('.products-category > .clearfix').remove();
          $('.product-grid:nth-child(4n)').after('<span class="clearfix visible-lg-block"></span>');
        }
        if ($screensize < 1199) {
          $('.products-category > .clearfix').remove();
          $('.product-grid:nth-child(4n)').after('<span class="clearfix visible-lg-block visible-md-block"></span>');
        }
        if ($screensize < 991) {
          $('.products-category > .clearfix').remove();
          $('.product-grid:nth-child(3n)').after('<span class="clearfix visible-lg-block visible-sm-block"></span>');
        }
        $(window).resize(function () {
          $screensize = $(window).width();
          if ($screensize > 1199) {
            $('.products-category > .clearfix').remove();
            $('.product-grid:nth-child(4n)').after('<span class="clearfix visible-lg-block"></span>');
          }
          if ($screensize < 1199) {
            $('.products-category > .clearfix').remove();
            $('.product-grid:nth-child(4n)').after('<span class="clearfix visible-lg-block visible-md-block"></span>');
          }
          if ($screensize < 991) {
            $('.products-category > .clearfix').remove();
            $('.product-grid:nth-child(3n)').after('<span class="clearfix visible-lg-block visible-sm-block"></span>');
          }
          if ($screensize < 767) {
            $('.products-category > .clearfix').remove();
          }
        });
        localStorage.setItem('display', 'grid');
        $('.btn-group').find('#grid-view').addClass('selected');
        $('.btn-group').find('#list-view').removeClass('selected');
      });
      if (localStorage.getItem('display') === 'list') {
        $('#list-view').trigger('click');
      } else {
        $('#grid-view').trigger('click');
      }
    });
  }

  getBestSellerProducts() {
    this.productService.getBestSellerProducts().subscribe(
      (response: ProductModel[]) => {
        this.bestSellerProducts = response;
        this.bestSellerProducts.forEach(item => {
          item.defaultImageAddress = Common.getImageAddress(item.defaultImage);
        });
      },
      (error) => {
        console.log(error);
        this.notificationService.serverError();
      }
    );
  }

  getPromotedProducts() {

    this.productService.getPromotedProducts().subscribe(
      (response) => {
        this.promotedProducts = response;
        this.promotedProducts.forEach(x => {
          x.defaultImageAddress = Common.getImageAddress(x.defaultImage);
        });
      },
      (error) => {
        throw error;
      }
    );
  }
}
