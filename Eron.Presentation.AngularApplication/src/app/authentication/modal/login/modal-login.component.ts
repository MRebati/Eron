import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../auth.service';
import { PubSubService } from 'angular2-pubsub';
import { LoginViewModel } from '../../login.model';
import { Router } from '@angular/router';
import { NotificationService } from '../../../base/services/notification.service';
import { ViewChild } from '@angular/core';
import { Modal } from 'ngx-modal';
import { Subscription } from 'rxjs/Subscription';
import { OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';
import { RecaptchaComponent } from 'ng2-recaptcha/recaptcha/recaptcha.component';
import { StorageService } from '../../../base/services/storage.service';

@Component({
  selector: 'app-modal-login',
  templateUrl: './modal-login.component.html',
  styleUrls: ['./modal-login.component.scss']
})
export class ModalLoginComponent implements OnInit, OnDestroy {
  redirectUrl: string;
  @ViewChild('modal') modal: Modal;
  @ViewChild('recaptcha') recaptcha: RecaptchaComponent;
  loginModel: LoginViewModel = {} as LoginViewModel;
  modalIsOpen = false;
  subscription: Subscription;
  submitting = false;
  constructor(
    private authService: AuthenticationService,
    private pubSubService: PubSubService,
    private router: Router,
    private notificationService: NotificationService,
    public storageService: StorageService
  ) {
    this.subscription = this.pubSubService.$sub('openLoginModal').subscribe(
      (response) => {
        this.modal.open();
        this.modalIsOpen = true;
      }
    );
  }

  ngOnInit() {
  }

  onLogin() {
    this.submitting = true;
    this.authService.login(this.loginModel).subscribe(
      (Response) => {
        const loginResponse = Response;
        // this.submitting = false;
        this.storageService.setItem('userName', loginResponse.userName);
        this.storageService.setItem('accessToken', loginResponse.access_token);
        this.storageService.setItem('refreshToken', loginResponse.refresh_token);
        this.pubSubService.$pub('login');
        this.modal.close();
        this.notificationService.successfulOperationWithAlert('خوش آمدید', '');
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

  resolved(captchaResponse: string) {
    this.loginModel.CaptchaResponse = captchaResponse;
  }


  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
