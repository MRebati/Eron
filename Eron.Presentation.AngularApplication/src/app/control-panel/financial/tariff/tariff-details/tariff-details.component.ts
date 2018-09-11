import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BreadCrump } from '../../../../base/models/breadCrump.model';
import { TariffItem } from '../tariffItem.model';
import { SelectListItem } from '../../../../base/models/SelectList.model';
import { EronFile } from '../../../../base/models/EronFile.model';
import { DropzoneConfig } from 'ngx-dropzone-wrapper';
import { Router, ActivatedRoute } from '@angular/router';
import { NotificationService } from '../../../../base/services/notification.service';
import { TariffService } from '../tariff.service';
import { SelectListService } from '../../../infrastructure/services/selectList.service';
import { TariffCategoryService } from '../../tariff-category/tariff-category.service';
import { FileService } from '../../../../base/services/file.service';
import { Tariff } from '../tariff.model';
import { UrlNamePair } from '../../../../base/models/urlNamePair.model';
import { Common } from '../../../../base/common';

@Component({
  selector: 'app-tariff-details',
  templateUrl: './tariff-details.component.html',
  styleUrls: ['./tariff-details.component.scss']
})
export class TariffDetailsComponent implements OnInit {

  tariffId: string;
  form: FormGroup;
  breadCrump: BreadCrump;
  imageAddress = '';
  tariffItems: TariffItem[] = [];
  itemTypes: SelectListItem[] = [];
  customerTypes: SelectListItem[] = [];
  categories: SelectListItem[] = [];
  unitTypes: SelectListItem[] = [];
  submitting: boolean;
  file: EronFile = {} as EronFile;
  dropzoneConfig: DropzoneConfig;
  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private notificationService: NotificationService,
    private tariffService: TariffService,
    private selectListService: SelectListService,
    private fb: FormBuilder,
    private tariffCategoryService: TariffCategoryService,
    private fileService: FileService) {

    //#region form init

    this.form = fb.group({
      'tariffName': [null, Validators.required],
      'customerType': [null, Validators.required],
      'tariffPrice': [null, Validators.required],
      'tariffCategoryId': [null, Validators.required],
      'designPrice': [null, null],
      'unitType': [null, null]
    });

    //#endregion

    //#region breadCrump

    this.breadCrump = {
      Title: 'تعرفه ها',
      DarkBackground: true,
      FirstNode: new UrlNamePair('داشبورد', '/controlpanel/dashboard'),
      SecondNode: new UrlNamePair('مدیریت تعرفه ها'),
      ThirdNode: new UrlNamePair('افزودن تعرفه جدید')
    } as BreadCrump;

    //#endregion

    //#region fill selectLists

    selectListService.getSelectList('CustomerType').subscribe((response) => {
      this.customerTypes = response;
    }, (error) => {
      console.log(error);
    });

    selectListService.getSelectList('TariffItemType').subscribe((response) => {
      this.itemTypes = response;
    }, (error) => {
      console.log(error);
    });

    selectListService.getSelectList('UnitType').subscribe((response) => {
      this.unitTypes = response;
    }, (error) => {
      console.log(error);
    });

    this.tariffCategoryService.getFlatCategories().subscribe(
      (response) => {
        this.categories = response;
      },
      (error) => {
        this.notificationService.serverError();
      }
    );
    //#endregion

    this.activatedRoute.params.subscribe(
      param => {
        this.tariffId = param['id'];
        this.tariffService.getById(Number.parseInt(this.tariffId)).subscribe(
          (response) => {
            response.tariffCategoryId = response.categoryId;
            this.imageAddress = Common.getImageAddress(response.imageId);
            this.form.patchValue(response);
            this.tariffItems = response.tariffItems;
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
}
