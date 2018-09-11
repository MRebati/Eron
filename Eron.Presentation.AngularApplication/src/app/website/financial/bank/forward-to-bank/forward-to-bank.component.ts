import { Component, OnInit, AfterViewInit, Renderer2 } from '@angular/core';
import { ProductCategoryListModel } from '../../../../control-panel/financial/product-category/product-category-list/product-category-list.model';
import { ProductModel } from '../../../../control-panel/financial/products/product-list/product-list.model';
import { ActivatedRoute } from '@angular/router';
import { ProductCategoryService } from '../../../../control-panel/financial/product-category/product-category.service';
import { ProductsService } from '../../../../control-panel/financial/products/products.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { WebsiteComponent } from '../../../website.component';
import { Common } from '../../../../base/common';
import { InvoiceService } from '../../invoices/invoice.service';
import { Config } from '../../../../app.config';

@Component({
  selector: 'app-forward-to-bank',
  templateUrl: './forward-to-bank.component.html',
  styleUrls: ['./forward-to-bank.component.scss']
})
export class ForwardToBankComponent extends WebsiteComponent implements OnInit {
  p: any;
  categoryName: string;
  applicationName: string;
  invoiceId: number;
  referenceId: string;
  constructor(
    private activatedRoute: ActivatedRoute,
    private invoiceService: InvoiceService,
    private notificationService: NotificationService,
    protected renderer: Renderer2
  ) {
    super(renderer);

    this.applicationName = Config.application.name;
    this.activatedRoute.params.subscribe(
      param => {
        this.invoiceId = param['id'];
        this.invoiceService.createReference(this.invoiceId).subscribe(
          (response) => {
            this.referenceId = response;
          },
          (error) => {
            console.log(error);
          }
        );
      }
    );
  }

  ngOnInit() {
  }
}
