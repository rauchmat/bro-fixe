import {Component} from '@angular/core';
import {TestClient} from "../../api";

@Component({
  selector: 'app-admin',
  template: `
    <p>
      admin works!
    </p>

    <button mat-raised-button color="primary" (click)="onNotificationTest()">Notification Test</button>
  `,
  styles: []
})
export class AdminComponent {

  constructor(private testClient: TestClient) {
  }

  onNotificationTest() {
    this.testClient.testNotifications().subscribe();
  }
}
