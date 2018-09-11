import { isDevMode } from '@angular/core';
import { environment } from '../environments/environment';

export class Config {
  static baseApiAddress = environment.baseApiAddress;
  static websiteHost = environment.webAppAddress;

  static dropzoneDefaultMessage = 'برای بارگزاری فایل های خود را اینجا بکشید یا کلیک نمایید';

  static application = {
    name: 'سامانه مدیریت ارون',
    description: 'وبلاگ شخصی محمد رباطی',
    heroChars: 'Er',
    mailAddress: 'info@rebati.net',
    phoneNumber: '+989381616622',
    companyName: 'Eron Solutions',
    copyright: 'All Rights Reserved',
    address: '',
    social: {
      facebook: {
        address: '',
        name: ''
      },
      twitter: {
        address: '',
        name: ''
      },
      linkedin: {
        address: '',
        name: ''
      },
      googlePlus: {
        address: '',
        name: ''
      },
      instagram: {
        address: '',
        name: ''
      },
      pintrest: {
        address: '',
        name: ''
      },
    }
  };

  static defaultTitle = Config.application.name + ' | ';
}
