import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductListComponent } from '../partial/body/product-list/product-list.component';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  public categoryId: string;

  @ViewChild('product')
  product: ProductListComponent;

  public changeCategory(categoryId: string) {
    this.categoryId = categoryId;
    this.product.init(categoryId);
  }

  constructor() { }

  ngOnInit() {
  }

}
