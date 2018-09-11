import { NgModule } from '@angular/core';
import { FinancialRoutingModule } from './financial.routing';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { LaddaModule } from 'angular2-ladda';
import { PubSubModule } from 'angular2-pubsub';
import { ToastModule } from 'ng2-toastr/src/toast.module';


import { CustomerTypeComponent } from '../../base/components/customer-type/customer-type.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { ProductCreateComponent } from './products/product-create/product-create.component';
import { ProductUpdateComponent } from './products/product-update/product-update.component';
import { TariffUpdateComponent } from './tariff/tariff-update/tariff-update.component';
import { TariffCreateComponent } from './tariff/tariff-create/tariff-create.component';
import { TariffListComponent } from './tariff/tariff-list/tariff-list.component';
import { OrderUpdateComponent } from './order/order-update/order-update.component';
import { OrderCreateComponent } from './order/order-create/order-create.component';
import { OrderSearchComponent } from './order/order-search/order-search.component';
import { OrderListComponent } from './order/order-list/order-list.component';
import { TariffComponent } from './tariff/tariff.component';
import { ShopComponent } from './shop/shop.component';
import { ProductsComponent } from './products/products.component';
import { OrderComponent } from './order/order.component';
import { BaseModule } from '../../base/base.module';
import { ControlPanelSharedModule } from '../control-panel.shared.module';
import { BadgeComponent } from '../../base/components/badge-component/badge-component.component';
import { ShopListComponent } from './shop/shop-list/shop-list.component';
import { ProductCategoryComponent } from './product-category/product-category.component';
import { ProductCategoryCreateComponent } from './product-category/product-category-create/product-category-create.component';
import { ProductCategoryUpdateComponent } from './product-category/product-category-update/product-category-update.component';
import { ProductCategoryListComponent } from './product-category/product-category-list/product-category-list.component';
import { ProductCategoryListItemComponent } from './product-category/product-category-list/product-category-list-item/product-category-list-item.component';
import { TariffCategoryComponent } from './tariff-category/tariff-category.component';
import { TariffCategoryCreateComponent } from './tariff-category/tariff-category-create/tariff-category-create.component';
import { TariffCategoryListComponent } from './tariff-category/tariff-category-list/tariff-category-list.component';
import { TariffCategoryUpdateComponent } from './tariff-category/tariff-category-update/tariff-category-update.component';
import { TariffCategoryListItemComponent } from './tariff-category/tariff-category-list/tariff-category-list-item/tariff-category-list-item.component';
import { OrderDetailsComponent } from './order/order-details/order-details.component';
import { ShopDetailsComponent } from './shop/shop-details/shop-details.component';
import { ProductViewComponent } from './products/product-view/product-view.component';
import { TariffCategoryDetailsComponent } from './tariff-category/tariff-category-details/tariff-category-details.component';
import { TariffDetailsComponent } from './tariff/tariff-details/tariff-details.component';
import { ProductCategoryDetailsComponent } from './product-category/product-category-details/product-category-details.component';

@NgModule({
  declarations: [
    // shop
    ShopComponent,
    ShopListComponent,
    // order
    OrderComponent,
    OrderListComponent,
    OrderSearchComponent,
    OrderCreateComponent,
    OrderUpdateComponent,
    // tariff
    TariffComponent,
    TariffListComponent,
    TariffCreateComponent,
    TariffUpdateComponent,
    // products
    ProductsComponent,
    ProductUpdateComponent,
    ProductCreateComponent,
    ProductListComponent,
    CustomerTypeComponent,
    ProductCategoryComponent,
    ProductCategoryCreateComponent,
    ProductCategoryUpdateComponent,
    ProductCategoryListComponent,
    ProductCategoryListItemComponent,
    TariffCategoryComponent,
    TariffCategoryCreateComponent,
    TariffCategoryListComponent,
    TariffCategoryUpdateComponent,
    TariffCategoryListItemComponent,
    OrderDetailsComponent,
    ShopDetailsComponent,
    ProductViewComponent,
    TariffCategoryDetailsComponent,
    TariffDetailsComponent,
    ProductCategoryDetailsComponent,
  ],
  imports: [
    BaseModule,
    ControlPanelSharedModule
  ]
})
export class FinancialModule { }
