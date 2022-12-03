import {Observable} from "rxjs";
import {EventModel} from "../../api";

export abstract class EventsService {
  abstract getPastEvents(): Observable<EventModel[]>;
}
