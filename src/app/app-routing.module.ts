import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {EventsComponent} from "./events/events.component";
import {AdminComponent} from "./admin/admin.component";

const routes: Routes = [
  { path: 'events', component: EventsComponent },
  { path: 'admin', component: AdminComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
