import { Component, OnInit, ViewChild } from '@angular/core';
import { TariffCategoryService } from '../tariff-category.service';
import { NotificationService } from '../../../../base/services/notification.service';
import { PubSubService } from 'angular2-pubsub';
import { EronFile } from '../../../../base/models/EronFile.model';
import { FileService } from '../../../../base/services/file.service';
import { TariffCategoryUpdateModel } from './tariff-category-update.model';
import { ActivatedRoute, Router } from '@angular/router';

declare var $: any;

@Component({
  selector: 'tariff-category-update',
  templateUrl: './tariff-category-update.component.html',
  styleUrls: ['./tariff-category-update.component.scss']
})
export class TariffCategoryUpdateComponent implements OnInit {
  dropzoneConfig = {
    maxFiles: 1
  };
  model: TariffCategoryUpdateModel;
  submitting: boolean;
  file: EronFile = {} as EronFile;
  @ViewChild('keywordsInput') keywordsInput;
  constructor(
    private tariffCategoryService: TariffCategoryService,
    private notificationService: NotificationService,
    private pubService: PubSubService,
    private fileService: FileService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.model = {} as TariffCategoryUpdateModel;

    this.activatedRoute.params.subscribe(
      param => {
        const categoryId = param['id'];

        this.tariffCategoryService.get(categoryId).subscribe(
          (response) => {
            this.model = response;
            const keywordsInput = this.keywordsInput.nativeElement;
            $(keywordsInput).importTags('');
            $(keywordsInput).importTags(response.keywords);

          }
        );
      }
    );
  }

  ngOnInit() {
  }

  save() {
    this.submitting = true;
    const keywordsInput = this.keywordsInput.nativeElement;
    $(keywordsInput).importTags('');
    // todo: check enhacement column in artin backbone board
    // [trello: 'https://trello.com/c/DB8t9vIj/14-tagsinput-directive-which-used-in-product-category-update-component-requires-to-trigger-restart-event-independently' ]
    // this.restart.next({});
    this.model.imageId = this.file.id || this.model.imageId;
    this.tariffCategoryService.update(this.model).subscribe(
      (response) => {
        this.submitting = false;
        this.pubService.$pub('productCategoryUpdateSuccess', response);
        this.router.navigateByUrl('/controlpanel/tariffcategories');
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
    this.model = {} as TariffCategoryUpdateModel;
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
