import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AdminComponent} from "./admin/admin.component";
import {ORGANIZER_ROUTES} from "./organizer/organizer.routing";
import {FIXES_ROUTE} from "./fixes/fixes.routing";

const routes: Routes = [
  FIXES_ROUTE,
  ORGANIZER_ROUTES,
  { path: 'admin', component: AdminComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
