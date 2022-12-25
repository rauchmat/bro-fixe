import {Route} from "@angular/router";
import {FixesComponent} from "./fixes.component";
import {FixeDetailsComponent} from "./fixe-details.component";
import {FixeResolver} from "./fixe-resolver.service";

export const FIXES_ROUTE: Route = {
  path: 'fixes',
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
