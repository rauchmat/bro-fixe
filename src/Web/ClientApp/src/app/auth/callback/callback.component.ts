import { Component } from '@angular/core';
import {filter, tap} from "rxjs";
import {NavigationEnd, Router} from "@angular/router";
import {SwPush} from "@angular/service-worker";
import {PushSubscriptionsClient} from "../../../api";
import {OidcSecurityService} from "angular-auth-oidc-client";

@Component({
  selector: 'app-callback',
  template: `
    <p>Anmeldung läuft...</p>
  `,
  styles: [
  ]
})
export class CallbackComponent {

  constructor(public oidcSecurityService: OidcSecurityService) {
  }

  ngOnInit() {
    this.oidcSecurityService.checkAuth().subscribe(({ isAuthenticated, userData, accessToken}) => {
      if (isAuthenticated) console.log("Successfully logged in", userData, accessToken)
    });
  }
}
