import { Renderer2, Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { WebsiteComponent } from '../website.component';
import { Config } from '../../app.config';
import { ViewChild } from '@angular/core';
import { Modal } from 'ngx-modal';
import { AuthenticationService } from '../../authentication/auth.service';
import { LoginViewModel } from '../../authentication/login.model';
import { NotificationService } from '../../base/services/notification.service';
import { Router } from '@angular/router';
import { PubSubService } from 'angular2-pubsub';
import { Subscription } from 'rxjs/Subscription';
import { RecaptchaComponent } from 'ng2-recaptcha/recaptcha/recaptcha.component';
import { StorageService } from '../../base/services/storage.service';

declare var $: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent extends WebsiteComponent implements OnInit, AfterViewInit, OnDestroy {
  applicationName: string;
  constructor(
    protected renderer: Renderer2,
    public storageService: StorageService
  ) {
    super(renderer);
    this.applicationName = Config.application.name;
  }

  ngOnInit() {
  }

  ngAfterViewInit() {

    let $screensize = $(window).width();

      $('#latest_category .owl-carousel.latest_category_tabs').owlCarousel({
        itemsCustom: [[320, 1], [600, 2], [768, 3], [992, 5], [1199, 5]],
        lazyLoad: true,
        navigation: true,
        navigationText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        scrollPerPage: true,
      });
      $('#latest_category .tab_content').addClass('deactive');
      $('#latest_category .tab_content:first').show();
      // Default Action
      $('#latest_category ul#sub-cat li:first').addClass('active').show(); // Activate first tab
      // On Click Event
      $('#latest_category ul#sub-cat li').on('click', function () {
        $('#latest_category ul#sub-cat li').removeClass('active'); // Remove any "active" class
        $(this).addClass('active'); // Add "active" class to selected tab
        $('#latest_category .tab_content').hide();
        const activeTab = $(this).find('a').attr('href'); // Find the rel attribute value to identify the active tab + content
        $(activeTab).fadeIn(); // Fade in the active content
        return false;
      });

      /*---------------------------------------------------
           Brand Slider (Default Owl Carousel)
      ----------------------------------------------------- */
      $('#carousel').owlCarousel({
        items: 6,
        autoPlay: 3000,
        lazyLoad: true,
        navigation: true,
        navigationText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        pagination: true
      });

      /*---------------------------------------------------
           Product Tab Carousel Slider(Featured,Latest,specila,etc..)
      ----------------------------------------------------- */

      $('#product-tab .tab_content').addClass('deactive');
      $('#product-tab .tab_content:first').show();
      // Default Action
      $('ul#tabs li:first').addClass('active').show(); // Activate first tab
      // On Click Event
      $('ul#tabs li').on('click', function () {
        $('ul#tabs li').removeClass('active'); // Remove any "active" class
        $(this).addClass('active'); // Add "active" class to selected tab
        $('#product-tab .tab_content').hide();
        const activeTab = $(this).find('a').attr('href'); // Find the rel attribute value to identify the active tab + content
        $(activeTab).fadeIn(); // Fade in the active content
        return false;
      });

      /*---------------------------------------------------
          Categories Accordion
      ----------------------------------------------------- */
      $('#cat_accordion').cutomAccordion({
        saveState: false,
        autoExpand: true
      });

      /*---------------------------------------------------
          Increase and Decrease Button Quantity for Product Page
      ----------------------------------------------------- */
      $('.qtyBtn').on('click', function () {
        if ($(this).hasClass('plus')) {
          let qty = $('.qty #input-quantity').val();
          qty++;
          $('.qty #input-quantity').val(qty);
        } else {
          let qty = $('.qty #input-quantity').val();
          qty--;
          if (qty > 0) {
            $('.qty #input-quantity').val(qty);
          }
        }
        return false;
      });

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

      /*---------------------------------------------------
         Product Grid
      ----------------------------------------------------- */
      $(document).on('click', '#grid-view', function (e) {
        $('#content .product-layout').attr('class', 'product-layout product-grid col-lg-3 col-md-3 col-sm-4 col-xs-12');

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

      /*---------------------------------------------------
         tooltips
      ----------------------------------------------------- */
      $('[data-toggle=\'tooltip\']').tooltip({ container: 'body' });

      /*---------------------------------------------------
         Scroll to top
      ----------------------------------------------------- */
      $(function () {
        $(window).scroll(function () {
          if ($(this).scrollTop() > 150) {
            $('#back-top').fadeIn();
          } else {
            $('#back-top').fadeOut();
          }
        });
      });
      $('#back-top').on('click', function () {
        $('html, body').animate({ scrollTop: 0 }, 'slow');
        return false;
      });

      /*---------------------------------------------------
         Facebook Side Block
      ----------------------------------------------------- */
      $(function () {
        $('#facebook.fb-left').hover(function () {
          $(this).stop(true, false).animate({ left: '0' }, 800, 'easeOutQuint');
        },
          function () {
            $(this).stop(true, false).animate({ left: '-241px' }, 800, 'easeInQuint');
          }, 1000);
      });
      $(function () {
        $('#facebook.fb-right').hover(function () {
          $(this).stop(true, false).animate({ right: '0' }, 800, 'easeOutQuint');
        },
          function () {
            $(this).stop(true, false).animate({ right: '-241px' }, 800, 'easeInQuint');
          }, 1000);
      });

      /*---------------------------------------------------
         Twitter Side Block
      ----------------------------------------------------- */
      $(function () {
        $('#twitter_footer.twit-left').hover(function () {
          $(this).stop(true, false).animate({ left: '0' }, 800, 'easeOutQuint');
        },
          function () {
            $(this).stop(true, false).animate({ left: '-215px' }, 800, 'easeInQuint');
          }, 1000);
      });
      $(function () {
        $('#twitter_footer.twit-right').hover(function () {
          $(this).stop(true, false).animate({ right: '0' }, 800, 'easeOutQuint');
        },
          function () {
            $(this).stop(true, false).animate({ right: '-215px' }, 800, 'easeInQuint');
          }, 1000);
      });

      /*---------------------------------------------------
         Video Side Block
      ----------------------------------------------------- */
      $(function () {
        $('#video_box.vb-left').hover(function () {
          $(this).stop(true, false).animate({ left: '0' }, 800, 'easeOutQuint');
        },
          function () {
            $(this).stop(true, false).animate({ left: '-566px' }, 800, 'easeInQuint');
          }, 1000);
      });
      $(function () {
        $('#video_box.vb-right').hover(function () {
          $(this).stop(true, false).animate({ right: '0' }, 800, 'easeOutQuint');
        },
          function () {
            $(this).stop(true, false).animate({ right: '-566px' }, 800, 'easeInQuint');
          }, 1000);
      });

      /*---------------------------------------------------
         Custom Side Block
      ----------------------------------------------------- */
      $(function () {
        $('#custom_side_block.custom_side_block_left').hover(function () {
          $(this).stop(true, false).animate({ left: '0' }, 800, 'easeOutQuint');
        },
          function () {
            $(this).stop(true, false).animate({ left: '-215px' }, 800, 'easeInQuint');
          }, 1000);
      });
      $(function () {
        $('#custom_side_block.custom_side_block_right').hover(function () {
          $(this).stop(true, false).animate({ right: '0' }, 800, 'easeOutQuint');
        },
          function () {
            $(this).stop(true, false).animate({ right: '-215px' }, 800, 'easeInQuint');
          }, 1000);
      });
  }
}
