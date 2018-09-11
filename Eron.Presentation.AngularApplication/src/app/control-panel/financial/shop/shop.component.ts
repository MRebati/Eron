import { Component, OnInit } from '@angular/core';
import { BreadCrump } from '../../../base/models/breadCrump.model';
import { UrlNamePair } from '../../../base/models/urlNamePair.model';

@Component({
  selector: 'shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  breadCrump: BreadCrump;

  constructor() {


  }

  ngOnInit() {
  }
}
