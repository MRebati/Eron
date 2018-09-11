import { Component, OnInit, Renderer2 } from '@angular/core';
import { WebsiteComponent } from '../../website.component';
import { Config } from '../../../app.config';

@Component({
  selector: 'app-not-found-error',
  templateUrl: './not-found-error.component.html',
  styleUrls: ['./not-found-error.component.scss']
})
export class NotFoundErrorComponent extends WebsiteComponent implements OnInit {
  applicationName: string;
  constructor(
    protected renderer: Renderer2
  ) {
    super(renderer);
    this.applicationName = Config.application.name;
  }

  ngOnInit() {
  }

}
