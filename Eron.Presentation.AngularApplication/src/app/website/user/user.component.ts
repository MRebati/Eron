import { Component, OnInit } from '@angular/core';
import { WebsiteComponent } from '../website.component';
import { Renderer2 } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Common } from '../../base/common';
import { Config } from '../../app.config';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent extends WebsiteComponent implements OnInit {

  constructor(
    protected rend: Renderer2,
    public titleService: Title
  ) {
    super(rend);
    this.titleService.setTitle(Config.defaultTitle + 'اطلاعات کاربری');
   }

  ngOnInit() {
  }

}
