import {Injectable} from "@angular/core";
import {Observable, of} from "rxjs";
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
}
