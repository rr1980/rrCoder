import { Component, OnInit } from '@angular/core';
import { fader2 } from '../helper/route-animation';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  animations: [fader2]
})
export class HomeComponent implements OnInit {

  title = 'ClientApp';

  constructor() { }

  ngOnInit() {
  }
}
