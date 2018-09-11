import { Component, OnInit, Input } from '@angular/core';
import { TariffCategoryListModel } from '../tariff-category-list.model';
import { PubSubService } from 'angular2-pubsub';
import { NotificationService } from '../../../../../base/services/notification.service';
import { Api } from '../../../../../base/api';

@Component({
  selector: '[app-tariff-category-list-item]',
  templateUrl: './tariff-category-list-item.component.html',
  styleUrls: ['./tariff-category-list-item.component.scss']
})
export class TariffCategoryListItemComponent implements OnInit {

  @Input() item: TariffCategoryListModel;
  @Input() itemList: TariffCategoryListModel[];
  children: TariffCategoryListModel[];
  constructor(
    private pubService: PubSubService,
    private notificationService: NotificationService
  ) { }

  ngOnInit() {
  }

  onUpdate() {
    this.pubService.$pub('updateTrigger', this.item);
  }

  onDelete() {
    this.notificationService.deleteConfirmationAlert(
      'مجموعه تعرفه ' + this.item.title,
      this.item.id,
      Api.tariffCategory.default,
      'deleteTariffCategorySuccess');
  }
}
