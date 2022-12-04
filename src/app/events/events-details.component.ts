import {Component} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-events-details',
  template: `
    <form [formGroup]="eventForm">

      <mat-form-field>
        <mat-label>Titel</mat-label>
        <input matInput formControlName="title">

      </mat-form-field>

      <mat-form-field>
        <mat-label>Ort</mat-label>
        <input matInput formControlName="location">
        <mat-icon matSuffix>location_on</mat-icon>
      </mat-form-field>

      <button mat-raised-button color="primary" type="submit">Speichern</button>

    </form>
  `,
  styles: [`
    form {
      display: flex;
      flex-direction: column;
      align-items: flex-start;
      padding: 1em;
    }
  `]
})
export class EventsDetailsComponent {
  eventForm = new FormGroup({
    title: new FormControl(''),
    location: new FormControl(''),
    start: new FormControl(''),
    organizer: new FormControl(''),
  });
}
