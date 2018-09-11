import { Component, OnInit } from '@angular/core';
import { TariffCategoryService } from '../tariff-category.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { PubSubService } from 'angular2-pubsub';
import { EronFile } from '../../../../base/models/EronFile.model';
import { FileService } from '../../../../base/services/file.service';
import { TariffCategoryDetailsModel } from './tariff-category-details.model';
import { ActivatedRoute } from '@angular/router';
import { Common } from '../../../../base/common';

declare var $: any;

@Component({
  selector: 'tariff-category-details',
  templateUrl: './tariff-category-details.component.html',
  styleUrls: ['./tariff-category-details.component.scss']
})
export class TariffCategoryDetailsComponent implements OnInit {
  dropzoneConfig = {
    maxFiles: 1
  };
  model: TariffCategoryDetailsModel;
  submitting: boolean;
  file: EronFile;
  constructor(
    private tariffCategoryService: TariffCategoryService,
    private notificationService: NotificationService,
    private pubService: PubSubService,
    private fileService: FileService,
    private activatedRoute: ActivatedRoute
  ) {
    this.model = {} as TariffCategoryDetailsModel;


    this.activatedRoute.params.subscribe(
      param => {
        const categoryId = param['id'];
        this.tariffCategoryService.get(categoryId).subscribe(
          (response) => {
            this.model = response;
            this.model.imageAddress = Common.getImageAddress(response.imageId);
          }
        );
      }
    );
  }

  ngOnInit() {
  }

  restartModel() {
    this.model = {} as TariffCategoryDetailsModel;
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
