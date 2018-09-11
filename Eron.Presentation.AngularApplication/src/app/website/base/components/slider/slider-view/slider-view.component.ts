import { Component, OnInit, Input, AfterViewInit, ViewChild } from '@angular/core';
import { SliderService } from '../../../../../control-panel/base/slider/slider.service';
import { SliderViewModel } from './slider-view.model';
import { Api } from '../../../../../base/api';

declare var $: any;

@Component({
  // tslint:disable-next-line:component-selector
  selector: '[slider-view]',
  templateUrl: './slider-view.component.html',
  styleUrls: ['./slider-view.component.scss']
})
export class SliderViewComponent implements OnInit, AfterViewInit {
  @Input() group: string;
  @Input() type: string;
  @Input() defaultsize: string;
  showDefault: boolean;
  list: SliderViewModel[] = [];
  constructor(
    private sliderService: SliderService
  ) {
  }

  ngOnInit() {

    this.sliderService.getByGroupName(this.group).subscribe(
      (response) => {
        this.list = response;
        this.list.forEach((item) => {
          item.fileAddress = Api.common.image + item.fileId;
        });
        if (this.list.length === 0) {
          this.showDefault = true;
        }
        this.afterSlierInit();
      },
      (error) => {
        this.showDefault = true;
        console.log(error);
      }
    );
  }

  afterSlierInit() {
    switch (this.type) {
      case 'topSlider': {
        $(document).ready(function () {
          $('.slideshow').owlCarousel({
            items: 1,
            autoPlay: 3000,
            singleItem: true,
            navigation: true,
            navigationText: ['<i class="fa fa-chevron-left"></i>', '<i class="fa fa-chevron-right"></i>'],
            pagination: true
          });
        });
        break;
      }
      case 'banner': {
        break;
      }

      case 'clients': {
        $(document).ready(function () {
          $('#clients').owlCarousel({
            items: 6,
            autoPlay: 3000,
            lazyLoad: true,
            navigation: true,
            navigationText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            pagination: true
          });
        });
        break;
      }
    }
  }

  ngAfterViewInit() {
  }
}
