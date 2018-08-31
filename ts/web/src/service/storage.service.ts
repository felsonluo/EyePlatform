import { Injectable } from '@angular/core';
import { CategoryModel } from '../model/category.model';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }

  private categoriesName = "categories";

  /**
   * 设置数据
   */
  getCategories(): CategoryModel[] {
    return JSON.parse(localStorage.getItem(this.categoriesName));
  }

  /**
   * 
   * @param categories 保存起来
   */
  setCategories(categories: CategoryModel[]) {
    localStorage.setItem(this.categoriesName, JSON.stringify(categories));
  }


  /**
   * 保存登陆状态
   */
  setLoginState(value: boolean) {

    sessionStorage.setItem("loginState", value ? "1" : "0");
  }

  /**
   * 获取登陆状态
   */
  getLoginState(): boolean {
    return sessionStorage.getItem("loginState") === "1";
  }
}
