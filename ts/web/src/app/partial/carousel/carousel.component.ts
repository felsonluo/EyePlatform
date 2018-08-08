import { Component, OnInit } from '@angular/core';
import { DashboardProduct } from '../../../model/dashboardProduct';
import { DataService } from '../../../service/data.service';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css']
})
export class CarouselComponent implements OnInit {

  //展示在首页的几张图片
  dashboardProduct: DashboardProduct[] = [];

  constructor(private service: DataService) {

  }

  ngOnInit() {

    this.service.getDashboardProduct('').subscribe(data => this.dashboardProduct.push(data));
  }

}
