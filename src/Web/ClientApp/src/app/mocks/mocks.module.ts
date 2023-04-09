import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {MockBrosService, MockFixesService} from "./mock-services";
import {BrosService} from "../admin/bros/bros.service";
import {FixesService} from "../fixes/fixes.service";


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    {provide: FixesService, useClass: MockFixesService},
    {provide: BrosService, useClass: MockBrosService},
  ]
})
export class MocksModule {
}
