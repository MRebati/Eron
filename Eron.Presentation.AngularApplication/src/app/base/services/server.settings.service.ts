import { Injectable } from '@angular/core';
import { HttpClient } from './app.http.service';
import { Api } from '../api';

@Injectable()
export class ServerSideSettingsService {

  constructor(private http: HttpClient) {
  }

  getClientSetting(key: string) {
    return this.http.get(Api.settings.client + key);
  }
}
