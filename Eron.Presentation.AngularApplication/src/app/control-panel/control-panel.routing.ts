import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ControlPanelComponent } from './control-panel.component';
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';
import { InsightComponent } from './insight/insight.component';
import { PageComponent } from './base/page/page.component';
import { LinkComponent } from './base/navigation/link/link.component';
import { SupportComponent } from './support/support.component';
import { ShopComponent } from './financial/shop/shop.component';
import { OrderComponent } from './financial/order/order.component';
import { ProductsComponent } from './financial/products/products.component';
import { TariffComponent } from './financial/tariff/tariff.component';
import { TariffListComponent } from './financial/tariff/tariff-list/tariff-list.component';
import { TariffCreateComponent } from './financial/tariff/tariff-create/tariff-create.component';
import { TariffUpdateComponent } from './financial/tariff/tariff-update/tariff-update.component';
import { DefaultComponent } from './default/default.component';
import { ProductListComponent } from './financial/products/product-list/product-list.component';
import { ProductCreateComponent } from './financial/products/product-create/product-create.component';
import { ProductUpdateComponent } from './financial/products/product-update/product-update.component';
import { PageListComponent } from './base/page/page-list/page-list.component';
import { PageCreateComponent } from './base/page/page-create/page-create.component';
import { PageUpdateComponent } from './base/page/page-update/page-update.component';
import { UserComponent } from './base/user/user.component';
import { UserListComponent } from './base/user/user-list/user-list.component';
import { UserCreateComponent } from './base/user/user-create/user-create.component';
import { UserUpdateComponent } from './base/user/user-update/user-update.component';
import { AdminAuthGuard } from '../authentication/admin.auth.guard';
import { SliderComponent } from './base/slider/slider.component';
import { SliderListComponent } from './base/slider/slider-list/slider-list.component';
import { SliderCreateComponent } from './base/slider/slider-create/slider-create.component';
import { SliderUpdateComponent } from './base/slider/slider-update/slider-update.component';
import { ProductCategoryComponent } from './financial/product-category/product-category.component';
import { ProductCategoryListComponent } from './financial/product-category/product-category-list/product-category-list.component';
import { ProductCategoryCreateComponent } from './financial/product-category/product-category-create/product-category-create.component';
import { ProductCategoryUpdateComponent } from './financial/product-category/product-category-update/product-category-update.component';
import { TariffCategoryComponent } from './financial/tariff-category/tariff-category.component';
import { TariffCategoryListComponent } from './financial/tariff-category/tariff-category-list/tariff-category-list.component';
import { TariffCategoryCreateComponent } from './financial/tariff-category/tariff-category-create/tariff-category-create.component';
import { TariffCategoryUpdateComponent } from './financial/tariff-category/tariff-category-update/tariff-category-update.component';
import { OrderDetailsComponent } from './financial/order/order-details/order-details.component';
import { OrderListComponent } from './financial/order/order-list/order-list.component';
import { ShopListComponent } from './financial/shop/shop-list/shop-list.component';
import { ShopDetailsComponent } from './financial/shop/shop-details/shop-details.component';
import { TariffCategoryDetailsComponent } from './financial/tariff-category/tariff-category-details/tariff-category-details.component';
import { UserDetailsComponent } from './base/user/user-details/user-details.component';
import { ProductViewComponent } from './financial/products/product-view/product-view.component';
import { TariffDetailsComponent } from './financial/tariff/tariff-details/tariff-details.component';
import { ProductCategoryDetailsComponent } from './financial/product-category/product-category-details/product-category-details.component';

const routes: Routes = [{
  path: '',
  component: ControlPanelComponent,
  canActivate: [AdminAuthGuard],
  // loadChildren: 'app/control-panel/control-panel.module#ControlPanelModule',
  children:
    [
      { path: 'dashboard', component: DefaultComponent },
      { path: 'insight', component: InsightComponent },
      {
        path: 'pages', component: PageComponent, children:
          [
            { path: '', component: PageListComponent },
            { path: 'create', component: PageCreateComponent },
            { path: 'update/:id', component: PageUpdateComponent }
          ]
      },
      {
        path: 'sliders', component: SliderComponent, children:
          [
            { path: 'create', component: SliderCreateComponent },
            { path: 'updte/:id', component: SliderUpdateComponent },
            { path: '', component: SliderListComponent },
          ]
      },
      { path: 'links', component: LinkComponent },
      {
        path: 'users', component: UserComponent, children:
          [
            { path: '', component: UserListComponent },
            { path: 'create', component: UserCreateComponent },
            { path: 'update/:id', component: UserUpdateComponent },
            { path: 'details/:id', component: UserDetailsComponent }
          ]
      },
      { path: 'support', component: SupportComponent },
      {
        path: 'tariff', component: TariffComponent, children:
          [
            { path: '', component: TariffListComponent },
            { path: 'create', component: TariffCreateComponent },
            { path: 'update/:id', component: TariffUpdateComponent },
            { path: 'details/:id', component: TariffDetailsComponent }
          ]
      },
      {
        path: 'tariffcategories', component: TariffCategoryComponent, children:
          [
            { path: '', component: TariffCategoryCreateComponent },
            { path: 'update/:id', component: TariffCategoryUpdateComponent },
            { path: 'details/:id', component: TariffCategoryDetailsComponent },
          ]
      },
      {
        path: 'shop', component: ShopComponent, children: [
          {
            path: '', component: ShopListComponent, children: [
              { path: 'invoice/details/:id', component: ShopDetailsComponent }
            ]
          }
        ]

      },
      {
        path: 'orders', component: OrderComponent, children: [
          { path: 'details/:id', component: OrderDetailsComponent }
        ]
      },
      {
        path: 'products', component: ProductsComponent, children:
          [
            { path: '', component: ProductListComponent },
            { path: 'create', component: ProductCreateComponent },
            { path: 'update/:id', component: ProductUpdateComponent },
            { path: 'details/:id', component: ProductViewComponent },
          ]
      },
      {
        path: 'productcategories', component: ProductCategoryComponent, children:
          [
            { path: '', component: ProductCategoryCreateComponent },
            { path: 'update/:id', component: ProductCategoryUpdateComponent },
            { path: 'details/:id', component: ProductCategoryDetailsComponent },
          ]
      },
      { path: '', component: DefaultComponent }
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ControlPanelRoutingModule {
  public ControlPanelRoutes = routes[0];
}
