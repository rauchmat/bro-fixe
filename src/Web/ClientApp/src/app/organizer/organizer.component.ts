import {Component, ElementRef, ViewChild} from "@angular/core";
import {FormBuilder, FormControl, FormGroup} from "@angular/forms";
import {map, Observable, startWith} from "rxjs";
import {MatChipInputEvent} from "@angular/material/chips";
import {MatAutocompleteSelectedEvent} from "@angular/material/autocomplete";

@Component({
  selector: 'app-organize-overview',
  template: `
    <mat-stepper orientation="vertical" [linear]="true" #stepper>
      <mat-step [stepControl]="firstFormGroup">
        <form [formGroup]="firstFormGroup">
          <ng-template matStepLabel>Termine vorschlagen</ng-template>
          <mat-form-field>
            <mat-label>Ort</mat-label>
            <input matInput formControlName="location">
            <mat-icon matSuffix>location_on</mat-icon>
          </mat-form-field>

          <mat-form-field class="example-chip-list" appearance="fill">
            <mat-label>Mögliche Termine</mat-label>
            <mat-chip-grid #chipGrid>
              <mat-chip-row *ngFor="let dateOption of selectedDateOptions" (removed)="remove(dateOption)">
                {{dateOption}}
                <button matChipRemove>
                  <mat-icon>cancel</mat-icon>
                </button>
              </mat-chip-row>
            </mat-chip-grid>
            <input placeholder="Neue Auswahlmöglichkeit..." #dateOptionInput required [formControl]="dateOptionControl"
                   [matChipInputFor]="chipGrid" [matAutocomplete]="auto"
                   (matChipInputTokenEnd)="add($event)"/>
            <mat-autocomplete #auto="matAutocomplete" (optionSelected)="selected($event)">
              <mat-option *ngFor="let dateOption of filteredDateOptions | async" [value]="dateOption">
                {{dateOption}}
              </mat-option>
            </mat-autocomplete>
          </mat-form-field>

          <div>
            <button mat-button matStepperNext>Next</button>
          </div>
        </form>
      </mat-step>
      <mat-step [stepControl]="secondFormGroup">
        <form [formGroup]="secondFormGroup">
          <ng-template matStepLabel>Termin auswählen</ng-template>
          <mat-form-field appearance="fill">
            <mat-label>Address</mat-label>
            <input matInput formControlName="secondCtrl" placeholder="Ex. 1 Main St, New York, NY"
                   required>
          </mat-form-field>
          <div>
            <button mat-button matStepperPrevious>Back</button>
            <button mat-button matStepperNext>Next</button>
          </div>
        </form>
      </mat-step>
      <mat-step>
        <ng-template matStepLabel>Protokoll führen</ng-template>
        <p>You are now done.</p>
        <div>
          <button mat-button matStepperNext>Next</button>
        </div>
      </mat-step>
      <mat-step>
        <ng-template matStepLabel>Organisation abschließen</ng-template>
        <p>You are now done.</p>
        <div>
          <div>
            <button mat-button matStepperNext>Next</button>
          </div>
        </div>
      </mat-step>
    </mat-stepper>
  `,
  styles: [`
    .logo {
      height: 80%;
    }

    .spacer {
      flex: 1 1 auto;
    }

    mat-form-field {
      width: 100%;
    }
  `]
})
export class OrganizerComponent {
  dateOptionControl = new FormControl('');
  @ViewChild('dateOptionInput') dateOptionInput!: ElementRef<HTMLInputElement>;

  filteredDateOptions: Observable<string[]>;
  selectedDateOptions: string[] = [];
  allDateOptions: string[] = [];

  constructor(private formBuilder: FormBuilder) {
    this.firstFormGroup = this.formBuilder.group({
      location: [''],
      poll: FormGroup
    });

    this.secondFormGroup = this.formBuilder.group({
      secondCtrl: ['']
    });

    this.filteredDateOptions = this.dateOptionControl.valueChanges.pipe(
      startWith(null),
      map((dateOption: string | null) => (dateOption ? this._filter(dateOption) : this.getPossibleDateOptions().slice())),
    );

    const month = new Date().getMonth();
    const date = new Date(2022, month, 1);
    while (date.getMonth() === month) {
      this.allDateOptions.push(new Date(date).toLocaleDateString("de-AT", {
        weekday: "short",
        year: "2-digit",
        month: "numeric",
        day: "numeric"
      }));
      date.setDate(date.getDate() + 1);
    }

  }

  firstFormGroup: any;
  secondFormGroup: any;

  remove(dateOption: string) {
    const index = this.selectedDateOptions.indexOf(dateOption, 0);
    if (index > -1) {
      this.selectedDateOptions.splice(index, 1);
    }
  }

  add(event: MatChipInputEvent) {
    const value = (event.value || '').trim();

    // Add our fruit
    if (value && this.allDateOptions.indexOf(value) >= 0) {
      this.selectedDateOptions.push(value);
    }

    // Clear the input value
    event.chipInput!.clear();

    this.dateOptionControl.setValue(null);
  }

  selected(event: MatAutocompleteSelectedEvent) {
    this.selectedDateOptions.push(event.option.viewValue);
    this.dateOptionInput.nativeElement.value = '';
    this.dateOptionControl.setValue(null);
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.getPossibleDateOptions()
      .filter(dateOption => dateOption.toLowerCase().includes(filterValue));
  }

  private getPossibleDateOptions() {
    return this.allDateOptions.filter(dateOption => this.selectedDateOptions.indexOf(dateOption) < 0);
  }
}

export class PollOption {
  value!: string;


}
