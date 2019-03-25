import { Component } from '@angular/core';
import { fader2 } from './helper/route-animation';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [fader2]
})
export class AppComponent {

  constructor() {
  }
}
