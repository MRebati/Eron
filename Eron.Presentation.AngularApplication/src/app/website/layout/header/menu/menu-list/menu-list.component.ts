import { Component, OnInit, AfterViewInit } from '@angular/core';
import { NavigationViewModel } from '../../../../../control-panel/base/navigation/navigation.view.model';
import { NavigationService } from '../../../../../control-panel/base/navigation/navigation.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: '[app-menu-list]',
  templateUrl: './menu-list.component.html',
  styleUrls: ['./menu-list.component.scss']
})
export class MenuListComponent implements OnInit, AfterViewInit {
  menuList: NavigationViewModel[] = [];
  constructor(private menuService: NavigationService) {
    this.menuService.getMenuItemsAsTree().subscribe(
      (response) => {
        this.menuList = response;

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
      },
      (error) => {
        console.log(error);
      }
    );
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    /*---------------------------------------------------
        Main Menu
    ----------------------------------------------------- */

    let $screensize = $(window).width();

    $(window).resize(function () {
      $screensize = $(window).width();
      if ($screensize > 1199) {
        $('#menu .nav > li.mega-menu > div .clearfix.visible-lg-block').remove();
        $('#menu .nav > li.mega-menu > div > .column:nth-child(6n)')
          .after('<div class="clearfix visible-lg-block"></div>');
      }
      if ($screensize < 1199) {
        $('#menu .nav > li.mega-menu > div .clearfix.visible-lg-block').remove();
        $('#menu .nav > li.mega-menu > div > .column:nth-child(4n)')
          .after('<div class="clearfix visible-lg-block visible-md-block"></div>');
      }
    });
  }

}
