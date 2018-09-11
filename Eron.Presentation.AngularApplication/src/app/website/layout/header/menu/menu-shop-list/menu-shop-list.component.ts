import { Component, OnInit } from '@angular/core';
import { ProductCategoryService } from '../../../../../control-panel/financial/product-category/product-category.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: '[app-menu-shop-list]',
  templateUrl: './menu-shop-list.component.html',
  styleUrls: ['./menu-shop-list.component.scss']
})
export class MenuShopListComponent implements OnInit {

  list: any[];
  parentProductCategories: any[];
  constructor(
    private productCategoryList: ProductCategoryService
  ) {
    productCategoryList.getAll().subscribe(
      (response) => {
        this.list = response;
        this.parentProductCategories = response;
        this.menuIsReady();
      },
      (error) => {
        console.log(error);
      }
    );
  }

  ngOnInit() {
  }

  menuIsReady() {
    let $screensize = $(window).width();
    $(document).ready(function () {
      $('#menu .nav > li > .dropdown-menu').each(function () {
        const menu = $('#menu').offset();
        const dropdown = $(this).parent().offset();

        const i = (dropdown.left + $(this).outerWidth()) - (menu.left + $('#menu').outerWidth());

        if (i > 0) {
          $(this).css('margin-left', '-' + (i + 5) + 'px');
        }
      });

      $('#menu .nav > li, #header .links > ul > li').on('mouseover', function () {

        if ($screensize > 991) {
          $(this).find('> .dropdown-menu').stop(true, true).slideDown('fast');
        }
        $(this).bind('mouseleave', function () {

          if ($screensize > 991) {
            $(this).find('> .dropdown-menu').stop(true, true).css('display', 'none');
          }
        });
      });
      $('#menu .nav > li div > ul > li').on('mouseover', function () {
        if ($screensize > 991) {
          $(this).find('> div').css('display', 'block');
        }
        $(this).bind('mouseleave', function () {
          if ($screensize > 991) {
            $(this).find('> div').css('display', 'none');
          }
        });
      });
      $('#menu .nav > li > .dropdown-menu').closest('li').addClass('sub');

      $screensize = $(window).width();
      if ($screensize > 1199) {
        $('#menu .nav > li.mega-menu > div > .column:nth-child(6n)').after('<div class="clearfix visible-lg-block"></div>');
      }
      if ($screensize < 1199) {
        $('#menu .nav > li.mega-menu > div > .column:nth-child(4n)')
          .after('<div class="clearfix visible-lg-block visible-md-block"></div>');
      }
    });
  }

}
