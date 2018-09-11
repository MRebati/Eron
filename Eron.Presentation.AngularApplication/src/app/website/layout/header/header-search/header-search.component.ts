import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  // tslint:disable-next-line:component-selector
  selector: '[app-header-search]',
  templateUrl: './header-search.component.html',
  styleUrls: ['./header-search.component.scss']
})
export class HeaderSearchComponent implements OnInit {

  searchQuery: string;
  constructor(
    private router: Router) { }

  ngOnInit() {
  }

  search() {
    if (this.searchQuery.length > 0) {
      const searchQuery = encodeURIComponent(this.searchQuery);
      this.router.navigateByUrl('/search/' + searchQuery);
    }
  }
}
