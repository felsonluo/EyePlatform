import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../service/data.service';
import { ItemModel } from '../../../model/item.model';
import { ImageService } from 'src/service/image.service';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css']
})
export class CarouselComponent implements OnInit {

  //展示在首页的几张图片
  dashboardItems: ItemModel[] = [];

  constructor(private service: DataService, private imageService: ImageService) {

  }

  ngOnInit() {

    this.dashboardItems = this.service.getDashboardItems();
  }

}
