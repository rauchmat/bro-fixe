import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {MockBrosService, MockEventsService} from "./mock-services";
import {EventsService} from "../events/events.service";
import {BrosService} from "../admin/bros/bros.service";


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    {provide: EventsService, useClass: MockEventsService},
    {provide: BrosService, useClass: MockBrosService}]
})
export class MocksModule {
}
