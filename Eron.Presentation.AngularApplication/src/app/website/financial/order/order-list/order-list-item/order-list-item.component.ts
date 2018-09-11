import { Component, OnInit, Input } from '@angular/core';
import { Common } from '../../../../../base/common';

@Component({
  selector: '[app-order-list-item]',
  templateUrl: './order-list-item.component.html',
  styleUrls: ['./order-list-item.component.scss']
})
export class OrderListItemComponent implements OnInit {

  @Input() tariff;
  constructor() {
  }

  ngOnInit() {
    this.tariff.slug = Common.slugify(this.tariff.slug);
  }

}
