import { Component, OnInit, AfterViewInit } from '@angular/core';
import { ProductCategoryService } from '../../../../../control-panel/financial/product-category/product-category.service';
import { ProductCategoryListModel } from '../../../../../control-panel/financial/product-category/product-category-list/product-category-list.model';

declare var $: any;

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent implements OnInit, AfterViewInit {

  list: ProductCategoryListModel;
  constructor(
    private productCategoryService: ProductCategoryService
  ) {
    productCategoryService.getAll().subscribe(
      (response) => {
        this.list = response;

        $(document).ready(function(){
          $('#cat_accordion').cutomAccordion({
            saveState: false,
            autoExpand: true
          });
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
  }
}
