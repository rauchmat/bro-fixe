import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BrosService} from "../admin/bros/bros.service";
import {FixesService} from "../fixes/fixes.service";
import {ApiBrosService, ApiFixesService} from "./api-services";
import {BroClient, FixeClient, PushSubscriptionsClient, TestClient} from "../../api";
import {HttpClientModule} from "@angular/common/http";


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [
    FixeClient,
    {provide: FixesService, useClass: ApiFixesService},
    BroClient,
    {provide: BrosService, useClass: ApiBrosService},
    PushSubscriptionsClient,
    TestClient
  ]
})
export class ApiModule {
}
