import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { LatestComponent } from 'src/app/partial/body/latest/latest.component';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  @Input()
  public categoryId: string;

  @ViewChild('latest')
  latest: LatestComponent;


  constructor() { }

  /**
   * 重新初始化
   */
  init(categoryId: string) {
    this.categoryId = categoryId;
    this.latest.init(this.categoryId);
  }

  ngOnInit() {
  }

}
