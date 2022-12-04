import {Injectable} from "@angular/core";
import {from, Observable, of, single} from "rxjs";
import {EventModel} from "../../api";
import {EVENTS} from "./mocks";
import {EventsService} from "../events/events.service";

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
