import { Component, OnInit } from '@angular/core';
import { WebsiteComponent } from '../../website.component';
import { Renderer2 } from '@angular/core';
import { Config } from '../../../app.config';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.scss']
})
export class InvoicesComponent extends WebsiteComponent implements OnInit {

  applicationName: string;
  constructor(protected renderer: Renderer2) {
    super(renderer);
    this.applicationName = Config.application.name;
  }

  ngOnInit() {
  }

}
