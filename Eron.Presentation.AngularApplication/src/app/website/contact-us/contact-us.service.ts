import { Injectable } from '@angular/core';
import { HttpClient } from '../../base/services/app.http.service';
import { Api } from '../../base/api';


@Injectable()
export class ContactService {
  constructor(public http: HttpClient) {
  }

  createMessage(model: any) {
    return this.http.post(Api.contact.default, model);
  }
}
