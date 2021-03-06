import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginViewModel } from '../login.model';
import { AuthenticationService } from '../auth.service';
import { Http } from '@angular/http';
import { AdminAuthGuard } from '../admin.auth.guard';
import { Config } from '../../app.config';
import { NotificationService } from '../../base/services/notification.service';
import { RecaptchaComponent } from 'ng2-recaptcha/recaptcha/recaptcha.component';
import { StorageService } from '../../base/services/storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  currentYear = new Date().getFullYear();
  form: FormGroup;
  submitting: boolean;
  applicationName = Config.application.name;
  applicationDescription = Config.application.description;
  applicationCharacters = Config.application.heroChars;
  captchaResponse: string;
  @ViewChild('recaptcha') recaptcha: RecaptchaComponent;
  constructor(
    private router: Router,
    private fb: FormBuilder,
    private authService: AuthenticationService,
    private authGuard: AdminAuthGuard,
    private notificationService: NotificationService,
    public storageService: StorageService
  ) {
    this.form = fb.group({
      'UserName': ['', Validators.compose([Validators.required, Validators.minLength(5), Validators.email])],
      'Password': ['', Validators.required]
    });
  }
  ngOnInit() {
  }

  onSubmit(form: LoginViewModel) {
    this.submitting = true;
    form.CaptchaResponse = this.captchaResponse;

    this.authService.login(form).subscribe((Response) => {
      const loginResponse = Response;
      // this.submitting = false;
      this.storageService.setItem('userName', loginResponse.userName);
      this.storageService.setItem('accessToken', loginResponse.access_token);
      this.storageService.setItem('refreshToken', loginResponse.refresh_token);
      this.authService.isAuthorized('admin').subscribe((response) => {
        if (response === true) {
          this.router.navigateByUrl('/controlpanel/dashboard');
        } else {
          this.router.navigateByUrl('/');
        }
        return loginResponse;
      });
    },
      (error) => {
        console.log(error);
        this.notificationService.serverError(error);
        this.submitting = false;
        this.recaptcha.reset();
      });
  }

  resolved(captchaResponse: string) {
    this.captchaResponse = captchaResponse;
  }
}
