import { Component, OnInit } from '@angular/core';
import { Renderer2 } from '@angular/core';
import { OnDestroy } from '@angular/core';

@Component({
  selector: 'app-website',
  templateUrl: './website.component.html',
  styleUrls: ['./website.component.scss']
})
export class WebsiteComponent implements OnInit, OnDestroy {

  constructor(protected renderer: Renderer2) {
    this.renderer.addClass(document.body.parentElement, 'webapp');
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.renderer.removeClass(document.body.parentElement, 'webapp');
  }

}
