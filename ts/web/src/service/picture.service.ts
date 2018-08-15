import { Injectable } from '@angular/core';
import { PictureModel } from '../model/picture.model';

@Injectable({
  providedIn: 'root'
})
export class PictureService {

  private rootPath = "http://image.luoqunyi.com/yuki/";

  constructor() { }

  /**
   * 获取真实路径
   */
  getPath(src: string, type: number = 0) {
    //0 xxxx/2018/2018-04/xxxx.jpg
    //1 xxxx/2018/2018-04/snapshot/snapshot_xxxx.jpg

    var path: string;

    if (type === 0) {
      var arr = src.split('\\');
      //获取最后三个小组
      path = this.rootPath + arr[arr.length - 3] + '/' + arr[arr.length - 2] + '/' + arr[arr.length - 1];
    }
    else if (type === 1) {
      var arr = src.split('\\');
      //获取最后四个小组
      path = this.rootPath + arr[arr.length - 4] + '/' + arr[arr.length - 3] + '/' + arr[arr.length - 2] + '/' + arr[arr.length - 1];
    }

    return path;
  }
}
