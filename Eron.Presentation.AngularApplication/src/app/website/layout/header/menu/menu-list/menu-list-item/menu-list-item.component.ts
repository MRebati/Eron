import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';

@Component({
  // tslint:disable-next-line:component-selector
  selector: '[app-menu-list-item]',
  templateUrl: './menu-list-item.component.html',
  styleUrls: ['./menu-list-item.component.scss']
})
export class MenuListItemComponent implements OnInit {
  @Input() item;
  constructor() { }

  ngOnInit() {
  }

}
