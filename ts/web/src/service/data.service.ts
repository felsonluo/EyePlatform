import { Injectable } from '@angular/core';
import { Category } from '../model/category.model';
import { Observable, from } from 'rxjs';
import { User } from '../model/user.model';
import { Item } from '../model/item.model';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor() { }


  /**
   * 获取商品大类
   * @param userId 用户Id
   */
  getCategories(userId: string): Observable<Category> {

    return from([]);
  }

  /**
   * 获取用户信息
   * @param userId 用户Id
   */
  getUser(userId: string): Observable<User> {

    return from([]);
  }

  /**
   * 获取某种类别下的产品
   * @param categoryId 类别Id
   */
  getItemByCategoryId(categoryId: string): Observable<Item[]> {

    return from([]);
  }

  /**
   * 获取某种类别下的产品
   * @param categoryId 类别Id
   */
  getLatestItem(categoryId: string): Observable<Item> {

    return from([]);
  }

  /**
   * 获取首页的几个产品
   * @param userId 用户Id
   */
  getDashboardItem(userId: string): Observable<Item> {

    return from([]);
  }

  /**
   * 获取首页的几个产品
   * @param userId 用户Id
   */
  getFeautredItem(userId: string): Observable<Item[]> {

    return from([]);
  }

/**
 * 根据一个ID获取项目
 * @param itemId 
 */
  getItemById(itemId: string): Item {
    return {};
  }


}
