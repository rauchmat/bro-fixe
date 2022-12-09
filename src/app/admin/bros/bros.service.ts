import {Observable} from "rxjs";
import {BroModel} from "../../../api";

export abstract class BrosService {
  abstract getAllBros(): Observable<BroModel[]>;

  abstract getBro(id: string) : Observable<BroModel>
}
