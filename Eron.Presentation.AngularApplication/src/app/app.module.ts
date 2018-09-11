import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler, Injector } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { PubSubModule } from 'angular2-pubsub';
import { ToastModule } from 'ng2-toastr/ng2-toastr';

import { AppRoutingModule } from './app.routes';
import { SelectListService } from './control-panel/infrastructure/services/selectList.service';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { LaddaModule } from 'angular2-ladda';

import { AppComponent } from './app.component';

import { AuthenticationService } from './authentication/auth.service';
import { HttpModule } from '@angular/http';
import { HttpClient } from './base/services/app.http.service';
import { Api } from './base/api';
import { CustomToastOption } from './control-panel/infrastructure/config/CustomToastOption';
import { SweetAlertService } from 'angular-sweetalert-service';
import { TariffService } from './control-panel/financial/tariff/tariff.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastProvider } from './control-panel/infrastructure/config/ToastProvider';
import { ControlPanelModule } from './control-panel/control-panel.module';
import { AuthModule } from './authentication/auth.module';
import { CustomerTypeComponent } from './base/components/customer-type/customer-type.component';
import { CommonService } from './control-panel/infrastructure/services/common.service';
import { FinancialModule } from './control-panel/financial/financial.module';
import { DropZoneConfiguration, DropZoneEronConfig } from './control-panel/infrastructure/config/DropZoneConfiguration';
import { FileService } from './base/services/file.service';
import { ProductsService } from './control-panel/financial/products/products.service';
import { PageService } from './control-panel/base/page/page.service';
import { UserService } from './control-panel/base/user/user.service';
import { AuthGuard } from './authentication/auth.guard';
import { AdminAuthGuard } from './authentication/admin.auth.guard';
import { NavigationService } from './control-panel/base/navigation/navigation.service';
import { NotificationService } from './base/services/notification.service';
import { WebsiteComponent } from './website/website.component';
import { WebSiteModule } from './website/website.module';
import { SliderService } from './control-panel/base/slider/slider.service';
import { ProductCategoryService } from './control-panel/financial/product-category/product-category.service';
import { ToastOptions } from 'ng2-toastr/src/toast-options';
import { DROPZONE_CONFIG } from 'ngx-dropzone-wrapper';
import { CartService } from './website/financial/cart/cart.service';
import { DefaultErrorHandler } from './base/exceptionHandlers/defaultExceptionHandler';
import { TariffCategoryService } from './control-panel/financial/tariff-category/tariff-category.service';
import { DropzoneModule } from 'ngx-dropzone-wrapper/dist/lib/dropzone.module';
import { OrderService } from './website/financial/order/order.service';
import { InvoiceService } from './website/financial/invoices/invoice.service';
import { ProvinceService } from './base/services/province.service';
import { ShopService } from './control-panel/financial/shop/shop.service';
import { RecaptchaLoaderService } from 'ng2-recaptcha/recaptcha/recaptcha-loader.service';
import { AgmCoreModule } from '@agm/core';
import { ContactService } from './website/contact-us/contact-us.service';
import { InsightsService } from './base/services/insights.service';
import { WishListService } from './website/user/wish-list/wish-list.service';
import { SearchService } from './website/search/search.service';
import { AppState } from './app.service';
import { StorageService } from './base/services/storage.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  entryComponents: [
    CustomerTypeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FinancialModule,
    AuthModule,
    WebSiteModule,
    DropzoneModule.forRoot()
  ],
  providers: [
    AppState,
    AuthenticationService,
    HttpClient,
    SelectListService,
    CommonService,
    TariffService,
    ProductsService,
    FileService,
    PageService,
    SliderService,
    ProductCategoryService,
    TariffCategoryService,
    UserService,
    NavigationService,
    SweetAlertService,
    NotificationService,
    CartService,
    OrderService,
    InvoiceService,
    AuthGuard,
    AdminAuthGuard,
    ProvinceService,
    ShopService,
    ContactService,
    InsightsService,
    WishListService,
    SearchService,
    StorageService,
    {
      provide: ToastOptions,
      useClass: CustomToastOption
    },
    // new ToastProvider().forRoot(),
    {
      provide: DROPZONE_CONFIG,
      useValue: DropZoneEronConfig()
    },
    { provide: ErrorHandler, useClass: DefaultErrorHandler }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  static injector: Injector;
  constructor(public appState: AppState, injector: Injector) {
    AppModule.injector = injector;
  }
 }
