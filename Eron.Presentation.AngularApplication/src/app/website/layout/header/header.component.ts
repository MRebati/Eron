import { Component, OnInit } from '@angular/core';
import { AfterViewInit, OnDestroy } from '@angular/core';
import { Config } from '../../../app.config';
import { UserService } from '../../../control-panel/base/user/user.service';
import { UserModel } from '../../../base/models/user.model';
import { AuthenticationService } from '../../../authentication/auth.service';
import { PubSubService } from 'angular2-pubsub';
import { Subscription } from 'rxjs/Subscription';
import { StorageService } from '../../../base/services/storage.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, AfterViewInit, OnDestroy {
  applicationName = Config.application.name;
  mailAddress: string;
  phoneNumber: string;
  userInfo: UserModel;
  userName: string;
  authenticated: boolean;
  loginSubscription: Subscription;
  logoutSubscription: Subscription;
  accessTokenSubscription: Subscription;
  constructor(
    private userService: UserService,
    private authService: AuthenticationService,
    private pubSubService: PubSubService,
    public storageService: StorageService
  ) {
    this.mailAddress = Config.application.mailAddress;
    this.phoneNumber = Config.application.phoneNumber;

    this.accessTokenSubscription = this.storageService.watchStorage().subscribe(
      () => {
        const accessToken = this.storageService.getItem('accessToken');
        if (accessToken == null) {
          this.authenticated = false;
          this.authService.logoutWithoutWatch();
          this.pubSubService.$pub('logoutChild');
        }
      }
    );

    this.authenticated = this.authService.isAuthenticated();
    if (this.authenticated) {
      this.getUserInfo();
    }

    this.loginSubscription = this.pubSubService.$sub('login').subscribe(
      (response) => {
        this.authenticated = this.authService.isAuthenticated();
        this.getUserInfo();
      }
    );

    this.logoutSubscription = this.pubSubService.$sub('logout').subscribe(
      (response) => {
        this.logout();
      }
    );
  }

  ngOnInit() {
  }

  getUserInfo() {
    this.userService.getUserInfo().subscribe(
      (response) => {
        this.userInfo = response;
        this.userName = this.userInfo.firstName != null && this.userInfo.lastName != null ?
          this.userInfo.firstName + ' ' + this.userInfo.lastName :
          this.userInfo.email;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  logout() {
    this.authService.logout();
    this.pubSubService.$pub('logoutChild');
    this.authenticated = this.authService.isAuthenticated();
  }

  ngAfterViewInit() {

    /*---------------------------------------------------
        Mobile Main Menu
    ----------------------------------------------------- */
    $('#menu .navbar-header > span').on('click', function () {
      $(this).toggleClass('active');
      $('#menu .navbar-collapse').slideToggle('medium');
      return false;
    });

    // mobile sub menu plus/mines button
    $('#menu .nav > li > div > .column > div, .submenu, #menu .nav > li .dropdown-menu').before('<span class="submore"></span>');

    // mobile sub menu click function
    $('span.submore').on('click', function () {
      $(this).next().slideToggle('fast');
      $(this).toggleClass('plus');
      return false;
    });
    // mobile top link click
    $('.drop-icon').on('click', function () {
      $('#header .htop').find('.left-top').slideToggle('fast');
      return false;
    });

  }

  ngOnDestroy() {
    this.loginSubscription.unsubscribe();
    this.logoutSubscription.unsubscribe();
    this.accessTokenSubscription.unsubscribe();
  }
}
