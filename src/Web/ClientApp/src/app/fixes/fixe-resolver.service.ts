import {FixeModel} from "../../api";
import {Injectable} from "@angular/core";
import {ActivatedRouteSnapshot, Resolve, RouterStateSnapshot} from "@angular/router";
import {FixesService} from "./fixes.service";
import {Observable} from "rxjs";

@Injectable({providedIn: 'root'})
export class FixeResolver implements Resolve<FixeModel> {
  constructor(private service: FixesService) {
  }

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<FixeModel> | Promise<FixeModel> | FixeModel {
    return this.service.getFixe(route.paramMap.get('id')!);
  }
}
