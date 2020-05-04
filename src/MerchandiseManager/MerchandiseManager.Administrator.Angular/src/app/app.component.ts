import { Component } from '@angular/core';
import { faBoxes, faWarehouse, faStore } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  faBoxes = faBoxes;
  faWarehouse = faWarehouse;
  faStore = faStore;
}
