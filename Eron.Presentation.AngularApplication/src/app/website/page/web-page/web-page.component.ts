import { Component, OnInit, Renderer2 } from '@angular/core';
import { Router } from '@angular/router';

import { PageService } from '../../../control-panel/base/page/page.service';
import { WebsiteComponent } from '../../website.component';
import { Config } from '../../../app.config';
import { Meta } from '@angular/platform-browser';

@Component({
  selector: 'app-web-page',
  templateUrl: './web-page.component.html',
  styleUrls: ['./web-page.component.scss']
})
export class WebPageComponent extends WebsiteComponent implements OnInit {
  applicationName: string;
  content: any;
  constructor(
    private pageService: PageService,
    private router: Router,
    protected renderer: Renderer2,
    private meta: Meta
  ) {
    super(renderer);
    this.applicationName = Config.application.name;
    const slug = this.router.url.substr(1);
    this.pageService.getPageBySlug(slug).subscribe(
      (response) => {
        this.content = response;
        this.meta.removeTag('keywords');
        this.meta.addTag({
          id: 'keywords',
          name: 'keywords',
          content: response.keywords
        });

        this.meta.addTag({
          id: 'description',
          name: 'description',
          content: response.description
        });
      },
      (error) => {
        this.router.navigateByUrl('/404');
      }
    );
  }

  ngOnInit() {
  }

}
