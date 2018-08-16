import { Component, OnInit, Output } from '@angular/core';

import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { CategoryModel } from 'src/model/category.model';
import { DataService } from 'src/service/data.service';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-navigator',
  templateUrl: './navigator.component.html',
  styleUrls: ['./navigator.component.css']
})
export class NavigatorComponent implements OnInit {

  nestedTreeControl: NestedTreeControl<CategoryModel>;
  nestedDataSource: MatTreeNestedDataSource<CategoryModel>;

  hasNestedChild = (_: number, nodeData: CategoryModel) => !!nodeData.ESubCategories;

  private _getChildren = (node: CategoryModel) => node.ESubCategories;

  @Output()
  changeCategory: EventEmitter<string> = new EventEmitter<string>();


  constructor(private service: DataService) {

    this.nestedTreeControl = new NestedTreeControl<CategoryModel>(this._getChildren);
    this.nestedDataSource = new MatTreeNestedDataSource();
    this.nestedDataSource.data = [];

    this.nestedDataSource.data = service.getCategories();
  }

  selectCategory(categoryId: string) {

    this.changeCategory.emit(categoryId);
  }


  ngOnInit() {

  }

}
