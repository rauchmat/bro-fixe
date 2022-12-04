import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {EventsComponent} from "./events.component";
import {MatCardModule} from "@angular/material/card";
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";
import {RouterModule} from "@angular/router";
import {EventsDetailsComponent} from "./events-details.component";


@NgModule({
  declarations: [
    EventsComponent,
    EventsDetailsComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    RouterModule
  ]
})
export class EventsModule {
}
