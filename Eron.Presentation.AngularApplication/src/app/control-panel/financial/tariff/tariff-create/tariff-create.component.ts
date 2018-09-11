import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BreadCrump } from '../../../../base/models/breadCrump.model';
import { UrlNamePair } from '../../../../base/models/urlNamePair.model';
import { SelectList } from '../../../infrastructure/models/selectList.model';
import { SelectListService } from '../../../infrastructure/services/selectList.service';
import { TariffItem } from '../tariffItem.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Tariff } from '../tariff.model';
import { TariffService } from '../tariff.service';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { TariffCategoryService } from '../../tariff-category/tariff-category.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { DropzoneConfig } from 'ngx-dropzone-wrapper/dist/lib/dropzone.interfaces';
import { EronFile } from '../../../../base/models/EronFile.model';
import { FileService } from '../../../../base/services/file.service';

@Component({
  selector: 'tariff-create',
  templateUrl: './tariff-create.component.html',
  styleUrls: ['./tariff-create.component.scss']
})
export class TariffCreateComponent implements OnInit {

  breadCrump: BreadCrump;
  customerTypes: SelectList[];
  itemTypes: SelectList[];
  form: FormGroup;
  tariffItems: TariffItem[];
  submitting: boolean;
  dropzoneConfig: DropzoneConfig;
  categories: any[];
  unitTypes: any[];
  file: EronFile;
  constructor(
    private tariffService: TariffService,
    private selectListService: SelectListService,
    private fb: FormBuilder,
    private notificationService: NotificationService,
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

    selectListService.getSelectList('UnitType').subscribe((response) => {
      this.unitTypes = response;
    }, (error) => {
      console.log(error);
    });

    selectListService.getSelectList('TariffItemType').subscribe((response) => {
      this.itemTypes = response;
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

    //#region Dropzone Configuration

    this.dropzoneConfig = new DropzoneConfig({
      maxFiles: 1,
      init: function() {
        this.on('maxfilesexceeded', function(file) {
              this.removeAllFiles();
              this.addFile(file);
        });
      }
    });

    //#endregion Dropzone Configuration

    //#region tariff Items list

    this.tariffItems = [];

    this.tariffItems.push({
      name: '',
      type: 1
    } as TariffItem);

    //#endregion

  }

  ngOnInit() {
  }

  onCreateItem() {
    this.tariffItems.push({
      name: '',
      type: 1
    } as TariffItem);
  }

  onDeleteItem(index: number) {
    this.tariffItems.splice(index, 1);
  }

  onSubmitForm(model: Tariff) {
    this.submitting = true;
    model.imageId = this.file.id;
    model.tariffItems = this.tariffItems.map(function(x) {
      return {tariffItemType: x.type, name: x.name};
    });
    this.tariffService.createTariff(model)
    .subscribe(
      (response) => {
        this.notificationService.successfulOperation('ثبت تعرفه');
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
