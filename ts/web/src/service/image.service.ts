import { Injectable } from '@angular/core';
import { Size } from '../entity/size.entity';

@Injectable({
    providedIn: 'root'
})
export class ImageService {

    constructor() { }

    getImageStyle(src: string, max: number): any {

        var size = this.getSize(src, max);
        return {
            'width': size.width + 'px',
            'height': size.height + 'px',
            'margin-left': size.left + 'px',
            'margin-top': size.top + 'px'
        }
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
