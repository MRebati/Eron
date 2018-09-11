import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CartComponent } from './financial/cart/cart.component';
import { ProductsComponent } from './financial/products/products.component';
import { ProductDetailsComponent } from './financial/product-details/product-details.component';
import { CheckoutComponent } from './financial/checkout/checkout.component';
import { WebPageComponent } from './page/web-page/web-page.component';
import { NotFoundErrorComponent } from './page/not-found-error/not-found-error.component';
import { OrderComponent } from './financial/order/order.component';
import { OrderCategoryListComponent } from './financial/order/order-categories/order-category-list/order-category-list.component';
import { OrderListComponent } from './financial/order/order-list/order-list.component';
import { OrderItemComponent } from './financial/order/order-item/order-item.component';
import { MyOrdersComponent } from './financial/my-orders/my-orders.component';
import { InvoiceListComponent } from './financial/invoices/invoice-list/invoice-list.component';
import { InvoiceDetailsComponent } from './financial/invoices/invoice-details/invoice-details.component';
import { InvoicesComponent } from './financial/invoices/invoices.component';
import { UserComponent } from './user/user.component';
import { UserDetailComponent } from './user/user-detail/user-detail.component';
import { ChangePasswordComponent } from './user/change-password/change-password.component';
import { MobileConfirmationComponent } from './user/mobile-confirmation/mobile-confirmation.component';
import { ChangePictureComponent } from './user/change-picture/change-picture.component';
import { TransactionsComponent } from './user/transactions/transactions.component';
import { WishListComponent } from './user/wish-list/wish-list.component';
import { NewsletterComponent } from './user/newsletter/newsletter.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { ModalLoginComponent } from '../authentication/modal/login/modal-login.component';
import { InvoicePaymentSendComponent } from './financial/invoices/invoice-payment-send/invoice-payment-send.component';
import { NoInvoiceComponent } from './financial/invoices/no-invoice/no-invoice.component';
import { MyOrderDetailsComponent } from './financial/my-orders/my-order-details/my-order-details.component';
import { SearchComponent } from './search/search.component';
import { ForwardToBankComponent } from './financial/bank/forward-to-bank/forward-to-bank.component';

const routes = [
  { path: 'shop', component: HomeComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'products/category/:categoryName/:categoryId', component: ProductsComponent },
  { path: 'product/:productCode/:productName', component: ProductDetailsComponent },
  {
    path: 'order', component: OrderComponent,
    children: [
      { path: '', component: OrderCategoryListComponent },
      { path: 'category/:id/:name', component: OrderListComponent },
      { path: 'details/:id/:name', component: OrderListComponent },
      { path: 'submit/:id/:name', component: OrderItemComponent },
    ]
  },
  {
    path: 'orders', component: MyOrdersComponent, children: [
      { path: 'details/:id', component: MyOrderDetailsComponent },
    ]
  },
  {
    path: 'invoices', component: InvoicesComponent, children: [
      {
        path: '', component: InvoiceListComponent, children: [
          { path: 'details/:id', component: InvoiceDetailsComponent },
          { path: 'pay/:id', component: InvoicePaymentSendComponent },
          { path: 'sendtobank/:id', component: ForwardToBankComponent },
          { path: 'callback/:id', component: InvoicePaymentSendComponent },
          { path: '', component: NoInvoiceComponent },
        ]
      },
    ]
  },
  { path: 'search/:searchQuery', component: SearchComponent },
  { path: 'cart', component: CartComponent },
  { path: 'checkout', component: CheckoutComponent },
  {
    path: 'user', component: UserComponent, children: [
      { path: 'manage', component: UserDetailComponent },
      { path: 'change-password', component: ChangePasswordComponent },
      { path: 'mobile-confirmation', component: MobileConfirmationComponent },
      { path: 'change-picture', component: ChangePictureComponent },
      { path: 'transactions', component: TransactionsComponent },
      { path: 'newsletter', component: NewsletterComponent },
      { path: 'wish-list', component: WishListComponent },
    ]
  },
  { path: 'contact', component: ContactUsComponent },
  { path: 'contactus', redirectTo: 'contact' },
  { path: 'contact-us', redirectTo: 'contact' },
  { path: '404', component: NotFoundErrorComponent },
  { path: '**', component: WebPageComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WebSiteRouting { }
