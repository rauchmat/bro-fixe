import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AdminComponent} from "./admin/admin.component";
import {EVENTS_ROUTE} from "./events/events.routing";
import {ORGANIZER_ROUTES} from "./organizer/organizer.routing";

const routes: Routes = [
  EVENTS_ROUTE,
  ORGANIZER_ROUTES,
  { path: 'admin', component: AdminComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
