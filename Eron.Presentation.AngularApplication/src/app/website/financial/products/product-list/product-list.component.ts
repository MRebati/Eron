import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ProductsService } from '../../../../control-panel/financial/products/products.service';
import { ProductModel } from '../../../../control-panel/financial/products/product-list/product-list.model';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  @Input() categoryId;
  list: ProductModel;
  p: number;
  pageSize = 20;
  constructor(
    private productService: ProductsService,
    private activatedRoute: ActivatedRoute
  ) {
    this.activatedRoute.params.subscribe(
      param => {
        this.categoryId = Number.parseInt(param['categoryId']);
        productService.getProductsByCategory(this.categoryId)
          .subscribe(
          (response) => {
            this.list = response;
          },
          (error) => {
            console.log(error);
          });
      });
  }

  ngOnInit() {
  }

}
