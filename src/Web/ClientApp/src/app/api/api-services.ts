import {Injectable} from "@angular/core";
import {from, Observable, of, single} from "rxjs";
import {BroClient, BroModel, FixeClient, FixeModel} from "../../api";
import {BrosService} from "../admin/bros/bros.service";
import {FixesService} from "../fixes/fixes.service";

@Injectable({
  providedIn: 'root'
})
export class ApiFixesService implements FixesService {

  constructor(private client: FixeClient) {
  }

  getPastFixes(): Observable<FixeModel[]> {
    return this.client.getPastFixes();
  }

  getFixe(id: string): Observable<FixeModel> {
    return this.client.getFixe(id);
  }
}

@Injectable({
  providedIn: 'root'
})
export class ApiBrosService implements BrosService {

  constructor(private client: BroClient) {
  }

  getAllBros(): Observable<BroModel[]> {
    return this.client.getAllBros();
  }

  getBro(id: string): Observable<BroModel> {
    return this.client.getBro(id);
  }
}
