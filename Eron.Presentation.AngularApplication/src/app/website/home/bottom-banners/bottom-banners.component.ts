import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-bottom-banners',
  templateUrl: './bottom-banners.component.html',
  styleUrls: ['./bottom-banners.component.scss']
})
export class BottomBannersComponent implements OnInit {
  @Input() categoryName: string;
  constructor() { }

  ngOnInit() {
  }

}
