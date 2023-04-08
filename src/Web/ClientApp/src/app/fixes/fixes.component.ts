import {Component} from '@angular/core';
import {FixesService} from "./fixes.service";
import {FixeModel} from "../../api";

@Component({
  selector: 'app-fixes',
  template: `
      <div class="fixes-container">
          <article *ngFor="let fixe of pastFixes" class="fixe-card">
              <mat-card>
                  <mat-card-header>
                      <img mat-card-avatar [src]="fixe.organizer.avatarUrl" [alt]="fixe.organizer.nickname"/>
                      <mat-card-title>{{fixe.title}}</mat-card-title>
                      <mat-card-subtitle>{{fixe.location}}</mat-card-subtitle>
                  </mat-card-header>
                  <img *ngIf="fixe.backgroundUrl != null" mat-card-image [src]="fixe.backgroundUrl"
                       [alt]="fixe.location" class="fixe-image">
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
      </div>
  `,
  styles: [`
    .fixes-container {
      display: flex;
      flex-direction: row;
      flex-wrap: wrap;
      justify-content: flex-start;
      align-content: space-around;
      align-items: stretch;
      gap: 2em;
      max-width: 1000px;
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

    .fixe-image {
      max-height: 320px;
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
