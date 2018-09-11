import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from '../../../../base/services/notification.service';
import { TariffService } from '../tariff.service';
import { FormGroup } from '@angular/forms';
import { SelectListService } from '../../../infrastructure/services/selectList.service';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FileService } from '../../../../base/services/file.service';
import { TariffCategoryService } from '../../tariff-category/tariff-category.service';
import { UrlNamePair } from '../../../../base/models/urlNamePair.model';
import { BreadCrump } from '../../../../base/models/breadCrump.model';
import { SelectListItem } from '../../../../base/models/SelectList.model';
import { TariffItem } from '../tariffItem.model';
import { Tariff } from '../tariff.model';
import { EronFile } from '../../../../base/models/EronFile.model';
import { DropzoneConfig } from 'ngx-dropzone-wrapper/dist/lib/dropzone.interfaces';

@Component({
  selector: 'tariff-update',
  templateUrl: './tariff-update.component.html',
  styleUrls: ['./tariff-update.component.scss']
})
export class TariffUpdateComponent implements OnInit {

  tariffId: string;
  form: FormGroup;
  breadCrump: BreadCrump;
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
            this.file.id = response.imageId;
            this.form.patchValue(response);
            this.tariffItems = response.tariffItems;
          },
          (error) => {
            this.notificationService.serverError(error);
          }
        );
      }
    );

    //#region Dropzone Configuration

    this.dropzoneConfig = new DropzoneConfig({
      maxFiles: 1,
      init: function () {
        this.on('maxfilesexceeded', function (file) {
          this.removeAllFiles();
          this.addFile(file);
        });
      }
    });

    //#endregion Dropzone Configuration
  }

  ngOnInit() {
  }

  onCreateItem() {
    this.tariffItems.push({
      name: '',
      type: 1,
      tariffItemType: 1
    } as TariffItem);
  }

  onDeleteItem(index: number) {
    this.tariffItems.splice(index, 1);
  }

  onSubmitForm(model: Tariff) {
    this.submitting = true;
    model.id = Number.parseInt(this.tariffId);
    model.imageId = this.file.id;
    model.tariffItems = this.tariffItems;
    this.tariffService.updateTariff(model)
      .subscribe(
      (response) => {
        this.notificationService.successfulOperation('ویرایش تعرفه');
        this.router.navigateByUrl('/controlpanel/tariff');
        this.submitting = false;
        return response;
      },
      (error) => {
        this.submitting = false;
        this.notificationService.serverError();
        console.log(error);
      }
      );
  }

  onUploadSuccess($event) {
    $event[1].forEach(item => {
      const newFile = {
        name: item.fileName,
        id: item.id
      } as EronFile;
      this.file = (newFile);

      console.log(newFile);
    });
  }

  onUploadError($event) {
    this.notificationService.serverError();
  }

  onRemoveFile($event) {
    const currentRow = this.file;
    this.fileService.deleteFile(currentRow.id);
    this.file = {} as EronFile;
  }
}
