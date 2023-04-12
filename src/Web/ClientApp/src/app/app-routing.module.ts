import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AdminComponent} from "./admin/admin.component";
import {ORGANIZER_ROUTES} from "./organizer/organizer.routing";
import {FIXES_ROUTE} from "./fixes/fixes.routing";
import {AutoLoginPartialRoutesGuard} from "angular-auth-oidc-client";
import {CallbackComponent} from "./auth/callback/callback.component";

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'fixes'},
  {path: 'callback', component: CallbackComponent},
  FIXES_ROUTE,
  ORGANIZER_ROUTES,
  {path: 'admin', component: AdminComponent, canActivate: [AutoLoginPartialRoutesGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
