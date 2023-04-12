import {Component} from '@angular/core';
import {NavigationEnd, Router} from "@angular/router";
import {catchError, filter, from, mergeMap, tap, throwError} from "rxjs";
import {SwPush} from "@angular/service-worker";
import {PushSubscription, PushSubscriptionsClient} from "../api";
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'app-root',
  template: `
    <mat-toolbar color="primary">
      <img src="/assets/brofixe_small.png" alt="" class="logo"/>
      <button mat-icon-button [matMenuTriggerFor]="menu">
        <mat-icon>menu</mat-icon>
      </button>
      <span>{{title}}</span>
      <span class="spacer"></span>
      <button mat-icon-button>
        <mat-icon>volunteer_activism</mat-icon>
      </button>
      <button mat-icon-button (click)="logout()">
        <mat-icon>account_circle</mat-icon>
      </button>
    </mat-toolbar>
    <mat-menu #menu="matMenu">
      <button *ngFor="let menuItem of menuItems" mat-menu-item
              [routerLink]="menuItem.link" (click)="onMenuItemClick(menuItem.title)">
        {{menuItem.title}}
      </button>
    </mat-menu>
    <section class="content">
      <router-outlet></router-outlet>
    </section>
  `,
  styles: [`
    .content {
      padding: 2em;
      display: flex;
      align-items: center;
      justify-content: center;
    }

    .logo {
      height: 80%;
    }

    .spacer {
      flex: 1 1 auto;
    }

    @media screen and (max-width: 575px) {
      .content {
        padding: 1em;
      }
    }
  `]
})
export class AppComponent {
  menuItems: MenuItem[] = [
    {title: "Fixes", link: "/fixes"},
    {title: "Organisator", link: "/organizer"},
    {title: "Admin", link: "/admin"},
  ];
  title!: string;

  constructor(private router: Router,
              private swPush: SwPush,
              private pushSubscriptionsClient: PushSubscriptionsClient,
              public oidcSecurityService: OidcSecurityService) {
  }

  ngOnInit() {
    this.router.events
      .pipe(
        filter(event => event instanceof NavigationEnd),
        tap(e => this.updateSelectedItem((e as NavigationEnd).url.split("#")[0]))
      );
  }

  logout() {
    this.oidcSecurityService.logoff().subscribe((result) => console.log("Successfully logged out", result));
  }

  onMenuItemClick(title: string) {
    this.title = title;
  }

  private updateSelectedItem(url: string) {
    let selectedMenuItem = this.menuItems.filter(mi => url.startsWith(mi.link))[0];
    this.title = selectedMenuItem.title;
  }

  subscribeToPushNotifications() {
    this.pushSubscriptionsClient.getPublicKey()
      .pipe(
        mergeMap(publicKey => from(this.swPush.requestSubscription({serverPublicKey: publicKey}))),
        catchError(err => {
          console.error("Error while requesting push subscription", err);
          return throwError(err);
        }),
        mergeMap(subscription => {
          let pushSubscription = subscription as unknown as PushSubscription;
          return this.pushSubscriptionsClient.createSubscription(pushSubscription);
        })
      ).subscribe();
  }
}

interface MenuItem {
  title: string,
  link: string
}
