import { Component, OnInit } from '@angular/core';
import { ChangePasswordModel } from './change-password.model';
import { UserService } from '../../../control-panel/base/user/user.service';
import { NotificationService } from '../../../base/services/notification.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {
  model: ChangePasswordModel;
  constructor(
    private userService: UserService,
    public notificationService: NotificationService
  ) {
    this.model = {} as ChangePasswordModel;
  }

  ngOnInit() {
  }

  onSubmit() {
    this.userService.changePassword(this.model).subscribe(
      (response) => {
        this.notificationService.successfulOperation('تغییر رمز عبور');
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

}
