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
}
