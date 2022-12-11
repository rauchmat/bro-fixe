import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {MatMenuModule} from "@angular/material/menu";
import {AdminComponent} from './admin/admin.component';
import {EventsModule} from "./events/events.module";
import {MocksModule} from "./mocks/mocks.module";
import {OrganizerModule} from "./organizer/organizer.module";

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatMenuModule,
    EventsModule,
    OrganizerModule,
    MocksModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}