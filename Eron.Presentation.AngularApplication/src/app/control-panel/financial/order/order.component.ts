import { Component, OnInit } from '@angular/core';
import { BreadCrump } from '../../../base/models/breadCrump.model';
import { UrlNamePair } from '../../../base/models/urlNamePair.model';

@Component({
  selector: 'order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  breadCrump: BreadCrump;
  constructor() {
    this.breadCrump = {
      Title: 'سفارشات',
      DarkBackground: true,
      FirstNode: new UrlNamePair('داشبورد', '/controlpanel/dashboard'),
      SecondNode: new UrlNamePair('مدیریت سفارشات'),
      ThirdNode: new UrlNamePair('لیست همه')
    } as BreadCrump;
  }

  ngOnInit() {
  }

}
