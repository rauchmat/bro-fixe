import {Component} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {ActivatedRoute, Navigation, Router} from "@angular/router";
import {FixesService} from "./fixes.service";
import {BroModel, FixeModel} from "../../api";
import {BrosService} from "../admin/bros/bros.service";

@Component({
  selector: 'app-fixe-details',
  template: `
      <div class="form-box mat-elevation-z3">
          <div class="header-image">
              <img class="header-image" [src]="fixe.backgroundUrl" *ngIf="fixe.backgroundUrl != null" alt=""/>
              <button mat-fab color="primary" class="upload-button" (click)="fileInput.click()">
                <mat-icon>add_photo_alternate</mat-icon>
                <input #fileInput type="file" (change)="onUploadFoto($event)" style="display:none;" />
              </button>
          </div>
          <div class="form-container">
              <h2>{{fixe.title}}</h2>

              <form [formGroup]="fixeForm">
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

                  <mat-selection-list #bros class="full-width bros">
                      <mat-list-option *ngFor="let bro of allBros">
                          <img matListItemAvatar [src]="bro.avatarUrl" [alt]="'Bild von ' + bro.nickname">
                          <div matListItemTitle>{{bro.nickname}}</div>
                      </mat-list-option>
                  </mat-selection-list>

                  <div class="button-container" class="full-width">
                      <button mat-raised-button color="primary" type="submit" routerLink="..">Speichern</button>
                      <button mat-raised-button routerLink="..">Zurück</button>
                  </div>
              </form>
          </div>
      </div>
  `,
  styles: [`
    :host {
      width: 100%;
      max-width: 800px;
    }

    .header-image {
      position: relative;
    }

    .header-image .upload-button {
      position: absolute;
      bottom: 0;
      right: 0;
      margin: 1rem;
    }

    .form-box {
      background-color: white
    }

    .form-container {
      padding: 2rem;
    }

    form {
      display: grid;
      grid-template-columns: 1fr 1fr;
      grid-gap: 1em;
    }

    .full-width {
      grid-column: 1 / 3;
    }

    .bros {
      display: grid;
      grid-template-columns: 1fr 1fr;
    }

    .header-image {
      width: 100%;
      max-height: 450px;
      object-fit: cover;
      object-position: bottom;
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

    @media screen and (max-width: 575px) {
      .form-container {
        padding: 1rem;
      }

      form {
        display: grid;
        grid-template-columns: 1fr;
        grid-gap: 0.5em;
      }

      .full-width {
        grid-column: 1 / 2;
      }

      .bros {
        display: grid;
        grid-template-columns: 1fr;
      }

      .header-image {
        max-height: 200px;
      }
    }
  `]
})
export class FixeDetailsComponent {
  fixeForm = new FormGroup({
    title: new FormControl(''),
    location: new FormControl(''),
    start: new FormControl(''),
    organizer: new FormGroup({
      nickname: new FormControl('')
    }),
  });
  fixe!: FixeModel;
  allBros!: BroModel[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fixesService: FixesService,
    private brosService: BrosService) {
  }

  ngOnInit(): void {
    this.getEvent();
    this.getBros();
    this.fixeForm.patchValue(this.fixe);
  }

  getEvent(): void {
    this.route.data
      .subscribe(data => {
        this.fixe = <FixeModel>data["fixe"];
      });
  }

  getHeaderBackgroundImage(): string | undefined {
    if (!this.fixe.backgroundUrl)
      return undefined;

    return "url('" + this.fixe.backgroundUrl + "')";
  }

  private getBros() {
    this.brosService.getAllBros().subscribe(bros => this.allBros = bros);
  }

  onSave() : void {
    this.router.navigate(['..']);
  }

  onUploadFoto($event: Event) {
    console.log($event)
  }
}
