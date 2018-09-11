import { NgModule } from '@angular/core';
import { WebsiteComponent } from './website.component';
import { WebSiteRouting } from './website.routing';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { MenuComponent } from './layout/header/menu/menu.component';
import { HeaderSearchComponent } from './layout/header/header-search/header-search.component';
import { TopSliderComponent } from './home/top-slider/top-slider.component';
import { MiddleBannersComponent } from './home/middle-banners/middle-banners.component';
import { BottomBannersComponent } from './home/bottom-banners/bottom-banners.component';
import { CategorizedProductsComponent } from './home/product-sliders/categorized-products/categorized-products.component';
import { ClientsComponent } from './home/clients/clients.component';
import { FeaturedComponent } from './home/featured/featured.component';
import { FeaturedProductsComponent } from './home/product-sliders/featured-products/featured-products.component';
import { BestSellingProductsComponent } from './home/product-sliders/best-selling-products/best-selling-products.component';
import { CartComponent } from './financial/cart/cart.component';
import { FinancialComponent } from './financial/financial.component';
import { ProductsComponent } from './financial/products/products.component';
import { ProductDetailsComponent } from './financial/product-details/product-details.component';
import { CheckoutComponent } from './financial/checkout/checkout.component';
import { BestSellerComponent } from './financial/products/side/best-seller/best-seller.component';
import { CategoriesComponent } from './financial/products/side/categories/categories.component';
import { CategoryItemComponent } from './financial/products/side/categories/category-item/category-item.component';
import { BaseModule } from '../base/base.module';
import { SliderViewComponent } from './base/components/slider/slider-view/slider-view.component';
import { MenuListComponent } from './layout/header/menu/menu-list/menu-list.component';
import { MenuListItemComponent } from './layout/header/menu/menu-list/menu-list-item/menu-list-item.component';
import { WebPageComponent } from './page/web-page/web-page.component';
import { NotFoundErrorComponent } from './page/not-found-error/not-found-error.component';
import { MenuShopListComponent } from './layout/header/menu/menu-shop-list/menu-shop-list.component';
import { MenuShopListItemComponent } from './layout/header/menu/menu-shop-list/menu-shop-list-item/menu-shop-list-item.component';
import { ProductItemComponent } from './financial/products/product-item/product-item.component';
import { ProductListComponent } from './financial/products/product-list/product-list.component';
import { OrderComponent } from './financial/order/order.component';
import { OrderCategoriesComponent } from './financial/order/order-categories/order-categories.component';
import { OrderListComponent } from './financial/order/order-list/order-list.component';
import { OrderItemComponent } from './financial/order/order-item/order-item.component';
import { OrderCategoryListComponent } from './financial/order/order-categories/order-category-list/order-category-list.component';
import { OrderListItemComponent } from './financial/order/order-list/order-list-item/order-list-item.component';
import { OrderCategoryListItemComponent } from './financial/order/order-categories/order-category-list/order-category-list-item/order-category-list-item.component';
import { MyOrdersComponent } from './financial/my-orders/my-orders.component';
import { InvoiceListComponent } from './financial/invoices/invoice-list/invoice-list.component';
import { InvoiceDetailsComponent } from './financial/invoices/invoice-details/invoice-details.component';
import { InvoicePaymentSendComponent } from './financial/invoices/invoice-payment-send/invoice-payment-send.component';
import { InvoicePaymentReceiveComponent } from './financial/invoices/invoice-payment-receive/invoice-payment-receive.component';
import { InvoicesComponent } from './financial/invoices/invoices.component';
import { UserComponent } from './user/user.component';
import { UserDetailComponent } from './user/user-detail/user-detail.component';
import { ChangePasswordComponent } from './user/change-password/change-password.component';
import { MobileConfirmationComponent } from './user/mobile-confirmation/mobile-confirmation.component';
import { ChangePictureComponent } from './user/change-picture/change-picture.component';
import { TransactionsComponent } from './user/transactions/transactions.component';
import { NewsletterComponent } from './user/newsletter/newsletter.component';
import { WishListComponent } from './user/wish-list/wish-list.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { NoInvoiceComponent } from './financial/invoices/no-invoice/no-invoice.component';
import { MyOrderDetailsComponent } from './financial/my-orders/my-order-details/my-order-details.component';
import { SearchComponent } from './search/search.component';
import { OrderSliderComponent } from './home/order-slider/order-slider.component';
import { ForwardToBankComponent } from './financial/bank/forward-to-bank/forward-to-bank.component';

@NgModule({
  declarations: [
    WebsiteComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    MenuComponent,
    CartComponent,
    HeaderSearchComponent,
    TopSliderComponent,
    MiddleBannersComponent,
    BottomBannersComponent,
    CategorizedProductsComponent,
    ClientsComponent,
    FeaturedComponent,
    FeaturedProductsComponent,
    BestSellingProductsComponent,
    FinancialComponent,
    ProductsComponent,
    ProductDetailsComponent,
    CheckoutComponent,
    BestSellerComponent,
    CategoriesComponent,
    CategoryItemComponent,
    SliderViewComponent,
    MenuListComponent,
    MenuListItemComponent,
    WebPageComponent,
    NotFoundErrorComponent,
    MenuShopListComponent,
    MenuShopListItemComponent,
    ProductItemComponent,
    ProductListComponent,
    OrderComponent,
    OrderCategoriesComponent,
    OrderListComponent,
    OrderItemComponent,
    OrderCategoryListComponent,
    OrderListItemComponent,
    OrderCategoryListItemComponent,
    MyOrdersComponent,
    InvoiceListComponent,
    InvoiceDetailsComponent,
    InvoicePaymentSendComponent,
    InvoicePaymentReceiveComponent,
    InvoicesComponent,
    UserComponent,
    UserDetailComponent,
    ChangePasswordComponent,
    MobileConfirmationComponent,
    ChangePictureComponent,
    TransactionsComponent,
    NewsletterComponent,
    WishListComponent,
    ContactUsComponent,
    NoInvoiceComponent,
    MyOrderDetailsComponent,
    SearchComponent,
    OrderSliderComponent,
    ForwardToBankComponent
  ],
  imports: [
    WebSiteRouting,
    BaseModule
  ]
})
export class WebSiteModule { }
