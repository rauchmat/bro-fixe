import {Route} from "@angular/router";
import {OrganizerComponent} from "./organizer.component";
import {AutoLoginPartialRoutesGuard} from "angular-auth-oidc-client";

export const ORGANIZER_ROUTES: Route = {
  path: 'organizer',
  canActivate: [AutoLoginPartialRoutesGuard],
  children: [
    {
      path: '',
      component: OrganizerComponent
    }
  ]
}
