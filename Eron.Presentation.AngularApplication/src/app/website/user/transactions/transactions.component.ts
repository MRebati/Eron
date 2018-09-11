import { Component, OnInit } from '@angular/core';
import { UserModel } from '../user.model';
import { ProvinceService } from '../../../base/services/province.service';
import { UserService } from '../../../control-panel/base/user/user.service';
import { NotificationService } from '../../../base/services/notification.service';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.scss']
})
export class TransactionsComponent implements OnInit {
  provinceList: any[] = [];
  cityList: any[] = [];
  user: UserModel;
  constructor(
    private provinceService: ProvinceService,
    private userService: UserService,
    public notificationService: NotificationService
  ) {
    this.provinceList = this.provinceService.getProvincesList();
    this.user = {} as UserModel;
    this.userService.getUserInfo().subscribe(
      (response) => {
        this.user = response;
        this.provinceChanged();
        this.user.cityName = response.cityName;
      }
    );
  }

  ngOnInit() {
  }

  provinceChanged() {
    this.cityList = this.provinceService.getCityByName(this.user.provinceName);
  }

  onSubmit() {
    this.userService.updateUser(this.user).subscribe(
      (response) => {
        this.notificationService.successfulOperation('ویرایش اطلاعات کاربری');
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

}
