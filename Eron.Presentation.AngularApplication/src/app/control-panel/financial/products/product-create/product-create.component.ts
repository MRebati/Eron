import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { ToastsManager } from 'ng2-toastr';

import { BreadCrump } from '../../../../base/models/breadCrump.model';
import { UrlNamePair } from '../../../../base/models/urlNamePair.model';
import { SelectListService } from '../../../infrastructure/services/selectList.service';
import { SelectList } from '../../../infrastructure/models/selectList.model';
import { ProductProperty } from '../productProperty.model';
import { Common } from '../../../../base/common';
import { DropzoneConfigInterface } from 'ngx-dropzone-wrapper';
import { EronFile } from '../../../../base/models/EronFile.model';
import { FileService } from '../../../../base/services/file.service';
import { ProductCreateModel } from './productCreate.model';
import { ProductsService } from '../products.service';
import { ProductCategoryService } from '../../product-category/product-category.service';
import { ProductCategoryListModel } from '../../product-category/product-category-list/product-category-list.model';
import { NotificationService } from '../../../../base/services/notification.service';

@Component({
  selector: 'product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.scss']
})
export class ProductCreateComponent implements OnInit {

  breadCrump: BreadCrump;
  customerTypes: SelectList[];
  categories: ProductCategoryListModel[] = [];
  itemTypes: SelectList[];
  form: FormGroup;
  submitting: boolean;
  productProperties: ProductProperty[];
  formToken: string;
  fileList: EronFile[] = [];
  summernoteOptions: any = {};
  text: string;

  constructor(
    private selectListService: SelectListService,
    private fb: FormBuilder,
    private notificationService: NotificationService,
    private fileService: FileService,
    private productService: ProductsService,
    private productCategoryService: ProductCategoryService) {

    //#region form init

    this.form = fb.group({
      'productName': [null, Validators.required],
      'productPrice': [null, Validators.required],
      'productCode': [null, Validators.required],
      'productCategoryId': [null, Validators.required],
      'shortDescription': [null, Validators.required],
      'longDescription': [null, null],
      'formToken': [null, null]
    });

    //#endregion

    //#region breadCrump

    this.breadCrump = {
      Title: 'محصولات',
      DarkBackground: true,
      FirstNode: new UrlNamePair('داشبورد', '/controlpanel/dashboard'),
      SecondNode: new UrlNamePair('مدیریت محصولات'),
      ThirdNode: new UrlNamePair('افزودن محصول جدید')
    } as BreadCrump;

    //#endregion

    //#region form token

    this.formToken = Common.generateString(5);
    this.form.controls['productCode'].setValue(this.generateNewProductCode());
    //#endregion

    //#region init product properties

    this.productProperties = [
      {
        propertyName: '',
        propertyValue: ''
      }
    ];

    //#endregion

    //#region categories

    this.productCategoryService.getFlatCategories().subscribe(
      (response) => {
        this.categories = response;
      },
      (error) => {
        console.log(error);
        this.notificationService.serverError();
      }
    );

    //#endregion
  }

  ngOnInit() {
  }

  generateNewProductCode(): string {
    const year = Common.currentYear2Digit();
    const randomNumbers = Common.generateNumber(5).toFixed();
    const randomDigits = Common.generateString(3).toUpperCase();
    const productCode = 'CH-' + year + randomNumbers + '-' + randomDigits;
    return productCode;
  }

  onCreateNewProperty() {
    const newItem = {
      propertyName: '',
      propertyValue: ''
    };
    this.productProperties.push(newItem);
  }

  onDeleteProperty(index: number) {
    this.productProperties.splice(index, 1);
  }

  onUploadSuccess($event) {
    $event[1].forEach(item => {
      const newFile = {
        name: item.fileName,
        id: item.id
      } as EronFile;
      this.fileList.push(newFile);
      if (this.fileList.length === 1) {
        this.fileList[0].selected = true;
      }
    });
  }

  onRemoveFile($event) {
    const index = this.fileList.findIndex(x => x.name === $event.name);
    const currentRow = this.fileList[index];
    this.fileService.deleteFile(currentRow.id);
    this.fileList.splice(index, 1);
  }

  onSubmitForm(form: ProductCreateModel) {
    this.submitting = true;
    const imageList = [];
    this.fileList.forEach(element => {
      if (element != null && element.id != null) {
        imageList.push(element.id);
      }
    });
    form.defaultImage = this.fileList.filter(x => x.selected)[0].id;
    form.images = imageList;
    form.properties = this.productProperties;
    this.productService.saveProduct(form).subscribe(
      (response) => {
        this.submitting = false;
        this.notificationService.successfulOperation('ثبت محصول جدید');
      },
      (error) => {
        this.submitting = false;
        console.log(error);
      }
    );
  }

  onUploadError($event) {
    this.notificationService.serverError();
  }

  fileItemChecked(file) {

  }
}
