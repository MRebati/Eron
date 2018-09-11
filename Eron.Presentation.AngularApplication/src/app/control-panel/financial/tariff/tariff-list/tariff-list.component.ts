import { Component, OnInit } from '@angular/core';
import { CommonService } from '../../../infrastructure/services/common.service';
import { Router } from '@angular/router';
import { UrlNamePair } from '../../../../base/models/urlNamePair.model';
import { BreadCrump } from '../../../../base/models/breadCrump.model';
import { Tariff } from '../tariff.model';
import { TariffService } from '../tariff.service';
import { ToastsManager } from 'ng2-toastr';
import { CustomerTypeComponent } from '../../../../base/components/customer-type/customer-type.component';
import { Http } from '@angular/http';
import { ServerDataSource } from 'ng2-smart-table';
import { Api } from '../../../../base/api';
import { Button } from '../../../../base/models/button.model';
import { Title } from '@angular/platform-browser';
import { Config } from '../../../../app.config';
import { NotificationService } from '../../../../base/services/notification.service';
import { PubSubService } from 'angular2-pubsub';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'tariff-list',
  templateUrl: './tariff-list.component.html',
  styleUrls: ['./tariff-list.component.scss']
})
export class TariffListComponent implements OnInit {

  tariffList: any[] = [];
  tableSettings: any;
  breadCrump: BreadCrump;
  tableData: Tariff[];
  tableRequest: any;
  source: ServerDataSource;
  deleteSubscription: Subscription;
  listSubscription: Subscription;
  constructor(
    private http: Http,
    private router: Router,
    private commonService: CommonService,
    private tariffService: TariffService,
    public toastr: ToastsManager,
    public titleService: Title,
    public notificationService: NotificationService,
    private subService: PubSubService
  ) {

    this.breadCrump = {
      Title: 'تعرفه ها',
      DarkBackground: true,
      FirstNode: new UrlNamePair('داشبورد', '/controlpanel/dashboard'),
      SecondNode: new UrlNamePair('مدیریت تعرفه ها'),
      ThirdNode: new UrlNamePair('لیست همه'),
      Button: [
        {
          ButtonText: 'ثبت تعرفه',
          ButtonClass: 'btn btn-success btn-outline',
          ButtonIconClass: 'fa fa-save',
          Url: '/controlpanel/tariff/create'
        } as Button
      ]
    } as BreadCrump;

    this.titleService.setTitle(Config.defaultTitle + 'مدیریت تعرفه ها');

    this.listSubscription = this.tariffService.getTariffList().subscribe(
      (response) => {
        this.tariffList = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );

    this.subService.$sub('deletedSuccessfully', (response) => {
      this.listSubscription.unsubscribe();
      this.loadTariffList();
    });
  }

  loadTariffList() {
    this.listSubscription = this.tariffService.getTariffList().subscribe(
      (response) => {
        this.tariffList = response;
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  ngOnInit() {
  }

  onCreateTariff() {
    this.router.navigateByUrl('/controlpanel/tariff/create');
  }

  onUpdate(entity) {
    this.router.navigateByUrl('/controlpanel/tariff/update/' + entity.id);
    console.log(entity);
  }

  onDelete(entity) {
    this.notificationService.deleteConfirmationAlert('تعرفه ' + entity.tariffName, entity.id, Api.tariff.default, 'deletedSuccessfully');
  }

  onView(entity) {
    this.router.navigateByUrl('/controlpanel/tariff/details/' + entity.id);
  }
}
