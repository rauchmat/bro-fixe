import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {MockEventsService} from "./mock-services";
import {EventsService} from "../events/events.service";


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [{provide: EventsService, useClass: MockEventsService}]
})
export class MocksModule {
}
