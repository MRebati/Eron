import { NgModule } from '@angular/core';

import { BaseModule } from '../base/base.module';
import { ControlPanelSharedModule } from './control-panel.shared.module';
import { FinancialModule } from './financial/financial.module';
import { ControlPanelRoutingModule } from './control-panel.routing';

import { DefaultComponent } from './default/default.component';
import { ControlPanelComponent } from './control-panel.component';
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';
import { InsightComponent } from './insight/insight.component';
import { SupportComponent } from './support/support.component';

import {
  BlogComponent,
  BlogListComponent,
  BlogCreateComponent,
  BlogUpdateComponent
} from './blog';

import {
  SideComponent,
  HeaderComponent,
  FooterComponent,
  RightSideComponent,
  SkinConfigComponent
} from './layout';

import {
  PageComponent,
  MenuComponent,
  SocialComponent,
  LinkComponent,
  NavigationComponent,
  PageCreateComponent,
  PageUpdateComponent,
  PageListComponent,
  UserComponent,
  UserCreateComponent,
  UserListComponent,
  UserUpdateComponent,
  FooterCreateComponent,
  LinkItemComponent,
  MenuCreateComponent,
  SliderComponent,
  SliderListComponent,
  SliderCreateComponent,
  SliderUpdateComponent,
  UserDetailsComponent,
  LinkDetailsComponent,
  LinkUpdateComponent,
  NotFoundComponent
} from './base';
import { BlogDashboardComponent } from './default/blog-dashboard/blog-dashboard.component';
import { FinancialDashboardComponent } from './default/financial-dashboard/financial-dashboard.component';

@NgModule({
  declarations: [
    SideComponent,
    HeaderComponent,
    FooterComponent,
    DefaultComponent,
    RightSideComponent,
    SkinConfigComponent,
    ControlPanelComponent,
    UserDashboardComponent,
    InsightComponent,
    SupportComponent,
    PageComponent,
    MenuComponent,
    SocialComponent,
    LinkComponent,
    NavigationComponent,
    PageCreateComponent,
    PageUpdateComponent,
    PageListComponent,
    UserComponent,
    UserCreateComponent,
    UserListComponent,
    UserUpdateComponent,
    FooterCreateComponent,
    LinkItemComponent,
    MenuCreateComponent,
    SliderComponent,
    SliderListComponent,
    SliderCreateComponent,
    SliderUpdateComponent,
    UserDetailsComponent,
    LinkDetailsComponent,
    LinkUpdateComponent,
    BlogComponent,
    BlogListComponent,
    BlogCreateComponent,
    BlogUpdateComponent,
    NotFoundComponent,
    BlogDashboardComponent,
    FinancialDashboardComponent
  ],
  imports: [
    BaseModule,
    ControlPanelSharedModule,
    FinancialModule,
    ControlPanelRoutingModule
  ]
})
export class ControlPanelModule {}
