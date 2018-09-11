import { Injectable } from '@angular/core';
import { HttpClient } from '../../base/services/app.http.service';
import { Api } from '../../base/api';

@Injectable()
export class SearchService {
  constructor(
    private http: HttpClient
  ) {
  }

  search(searchQuery: string) {
    return this.http.get(Api.search.default + searchQuery);
  }
}
