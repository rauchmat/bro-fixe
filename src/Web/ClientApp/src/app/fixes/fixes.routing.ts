import {Route} from "@angular/router";
import {FixesComponent} from "./fixes.component";
import {FixeDetailsComponent} from "./fixe-details.component";
import {FixeResolver} from "./fixe-resolver.service";
import {AutoLoginPartialRoutesGuard} from "angular-auth-oidc-client";

export const FIXES_ROUTE: Route = {
  path: 'fixes',
  canActivate: [AutoLoginPartialRoutesGuard],
  children: [
    {
      path: '',
      component: FixesComponent
    },
    {
      path: ':id',
      component: FixeDetailsComponent,
      resolve: {
        fixe: FixeResolver
      }
    }
  ]
}
