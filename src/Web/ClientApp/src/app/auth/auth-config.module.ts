import {NgModule} from '@angular/core';
import {AuthModule} from 'angular-auth-oidc-client';
import {CallbackComponent} from './callback/callback.component';


@NgModule({
  imports: [AuthModule.forRoot({
    config: {
      authority: 'https://brofixe-dev.eu.auth0.com',
      secureRoutes: [`./api`],
      redirectUrl: `${window.location.origin}/callback`,
      postLogoutRedirectUri: window.location.origin,
      clientId: 'QjYVq7isSvArdu3CHAAvDWpt9BnXkIAO',
      scope: 'openid profile email offline_access',
      responseType: 'code',
      silentRenew: true,
      useRefreshToken: true,
      renewTimeBeforeTokenExpiresInSeconds: 30,
      customParamsAuthRequest: {
        audience: 'https://bro-fixe.org/api'
      },
    }
  })],
  exports: [AuthModule],
  declarations: [
    CallbackComponent
  ],
})
export class AuthConfigModule {
}
