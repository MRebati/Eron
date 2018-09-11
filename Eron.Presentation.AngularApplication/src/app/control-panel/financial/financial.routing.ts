import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { TariffComponent } from './tariff/tariff.component';
import { TariffListComponent } from './tariff/tariff-list/tariff-list.component';
import { TariffCreateComponent } from './tariff/tariff-create/tariff-create.component';
import { TariffUpdateComponent } from './tariff/tariff-update/tariff-update.component';
import { ShopComponent } from './shop/shop.component';
import { OrderComponent } from './order/order.component';
import { ProductsComponent } from './products/products.component';
import { ControlPanelComponent } from '../control-panel.component';
import { UserDashboardComponent } from '../user-dashboard/user-dashboard.component';

const routes: Routes = [
  {
    path: 'controlpanel', component: ControlPanelComponent, children:
      [
        {
          path: 'tariff', component: TariffComponent, children:
            [
              { path: '', component: TariffListComponent },
              { path: 'create', component: TariffCreateComponent },
              { path: 'update/:id', component: TariffUpdateComponent }
            ]
        },
        { path: 'shop', component: ShopComponent },
        { path: 'orders', component: OrderComponent },
        { path: 'products', component: ProductsComponent },
        { path: '', component: UserDashboardComponent }
      ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FinancialRoutingModule { }
