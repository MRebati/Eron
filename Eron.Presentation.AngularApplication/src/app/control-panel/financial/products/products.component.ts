import { Component, OnInit } from '@angular/core';
import { BreadCrump } from '../../../base/models/breadCrump.model';
import { UrlNamePair } from '../../../base/models/urlNamePair.model';

@Component({
  selector: 'products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  breadCrump: BreadCrump;
  constructor() {
    this.breadCrump = {
      Title: 'محصولات',
      DarkBackground: true,
      FirstNode: new UrlNamePair('داشبورد', '/controlpanel/dashboard'),
      SecondNode: new UrlNamePair('مدیریت محصولات'),
      ThirdNode: new UrlNamePair('لیست همه')
    } as BreadCrump;
  }

  ngOnInit() {
  }

}
