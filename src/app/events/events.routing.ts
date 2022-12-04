import {Route} from "@angular/router";
import {EventsComponent} from "./events.component";
import {EventsDetailsComponent} from "./events-details.component";

export const EVENTS_ROUTE: Route = {
  path: 'events',
  children: [
    {
      path: '',
      component: EventsComponent
    },
    {
      path: ':id',
      component: EventsDetailsComponent,
    }
  ]
}
