import { Component, OnInit } from '@angular/core';
import { Config } from '../../../app.config';
import { NavigationService } from '../../../control-panel/base/navigation/navigation.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  applicationName: string;
  applicationDescription: string;
  currentYear: string;
  footerList: any[] = [];
  companyAddress: string;
  companyPhoneNumber: string;
  applicationCompanyName: string;
  constructor(
    private navigationService: NavigationService
  ) {
    this.applicationCompanyName = Config.application.companyName;
    this.applicationName = Config.application.name;
    this.applicationDescription = Config.application.description;
    this.companyAddress = Config.application.address;
    this.companyPhoneNumber = Config.application.phoneNumber;
    this.currentYear = new Date().getFullYear().toString();
    this.navigationService.getFooterItemsAsTree().subscribe(
      (response) => {
        this.footerList = response;
      },
      (error) => {
        console.log(error);
      }
    );
   }

  ngOnInit() {
  }

}
