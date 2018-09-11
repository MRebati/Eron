import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DropzoneModule } from 'ngx-dropzone-wrapper';
import { DropZoneConfiguration, DropZoneEronConfig } from '../control-panel/infrastructure/config/DropZoneConfiguration';
import { SummernoteModule, Summernote } from 'ng2-summernote-angular4';
import { SummernoteDirective } from '../control-panel/infrastructure/directives/summernote.directive';
import { ICheckDirective } from '../control-panel/infrastructure/directives/icheck.directive';
import { TagsInputDirective } from '../control-panel/infrastructure/directives/tagsinput.directive';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { LaddaModule } from 'angular2-ladda';
import { PubSubModule } from 'angular2-pubsub';
import { ToastModule } from 'ng2-toastr/src/toast.module';
import { NestableDirective } from '../control-panel/infrastructure/directives/nestable.directive';
import { TagsInputWithModelDirective } from '../control-panel/infrastructure/directives/tagsinputWithModel.directive';
import { OwlModule } from 'ngx-owl-carousel';
import {NgxPaginationModule} from 'ngx-pagination';
import { CurrencyMaskModule } from 'ng2-currency-mask';
import { PriceRialPipe } from './pipes/priceRial.pipe';
import { PriceTomanPipe } from './pipes/priceToman.pipe';
import { JalaliPipe } from './pipes/jalali.pipe';
import { CKEditorModule } from 'ngx-ckeditor';
import { IsParentPipe } from './pipes/isParent.pipe';
import { DROPZONE_CONFIG } from 'ngx-dropzone-wrapper/dist/lib/dropzone.module';
import { ICheckWithModelDirective } from '../control-panel/infrastructure/directives/icheckWithModel.directive';
import { BadgeComponent } from './components/badge-component/badge-component.component';
import { OrderStatusPipe } from './pipes/order-status.pipe';
import { OrderStatusColorPipe } from './pipes/order-status-color.pipe';
import { DefaultFilterPipe } from './pipes/filter.pipe';
import { LikeFilterPipe } from './pipes/filter-like.pipe';
import { SlugPipe } from './pipes/slug.pipe';
import { ModalModule } from 'ngx-modal';
import { InvoiceStatusColorPipe } from './pipes/invoice-status-color.pipe';
import { InvoiceStatusPipe } from './pipes/invoice-status.pipe';
import { RecaptchaModule, RecaptchaLoaderService } from 'ng2-recaptcha';
import { CheckboxComponent } from './components/checkbox/checkbox.component';
import { RadioComponent } from './components/radio/radio.component';
import { InvoiceTypePipe } from './pipes/invoice-type.pipe';
import { AgmCoreModule } from '@agm/core/core.module';
import { ModalLoginComponent } from '../authentication/modal/login/modal-login.component';

@NgModule({
  declarations: [
    SummernoteDirective,
    ICheckDirective,
    ICheckWithModelDirective,
    TagsInputDirective,
    NestableDirective,
    TagsInputWithModelDirective,
    BadgeComponent,
    IsParentPipe,
    PriceRialPipe,
    PriceTomanPipe,
    OrderStatusPipe,
    OrderStatusColorPipe,
    InvoiceStatusPipe,
    InvoiceTypePipe,
    InvoiceStatusColorPipe,
    JalaliPipe,
    DefaultFilterPipe,
    LikeFilterPipe,
    SlugPipe,
    CheckboxComponent,
    RadioComponent,
    ModalLoginComponent
  ],
  imports: [
    RouterModule,
    FormsModule,
    HttpModule,
    ReactiveFormsModule,
    DropzoneModule.forChild(),
    Ng2SmartTableModule,
    LaddaModule,
    CurrencyMaskModule,
    NgxPaginationModule,
    CKEditorModule,
    ModalModule,
    // OwlModule,
    PubSubModule.forRoot(),
    ToastModule.forRoot(),
    RecaptchaModule.forRoot(),
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyCs8nSEumLi8FjQrodnZEWl4H36P_UpTow'
    })
  ],
  exports: [
    CommonModule,
    RouterModule,
    FormsModule,
    HttpModule,
    ReactiveFormsModule,
    DropzoneModule,
    SummernoteDirective,
    ICheckDirective,
    ICheckWithModelDirective,
    TagsInputDirective,
    TagsInputWithModelDirective,
    BadgeComponent,
    CheckboxComponent,
    ModalLoginComponent,
    RadioComponent,
    NestableDirective,
    IsParentPipe,
    PriceRialPipe,
    PriceTomanPipe,
    OrderStatusPipe,
    InvoiceTypePipe,
    OrderStatusColorPipe,
    InvoiceStatusPipe,
    InvoiceStatusColorPipe,
    JalaliPipe,
    DefaultFilterPipe,
    LikeFilterPipe,
    SlugPipe,
    Ng2SmartTableModule,
    LaddaModule,
    CurrencyMaskModule,
    NgxPaginationModule,
    CKEditorModule,
    ModalModule,
    RecaptchaModule,
    ToastModule,
    PubSubModule,
    AgmCoreModule,
  ],
  providers: [
    {
      provide: DROPZONE_CONFIG,
      useValue: DropZoneEronConfig()
    }
  ]
})
export class BaseModule { }
