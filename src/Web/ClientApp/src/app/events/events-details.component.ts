import {Component} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {ActivatedRoute} from "@angular/router";
import {EventsService} from "./events.service";
import {BroModel, EventModel} from "../../api";
import {BrosService} from "../admin/bros/bros.service";
import {Observable} from "rxjs";

@Component({
  selector: 'app-events-details',
  template: `
    <div class="form-box mat-elevation-z3">
      <img class="header-image" [src]="event.backgroundUrl" *ngIf="event.backgroundUrl != null" alt=""/>
      <div class="form-container">
        <h2>{{event.title}}</h2>

        <form [formGroup]="eventForm">

          <mat-form-field>
            <mat-label>Titel</mat-label>
            <input matInput readonly formControlName="title">

          </mat-form-field>

          <mat-form-field>
            <mat-label>Ort</mat-label>
            <input matInput readonly formControlName="location">
            <mat-icon matSuffix>location_on</mat-icon>
          </mat-form-field>

          <mat-form-field>
            <mat-label>Start</mat-label>
            <input matInput readonly formControlName="start">
            <mat-icon matSuffix>schedule</mat-icon>
          </mat-form-field>

          <mat-form-field formGroupName="organizer">
            <mat-label>Organisator</mat-label>
            <input matInput readonly formControlName="nickname">
            <mat-icon matSuffix>person</mat-icon>
          </mat-form-field>

          <mat-selection-list #bros>
            <mat-list-option *ngFor="let bro of allBros">
              <img matListItemAvatar [src]="bro.avatarUrl" [alt]="'Bild von ' + bro.nickname">
              <div matListItemTitle>{{bro.nickname}}</div>
            </mat-list-option>
          </mat-selection-list>

          <div class="button-container">
            <button mat-raised-button color="primary" type="submit">Speichern</button>
            <button mat-raised-button>Abbrechen</button>
          </div>
        </form>
      </div>
    </div>
  `,
  styles: [`
    .form-box {
      margin: 2rem 2rem;
      max-width: 800px;
      background-color: white
    }

    .form-container {
      width: 100%;
      display: flex;
      flex-direction: column;
    }

    .form-container > * {
      margin: 2rem;
    }

    .header-image {
      width: 100%;
      max-height: 320px;
      object-fit: cover;
      object-position: bottom;
    }

    mat-form-field {
      width: 100%;
    }

    .button-container {
      margin-top: 1rem;
      display: flex;
      flex-direction: row;
      flex-wrap: wrap;
      align-items: stretch;
    }

    button {
      margin-right: 1rem;
    }

    @media screen and (max-width: 400px){
      .form-box {
        margin: 1rem;
      }

      .header-image {
        max-height: 200px;
      }
    }
  `]
})
export class EventsDetailsComponent {
  eventForm = new FormGroup({
    title: new FormControl(''),
    location: new FormControl(''),
    start: new FormControl(''),
    organizer: new FormGroup({
      nickname: new FormControl('')
    }),
  });
  event!: EventModel;
  allBros!: BroModel[];

  constructor(
    private route: ActivatedRoute,
    private eventsService: EventsService,
    private brosService: BrosService) {
  }

  ngOnInit(): void {
    this.getEvent();
    this.getBros();
    this.eventForm.patchValue(this.event);
  }

  getEvent(): void {
    this.route.data
      .subscribe(data => {
        this.event = <EventModel>data["event"];
      });
  }

  getHeaderBackgroundImage(): string | undefined {
    if (!this.event.backgroundUrl)
      return undefined;

    return "url('" + this.event.backgroundUrl + "')";
  }

  private getBros() {
    this.brosService.getAllBros().subscribe(bros => this.allBros = bros);
  }
}
