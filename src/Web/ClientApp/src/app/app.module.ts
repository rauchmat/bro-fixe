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
import {MocksModule} from "./mocks/mocks.module";
import {OrganizerModule} from "./organizer/organizer.module";
import {FixesModule} from "./fixes/fixes.module";
import {ApiModule} from "./api/api.module";
import {API_BASE_URL} from "../api";

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
    FixesModule,
    OrganizerModule,
    ApiModule
  ],
  providers: [
    {provide: API_BASE_URL, useValue: '.'}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
