import { Component, OnInit } from '@angular/core';
import { Config } from '../../app.config';

@Component({
  selector: 'app-financial',
  templateUrl: './financial.component.html',
  styleUrls: ['./financial.component.scss']
})
export class FinancialComponent implements OnInit {
  applicationName: string;
  constructor() {
    this.applicationName = Config.application.name;
  }

  ngOnInit() {
  }

}
