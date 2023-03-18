import {Component} from '@angular/core';
import {NavigationEnd, Router} from "@angular/router";
import {filter} from "rxjs";

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
      <button mat-icon-button>
        <mat-icon>account_circle</mat-icon>
      </button>
    </mat-toolbar>
    <mat-menu #menu="matMenu">
      <button *ngFor="let menuItem of menuItems" mat-menu-item
              [routerLink]="menuItem.link" (click)="onMenuItemClick(menuItem.title)">
        {{menuItem.title}}
      </button>
    </mat-menu>
    <router-outlet></router-outlet>
  `,
  styles: [`
    .logo {
      height: 80%;
    }

    .spacer {
      flex: 1 1 auto;
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

  constructor(private router: Router) {
  }

  ngOnInit() {
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(e => this.updateSelectedItem((e as NavigationEnd).url.split("#")[0]));
  }

  onMenuItemClick(title: string) {
    this.title = title;
  }

  private updateSelectedItem(url: string) {
    let selectedMenuItem = this.menuItems.filter(mi => url.startsWith(mi.link))[0];
    this.title = selectedMenuItem.title;
  }
}

interface MenuItem {
  title: string,
  link: string
}
