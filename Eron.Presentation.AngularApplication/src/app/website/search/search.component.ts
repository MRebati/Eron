import { Component, OnInit, Renderer2 } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SearchService } from './search.service';
import { SearchResponseModel } from './search.model';
import { WebsiteComponent } from '../website.component';
import { Common } from '../../base/common';
import { WishListService } from '../user/wish-list/wish-list.service';
import { NotificationService } from '../../base/services/notification.service';
import { Config } from '../../app.config';

declare var $: any;

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent extends WebsiteComponent implements OnInit {

  model: SearchResponseModel = {} as SearchResponseModel;
  searchQuery: string;
  domainName = Config.websiteHost;
  loading = true;
  applicationName = Config.application.name;
  constructor(
    protected renderer: Renderer2,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private searchService: SearchService,
    private wishListService: WishListService,
    private notificationService: NotificationService
  ) {
    super(renderer);
    this.activatedRoute.params.subscribe(
      param => {
        this.searchQuery = param['searchQuery'];
        if (this.searchQuery === 'undefined') {
          this.router.navigateByUrl('/');
        }
        this.searchService.search(this.searchQuery).subscribe(
          (response) => {
            this.model = response;
            this.loading = false;

            this.setupProducts();
          }
        );
      }
    );
  }

  ngOnInit() {
  }

  setupProducts() {
    this.model.products.forEach(
      x => {
        x.defaultImageAddress = Common.getImageAddress(x.defaultImage);
      }
    );

    $(document).ready(function () {
      $('.product_carousel')
        .owlCarousel({
          itemsCustom: [[320, 1], [600, 2], [768, 3], [992, 5], [1199, 5]],
          lazyLoad: true,
          navigation: true,
          navigationText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
          scrollPerPage: true
        });
    });
  }

  onAddToWishList(item) {
    this.wishListService.create(item.id).subscribe(
      (response) => {
        this.notificationService.successfulOperationWithAlert('عملیات موفق', 'افزودن محصول به لیست علاقه مندی موفقیت آمیز بود.');
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }
}
