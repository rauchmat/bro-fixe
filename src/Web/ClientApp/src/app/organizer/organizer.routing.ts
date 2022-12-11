import {Route} from "@angular/router";
import {OrganizerComponent} from "./organizer.component";

export const ORGANIZER_ROUTES: Route = {
  path: 'organizer',
  children: [
    {
      path: '',
      component: OrganizerComponent
    }
  ]
}
