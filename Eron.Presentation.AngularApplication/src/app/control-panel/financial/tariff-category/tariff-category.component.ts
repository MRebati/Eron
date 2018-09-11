import { Component, OnInit } from '@angular/core';
import { BreadCrump } from '../../../base/models/breadCrump.model';
import { UrlNamePair } from '../../../base/models/urlNamePair.model';
import { PubSubService } from 'angular2-pubsub';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'app-tariff-category',
  templateUrl: './tariff-category.component.html',
  styleUrls: ['./tariff-category.component.scss']
})
export class TariffCategoryComponent implements OnInit {
  breadCrump: BreadCrump;
  constructor(
    private subService: PubSubService
  ) {
    this.breadCrump = {
      Title: 'مجموعه تعرفه ها',
      DarkBackground: true,
      FirstNode: new UrlNamePair('داشبورد', '/controlpanel/dashboard'),
      ThirdNode: new UrlNamePair('مدیریت مجموعه تعرفه ها'),
    } as BreadCrump;
  }

  ngOnInit() {
  }

  onUpdate(item) {

    console.log(item);
  }

  onCloseUpdateBox() {
  }
}
