import { Component, OnInit } from '@angular/core';

import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { DataService } from '../../../../service/data.service';
import { Category } from '../../../../model/category.model';

@Component({
  selector: 'app-navigator',
  templateUrl: './navigator.component.html',
  styleUrls: ['./navigator.component.css']
})
export class NavigatorComponent implements OnInit {

  nestedTreeControl: NestedTreeControl<Category>;
  nestedDataSource: MatTreeNestedDataSource<Category>;


  constructor(private service: DataService) {

    this.nestedTreeControl = new NestedTreeControl<Category>(this._getChildren);
    this.nestedDataSource = new MatTreeNestedDataSource();
    this.nestedDataSource.data = [];

    service.getCategories('').subscribe(data => this.nestedDataSource.data.push(data));
  }

  hasNestedChild = (_: number, nodeData: Category) => !!nodeData.SubCategories;

  private _getChildren = (node: Category) => node.SubCategories;

  ngOnInit() {

  }

}
