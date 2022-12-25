import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BrosService} from "../admin/bros/bros.service";
import {FixesService} from "../fixes/fixes.service";
import {ApiBrosService, ApiFixesService} from "./api-services";


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    {provide: FixesService, useClass: ApiFixesService},
    {provide: BrosService, useClass: ApiBrosService}]
})
export class ApiModule {
}
