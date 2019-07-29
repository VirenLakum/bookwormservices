import { Component, OnInit } from '@angular/core';
import { NgbCarouselConfig} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css'],
  providers: [NgbCarouselConfig]
})
export class CarouselComponent implements OnInit {

  constructor(config: NgbCarouselConfig) {
  config.interval = 5000;
  config.wrap = true;
  config.keyboard = false;
  config.pauseOnHover = true;
   }

  images : string[] = ['/assets/img/banner4.jpg', '/assets/img/hd-banner-3.png', '/assets/img/hd-banner-2.png', '/assets/img/hd-banner-1.png'];

  ngOnInit() {
  }

}
