import { Component, OnInit } from '@angular/core';
import { fadeInAnimation } from '../helper/route-animation';
import { ConcatSource } from 'webpack-sources';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  animations: [fadeInAnimation],
  host: { '[@fadeInAnimation]': '' }
})
export class HomeComponent implements OnInit {

  title = 'ClientApp';

  constructor() { }

  ngOnInit() {
    console.debug("Start Home!");
  }
}
