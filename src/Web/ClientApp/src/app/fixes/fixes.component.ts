import {Component} from '@angular/core';
import {FixesService} from "./fixes.service";
import {FixeModel} from "../../api";

@Component({
  selector: 'app-fixes',
  template: `
    <section class="fixes-container">
      <article *ngFor="let fixe of pastFixes" class="fixe-card">
        <mat-card>
          <mat-card-header>
            <img mat-card-avatar [src]="fixe.organizer.avatarUrl" [alt]="fixe.organizer.nickname"/>
            <mat-card-title>{{fixe.title}}</mat-card-title>
            <mat-card-subtitle>{{fixe.location}}</mat-card-subtitle>
          </mat-card-header>
          <img *ngIf="fixe.backgroundUrl != null" mat-card-image [src]="fixe.backgroundUrl" [alt]="fixe.location">
          <mat-card-content>
            <div>
              <span>Organisator: </span><span>{{fixe.organizer.nickname}}</span>
            </div>
            <div>
              <span>Beginn: </span><span>{{fixe.start}}</span>
            </div>
          </mat-card-content>
          <mat-card-actions>
            <button [routerLink]="fixe.id" mat-button>
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
    .fixes-container {
      display: flex;
      justify-content: space-evenly;
      flex-wrap: wrap;
      align-items: stretch;
      align-content: flex-start;
      padding: 1em;
    }

    .fixe-card {
      margin-bottom: 1em;
      max-width: 400px;
      width: 100%;
    }

    .fixe-card mat-card {
      height: 100%;
      display: flex;
      flex-direction: column;
      align-items: stretch;
      justify-content: space-between;
    }

    mat-card-content {
      padding: 1em;
    }
  `
  ]
})
export class FixesComponent {
  pastFixes: FixeModel[] = [];

  constructor(private fixesService: FixesService) {
  }

  ngOnInit(): void {
    this.getFixes();
  }

  getFixes() {
    this.fixesService.getPastFixes().subscribe((fixes: FixeModel[]) => this.pastFixes = fixes);
  }

  edit(fixes: FixeModel) {

  }
}
