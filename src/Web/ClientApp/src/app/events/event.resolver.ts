import {EventModel} from "../../api";
import {Injectable} from "@angular/core";
import {ActivatedRouteSnapshot, Resolve, RouterStateSnapshot} from "@angular/router";
import {EventsService} from "./events.service";
import {Observable} from "rxjs";

@Injectable({providedIn: 'root'})
export class EventResolver implements Resolve<EventModel> {
  constructor(private service: EventsService) {
  }

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<EventModel> | Promise<EventModel> | EventModel {
    return this.service.getEvent(route.paramMap.get('id')!);
  }
}
