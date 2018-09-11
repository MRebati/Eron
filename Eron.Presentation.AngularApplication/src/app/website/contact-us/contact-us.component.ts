import { Component, OnInit } from '@angular/core';
import { WebsiteComponent } from '../website.component';
import { Renderer2 } from '@angular/core';
import { ContactService } from './contact-us.service';
import { NotificationService } from '../../base/services/notification.service';
import { Config } from '../../app.config';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.scss']
})
export class ContactUsComponent extends WebsiteComponent implements OnInit {
  mapLat = 35.829770;
  mapLng = 50.997222;
  pntrLat = 35.829770;
  pntrLng = 50.997222;
  applicationDescription: string;
  companyAddress: string;
  companyEmail: string;
  companyPhoneNumber: string;
  applicationName: string;
  message: any = {};
  constructor(
    private rend: Renderer2,
    private contactService: ContactService,
    private notificationService: NotificationService
  ) {
    super(rend);
    this.applicationName = Config.application.name;
    this.applicationDescription = Config.application.description;
    this.companyAddress = Config.application.address;
    this.companyPhoneNumber = Config.application.phoneNumber;
    this.companyEmail = Config.application.mailAddress;
  }

  ngOnInit() {
  }

  onSubmit() {
    this.contactService.createMessage(this.message).subscribe(
      (response) => {
        this.notificationService.successfulOperationWithAlert('عملیات موفقیت آمیز', 'پیام شما با موفقیت  به سامانه ارسال شد');
      },
      (error) => {
        this.notificationService.serverError(error);
      }
    );
  }

}
