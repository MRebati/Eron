import { Component, OnInit } from '@angular/core';
import { TariffCategoryCreateModel } from './tariff-category-create.model';
import { TariffCategoryService } from '../tariff-category.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { PubSubService } from 'angular2-pubsub';
import { EronFile } from '../../../../base/models/EronFile.model';
import { FileService } from '../../../../base/services/file.service';

declare var $: any;

@Component({
  selector: 'tariff-category-create',
  templateUrl: './tariff-category-create.component.html',
  styleUrls: ['./tariff-category-create.component.scss']
})
export class TariffCategoryCreateComponent implements OnInit {
  dropzoneConfig = {
    maxFiles: 1
  };
  model: TariffCategoryCreateModel;
  submitting: boolean;
  file: EronFile;
  constructor(
    private productCategoryService: TariffCategoryService,
    private notificationService: NotificationService,
    private pubService: PubSubService,
    private fileService: FileService
  ) {
    this.model = {} as TariffCategoryCreateModel;
  }

  ngOnInit() {
  }

  save(keywordsInput) {
    this.submitting = true;
    $(keywordsInput).importTags('');
    // todo: check enhacement column in artin backbone board
    // [trello: 'https://trello.com/c/DB8t9vIj/14-tagsinput-directive-which-used-in-product-category-create-component-requires-to-trigger-restart-event-independently' ]
    // this.restart.next({});
    this.model.imageId = this.file.id;
    this.productCategoryService.create(this.model).subscribe(
      (response) => {
        this.submitting = false;
        this.pubService.$pub('productCategoryCreateSuccess', response);
      },
      (error) => {
        this.submitting = false;
        this.notificationService.serverError();
        console.log(error);
      }
    );

    this.restartModel();
  }

  restartModel() {
    this.model = {} as TariffCategoryCreateModel;
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
