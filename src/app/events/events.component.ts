import {Component} from '@angular/core';
import {EventsService} from "./events.service";
import {EventModel} from "../../api";

@Component({
  selector: 'app-events',
  template: `
    <section class="events-container">
      <article *ngFor="let event of pastEvents" class="event-card">
        <mat-card>
          <mat-card-header>
            <img mat-card-avatar [src]="event.organizer.avatarUrl" [alt]="event.organizer.nickname"/>
            <mat-card-title>{{event.title}}</mat-card-title>
            <mat-card-subtitle>{{event.location}}</mat-card-subtitle>
          </mat-card-header>
          <img mat-card-image [src]="event.backgroundUrl" [alt]="event.location">
          <mat-card-content>
            <div>
              <span>Organisator: </span><span>{{event.organizer.nickname}}</span>
            </div>
            <div>
              <span>Beginn: </span><span>{{event.start}}</span>
            </div>
          </mat-card-content>
          <mat-card-actions>
            <button [routerLink]="event.id" mat-button>
              <mat-icon>edit</mat-icon>
              Details
            </button>
            <button mat-button>
              <mat-icon>share</mat-icon>
              Share
            </button>
          </mat-card-actions>
        </mat-card>
      </article>
    </section>
  `,
  styles: [`
    .events-container {
      display: flex;
      justify-content: space-evenly;
      flex-wrap: wrap;
      align-items: stretch;
      align-content: flex-start;
      padding: 1em;
    }

    .event-card {
      margin-bottom: 1em;
    }

    .event-card mat-card {
      height: 100%;
      display: flex;
      flex-direction: column;
      align-items: stretch;
      justify-content: space-between;
    }

    .event-card mat-card-actions {
      //position: absolute;
      //bottom: 0;
    }

    .event-card {
      max-width: 400px;
    }

    mat-card-content {
      padding: 1em;
    }
  `
  ]
})
export class EventsComponent {
  pastEvents: EventModel[] = [];

  constructor(private eventsService: EventsService) {
  }

  ngOnInit(): void {
    this.getEvents();
  }

  getEvents() {
    this.eventsService.getPastEvents().subscribe((events: EventModel[]) => this.pastEvents = events);
  }

  edit(event: EventModel) {

  }
}
