import {Component} from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <mat-toolbar color="primary">
      <img src="/assets/brofixe.png" alt="" class="logo"/>
      <button mat-icon-button [matMenuTriggerFor]="menu">
        <mat-icon>menu</mat-icon>
      </button>
      <span>{{title}}</span>
      <span class="spacer"></span>
      <button mat-icon-button>
        <mat-icon>favorite</mat-icon>
      </button>
      <button mat-icon-button>
        <mat-icon>share</mat-icon>
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
    {title: "Events", link: "/events"},
    {title: "Admin", link: "/admin"},
  ];
  title = 'Events';

  onMenuItemClick(title: string) {
    this.title = title;
  }
}

interface MenuItem {
  title: string,
  link: string
}
