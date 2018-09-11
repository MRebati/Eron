import { Api } from '../../../base/api';
import { HttpClient } from '../../../base/services/app.http.service';
import { Tariff } from './tariff.model';
import { ToastsManager } from 'ng2-toastr/src/toast-manager';
import { Injectable, ViewContainerRef } from '@angular/core';

@Injectable()
export class TariffService {

  constructor(private http: HttpClient) {
  }

  getById(id: number) {
    return this.http.get(Api.tariff.default + id);
  }

  getTariffList() {
    return this.http.get(Api.tariff.default);
  }


  getByCategory(id: number) {
    return this.http.get(Api.tariff.category + id);
  }

  createTariff(tariffModel: Tariff) {
    return this.http.post(Api.tariff.default, tariffModel);
  }

  updateTariff(tariffModel: Tariff) {
    return this.http.put(Api.tariff.default, tariffModel);
  }
}
