import {Observable} from "rxjs";
import {FixeModel} from "../../api";

export abstract class FixesService {
  abstract getPastFixes(): Observable<FixeModel[]>;

  abstract getFixe(id: string) : Observable<FixeModel>
}
