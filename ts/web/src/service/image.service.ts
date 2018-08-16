import { Injectable } from '@angular/core';
import { Size } from '../entity/size.entity';
import { PictureService } from './picture.service';

@Injectable({
    providedIn: 'root'
})
export class ImageService {

    constructor(private pictureService: PictureService) { }

    getImageStyle(src: string, max: number): any {

        src = this.pictureService.getPath(src, 1);

        var size = this.getSize(src, max);
        return {
            'width': size.width + 'px',
            'height': size.height + 'px',
            'margin-left': size.left + 'px',
            'margin-top': size.top + 'px'
        }
    }

    /**
     * 按照比例来缩放
     */
    getImageStyleByFixSize(src: string, height: number, width: number, fixHeight: number, fixWidth: number): any {

        src = this.pictureService.getPath(src, 0);

        var size = this.getSizeByFixSize(height, width, fixHeight, fixWidth);
        return {
            'width': size.width + 'px',
            'height': size.height + 'px',
            'margin-left': size.left + 'px',
            'margin-top': size.top + 'px'
        }
    }

    /**
     * 
     * @param src 根据比例来算
     * @param maxHeight 
     * @param maxWidth 
     */
    getSizeByFixSize(height: number, width: number, fixHeight: number, fixWidth: number): Size {
        var left = 0;
        var top = 0;

        var imageRate = width / height;//2336/4160 = 0.5
        var fixRate = fixWidth / fixHeight;//1170/480 = 3

        var finalWidth = 0;
        var finalHeight = 0;

        //如果图片的宽:高 大于 规定的宽:高，比如图片是 3:1， 固定是2:1，则需要，将3调整为2,1调整为0.666
        if (imageRate > fixRate) {
            finalWidth = fixWidth;
            finalHeight = fixWidth * imageRate;
            //左右无边距，上下有边距
            left = 0;
            top = (fixHeight - finalHeight) / 2.0;
        }
        else {
            finalHeight = fixHeight;
            finalWidth = fixHeight * imageRate;
            //上下无边距，左右有边距
            top = 0;
            left = (fixWidth - finalWidth) / 2.0;
        }
        return { width: finalWidth, height: finalHeight, top: top, left: left };
    }

    /**
     * 
     * @param src 获取图片的大小，按照比例
     * @param max 
     */
    getSize(src: string, max: number): Size {

        var img = new Image();
        img.src = src;
        var width = img.width;
        var height = img.height;
        var left = 0;
        var top = 0;

        if (width > height) {
            height = height / width * max;
            width = max;
            left = 0;
            top = (max - height) / 2;
        }
        else {
            width = width / height * max;
            height = max;
            top = 0;
            left = (max - width) / 2;
        }

        return { width: width, height: height, top: top, left: left };
    }
}
