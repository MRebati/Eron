import { Component, OnInit } from '@angular/core';
import { BreadCrump } from '../../../../base/models/breadCrump.model';
import { SelectList } from '../../../infrastructure/models/selectList.model';
import { ProductCategoryListModel } from '../../product-category/product-category-list/product-category-list.model';
import { FormGroup } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { ProductProperty } from '../productProperty.model';
import { EronFile } from '../../../../base/models/EronFile.model';
import { ViewChild } from '@angular/core';
import { SelectListService } from '../../../infrastructure/services/selectList.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { FileService } from '../../../../base/services/file.service';
import { ProductsService } from '../products.service';
import { ProductCategoryService } from '../../product-category/product-category.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

import { UrlNamePair } from '../../../../base/models/urlNamePair.model';
import { Common } from '../../../../base/common';
import { ProductModel } from '../product-list/product-list.model';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.scss']
})
export class ProductViewComponent implements OnInit {
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
  @ViewChild('summernote') summernoteElement;
  @ViewChild('dropzone') dropZoneElement;
  text: string;
  productNumber: string;
  productId: number;
  existsInShop = true;
  model: any = {};
  constructor(
    private selectListService: SelectListService,
    private fb: FormBuilder,
    private notificationService: NotificationService,
    private fileService: FileService,
    private productService: ProductsService,
    private productCategoryService: ProductCategoryService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {

    //#region form init

    this.form = fb.group({
      'productName': [{disabled: true}, Validators.required],
      'productPrice': [{disabled: true}, Validators.required],
      'productCode': [{disabled: true}, Validators.required],
      'productCategoryId': [{disabled: true}, Validators.required],
      'shortDescription': [{disabled: true}, Validators.required],
      'longDescription': [{disabled: true}, null],
      'formToken': [{disabled: true}, null]
    });

    //#endregion

    //#region breadCrump

    this.breadCrump = {
      Title: 'محصولات',
      DarkBackground: true,
      FirstNode: new UrlNamePair('داشبورد', '/controlpanel/dashboard'),
      SecondNode: new UrlNamePair('مدیریت محصولات', '/controlpanel/products'),
      ThirdNode: new UrlNamePair('نمایش محصول')
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

    this.activatedRoute.params.subscribe(
      param => {
        this.productNumber = param['id'];
        this.productService.getByProductCodeForUpdate(this.productNumber).subscribe(
          (response) => {
            this.model = response;
            this.form.patchValue(response);
            this.productId = response.id;
            this.existsInShop = response.existsInShop;
            const summernoteElement = this.summernoteElement.nativeElement;

            $(summernoteElement).parent().find('.note-editable').html(response.longDescription);

            this.productProperties = response.properties;

            response.images.forEach(image => {
              const num = response.images.indexOf(image) + 1;
              this.fileList.push({
                id: image,
                imageAddress: Common.getImageAddress(image),
                name: 'image No ' + num,
                selected: image === response.defaultImage
              } as EronFile);
            });
          },
          (error) => {
            this.notificationService.serverError(error);
          }
        );
      }
    );
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
        id: item.id,
        imageAddress: Common.getImageAddress(item.id)
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

  onRemoveVirtualFile($event) {
    const index = this.fileList.findIndex(x => x.name === $event.name);
    const currentRow = this.fileList[index];
    this.fileList.splice(index, 1);
  }

  onUploadError($event) {
    this.notificationService.serverError();
  }
}
