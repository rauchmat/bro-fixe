import {Component} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {ActivatedRoute} from "@angular/router";
import {EventsService} from "./events.service";
import {EventModel} from "../../api";

@Component({
  selector: 'app-events-details',
  template: `
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

      <button mat-raised-button color="primary" type="submit">Speichern</button>

    </form>
  `,
  styles: [`
    form {
      display: flex;
      flex-direction: column;
      align-items: stretch;
      padding: 1em;
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

  constructor(
    private route: ActivatedRoute,
    private eventsService: EventsService) {
  }

  ngOnInit(): void {
    this.getEvent();
    this.eventForm.patchValue(this.event);
  }

  getEvent(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.eventsService.getEvent(id!)
      .subscribe(event => this.event = event);
  }
}
