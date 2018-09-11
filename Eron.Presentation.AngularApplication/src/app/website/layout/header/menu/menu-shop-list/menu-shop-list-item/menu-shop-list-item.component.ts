import { Component, OnInit, Input } from '@angular/core';

@Component({
  // tslint:disable-next-line:component-selector
  selector: '[app-menu-shop-list-item]',
  templateUrl: './menu-shop-list-item.component.html',
  styleUrls: ['./menu-shop-list-item.component.scss']
})
export class MenuShopListItemComponent implements OnInit {
  @Input() item;
  constructor() { }

  ngOnInit() {
  }

}
