import { Injectable } from '@angular/core';
import { PictureModel } from '../model/picture.model';
import { PhotoComponent } from 'src/app/photo/photo.component';
import { MatDialog } from '../../node_modules/@angular/material';

@Injectable({
  providedIn: 'root'
})
export class PictureService {

  maxImageSrc: string;
  maxImageHeight: number;
  maxImageWidth: number;

  //private rootPath = "http://image.luoqunyi.com/yuki/";
  private rootPath = "src/photo/";

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

  openImageDialog(dialog: MatDialog, picture: PictureModel): void {

    var src = this.getPath(picture.EPath);

    var pictrueWidth = picture.EWidth;
    var pictureHeight = picture.EHeight;

    if (picture.EWidth > (window.innerWidth - 100)) {
      pictrueWidth = window.innerWidth - 100;
      pictureHeight = picture.EHeight * (pictrueWidth / picture.EWidth);
    }

    if (pictureHeight > (window.innerHeight - 100)) {
      var temp = window.innerHeight - 100;
      pictrueWidth = pictrueWidth * (temp / pictureHeight);
      pictureHeight = temp;
    }

    const dialogRef = dialog.open(PhotoComponent, {
      width: (pictrueWidth + 50) + 'px',
      height: (pictureHeight + 50) + 'px',
      data: { src: src, width: pictrueWidth, height: pictureHeight }
    });
  }
}
