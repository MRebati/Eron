import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Input } from '@angular/core';
import { ProductCategoryListModel } from '../../../../../../control-panel/financial/product-category/product-category-list/product-category-list.model';

declare var $: any;

@Component({
  // tslint:disable-next-line:component-selector
  selector: '[app-category-item]',
  templateUrl: './category-item.component.html',
  styleUrls: ['./category-item.component.scss']
})
export class CategoryItemComponent implements OnInit, AfterViewInit {

  @Input() item: ProductCategoryListModel;
  constructor() { }

  ngOnInit() {
  }

  ngAfterViewInit() {
  }

}
