import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CategoryModel } from '../model/category.model';
import { Observable, from, of } from 'rxjs';
import { map, filter, scan, take } from 'rxjs/operators';
import { ItemModel } from '../model/item.model';
import { StorageService } from 'src/service/storage.service';
import { ValueTransformer } from '../../node_modules/@angular/compiler/src/util';

@Injectable({
  providedIn: 'root'
})
export class DataService {


  private apiUrl = "http://api.luoqunyi.com/Home/GetCategories";

  private lockName = 'eye_lock';

  constructor(private http: HttpClient, private storage: StorageService) {


  }

  /**
   * 从api接口获取分类
   */
  public getCategoriesFromApi(callback: () => void) {

    var result: CategoryModel[] = [];

    this.http.get<CategoryModel>(this.apiUrl).subscribe(
      (x: CategoryModel) => {
        result = result.concat(x);
      },
      undefined,
      () => {
        this.storage.setCategories(result);
        callback();
      });
  }

  /**
   * 获取商品大类
   * @param 
   */
  getCategories(): CategoryModel[] {

    var categories = this.storage.getCategories();

    return categories;
  }


  /**
   * 
   * @param categoryId 获取某一个Category
   */
  getCategoryById(categories: CategoryModel[], categoryId: string): CategoryModel {

    var category: CategoryModel;

    for (var i = 0; i < categories.length; i++) {
      if (categories[i].EId === categoryId) {
        category = categories[i];
        return category;
      }
      if (category == null && categories[i].ESubCategories != null && categories[i].ESubCategories != undefined && categories[i].ESubCategories.length > 0) {
        category = this.getCategoryById(categories[i].ESubCategories, categoryId);
      }

      if (category != null) return category;
    }

    return category;
  }


  /**
   * 获取某种类别下的产品
   * @param categoryId 类别Id
   */
  getItemsByCategoryId(categoryId: string): ItemModel[] {

    var categories = this.getCategories();

    var category = this.getCategoryById(categories, categoryId);

    var result: ItemModel[] = this.getItemsFromCategory(category);

    return result;
  }


  /**
   * 获取项目
   */
  getItems(): ItemModel[] {

    var categories = this.getCategories();

    var items: ItemModel[] = [];

    for (var i = 0; i < categories.length; i++) {
      items = items.concat(this.getItemsFromCategory(categories[i]));
    }

    return items;
  }

  /**
   * 从分类获取项目
   * @param category 
   */
  getItemsFromCategory(category: CategoryModel): ItemModel[] {

    var items: ItemModel[] = [];

    //如果是父级的
    if (category.EParentId === null) {

      for (var i = 0; i < category.ESubCategories.length; i++) {

        items = items.concat(this.getItemsFromCategory(category.ESubCategories[i]));
      }
    }
    else {
      if (category.ESubCategories === null || category.ESubCategories.length == 0)
        items = items.concat(category.EItems);
      else {
        for (var i = 0; i < category.ESubCategories.length; i++) {

          items = items.concat(this.getItemsFromCategory(category.ESubCategories[i]));
        }
      }
    }

    return items;
  }

  /**
   * 获取某种类别下的产品
   * @param categoryId 类别Id
   */
  getLatestItems(categoryId?: string): ItemModel[] {

    var result = categoryId === undefined ? this.getItems() : this.getItemsByCategoryId(categoryId);

    return result;
  }

  /**
   * 获取首页的几个产品
   * @param userId 用户Id
   */
  getDashboardItems(): ItemModel[] {

    var items = this.getItems();

    var result: ItemModel[] = [];

    for (var i = 0; i < items.length; i++) {

      if (items[i].EDashboard === true)
        result.push(items[i]);
    }

    return result;
  }

  /**
   * 获取首页的几个产品
   * @param 
   */
  getFeautredItems(): ItemModel[][] {

    var items = this.getItems();

    var result: ItemModel[][] = [];

    items = items.sort((a, b) => {

      if (a.EDateTime < b.EDateTime) return 1;
      if (a.EDateTime === b.EDateTime) return 0;
      if (a.EDateTime > b.EDateTime) return -1;

    });

    result = [[items[0], items[1], items[2], items[3]], [items[4], items[5], items[6], items[7]]];

    return result;
  }

  /**
   * 根据一个ID获取项目
   * @param itemId 
   */
  getItemById(itemId: string): ItemModel {

    var items = this.getItems();

    var item: ItemModel;

    for (var i = 0; i < items.length; i++) {
      if (items[i].EId === itemId)
        item = items[i];
    }

    return item;
  }

}
