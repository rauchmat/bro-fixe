﻿import {Injectable} from "@angular/core";
import {from, Observable, of, single} from "rxjs";
import {BroModel, FixeModel} from "../../api";
import {BROS, FIXES} from "./mocks";
import {BrosService} from "../admin/bros/bros.service";
import {FixesService} from "../fixes/fixes.service";

@Injectable({
  providedIn: 'root'
})
export class MockFixesService implements FixesService {

  constructor() {
  }

  getPastFixes(): Observable<FixeModel[]> {
    return of(FIXES);
  }

  getFixe(id: string): Observable<FixeModel> {
    return from(FIXES)
      .pipe(single(e => e.id === id));
  }
}

@Injectable({
  providedIn: 'root'
})
export class MockBrosService implements BrosService {

  constructor() {
  }

  getAllBros(): Observable<BroModel[]> {
    return of(BROS);
  }

  getBro(id: string): Observable<BroModel> {
    return from(BROS)
      .pipe(single(e => e.id === id));
  }
}
