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


  private apiUrl = "http://api.tanyundan.com/Home/GetCategories";

  constructor(private http: HttpClient, private storage: StorageService) {


  }

  /**
   * 从api接口获取分类
   */
  private getCategoriesFromApi(): Observable<CategoryModel> {

    var result = this.http.get<CategoryModel>(this.apiUrl);

    return result;
  }

  /**
   * 获取商品大类
   * @param 
   */
  getCategories(): Observable<CategoryModel> {

    var categories = this.storage.getCategories();

    if (categories === null) {

      this.getCategoriesFromApi().subscribe(x => categories.push(x));
      this.storage.setCategories(categories);
    }

    return from(categories);
  }


  /**
   * 
   * @param categoryId 获取某一个Category
   */
  getCategoriesById(categoryId: string): CategoryModel {

    var categories = this.getCategories();

    var category: CategoryModel;

    categories.pipe(
      filter(x => x.EId === categoryId),
      take(1),
      map(x => category = x)
    );

    return category;
  }


  /**
   * 获取某种类别下的产品
   * @param categoryId 类别Id
   */
  getItemsByCategoryId(categoryId: string): Observable<ItemModel> {

    var categories = this.getCategories();

    var result: Observable<ItemModel>;

    categories.pipe(
      filter(x => x.EId === categoryId),
      take(1),
      map((value, index) => { result = from(value.EItems) })
    );

    return result;
  }


  /**
   * 获取项目
   */
  getItems(): Observable<ItemModel> {

    var categories = this.getCategories();

    var items: ItemModel[] = [];

    categories.pipe(
      map((value, index) => { items.concat(value.EItems); })
    );

    return from(items);
  }

  /**
   * 获取某种类别下的产品
   * @param categoryId 类别Id
   */
  getLatestItems(categoryId?: string): Observable<ItemModel> {

    var categories = categoryId === undefined ? this.getCategories() : from([this.getCategoriesById(categoryId)]);

    var items: ItemModel[] = [];

    categories.pipe(
      map(x => items.concat(x.EItems))
    );

    return from(items);
  }

  /**
   * 获取首页的几个产品
   * @param userId 用户Id
   */
  getDashboardItems(userId: string): Observable<ItemModel> {

    var categories = this.getCategories();

    var items: ItemModel[] = [];

    categories.pipe(
      map((value, index) => { items.concat(value.EItems); })
    );

    var result = from(items).pipe(
      filter(x => x.EDashboard === true)
    );

    return result;
  }

  /**
   * 获取首页的几个产品
   * @param 
   */
  getFeautredItems(): Observable<ItemModel[]> {

    var categories = this.getCategories();

    var items: ItemModel[] = [];

    categories.pipe(
      map((value, index) => { items.concat(value.EItems); })
    );

    items = items.sort((a, b) => {

      if (a.EDateTime < b.EDateTime) return 1;
      if (a.EDateTime === b.EDateTime) return 0;
      if (a.EDateTime > b.EDateTime) return -1;

    });



    return from([[items[0], items[0], items[0], items[0]], [items[0], items[0], items[0], items[0]]]);
  }

  /**
   * 根据一个ID获取项目
   * @param itemId 
   */
  getItemById(itemId: string): ItemModel {

    var items = this.getItems();

    var item: ItemModel;

    items.pipe(
      filter(x => x.EId === itemId),
      take(1)
    );

    return item;
  }

}
