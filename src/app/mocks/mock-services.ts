import {Injectable} from "@angular/core";
import {from, Observable, of, single} from "rxjs";
import {BroModel, EventModel} from "../../api";
import {BROS, EVENTS} from "./mocks";
import {EventsService} from "../events/events.service";
import {BrosService} from "../admin/bros/bros.service";

@Injectable({
  providedIn: 'root'
})
export class MockEventsService implements EventsService {

  constructor() {
  }

  getPastEvents(): Observable<EventModel[]> {
    return of(EVENTS);
  }

  getEvent(id: string): Observable<EventModel> {
    return from(EVENTS)
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
