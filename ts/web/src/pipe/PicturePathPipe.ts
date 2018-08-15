import { Pipe, PipeTransform } from '@angular/core';
import { PictureModel } from '../model/picture.model';
import { PictureService } from '../service/picture.service';

@Pipe({
    name: 'picturePathHandler',
    pure: true // 如果你的管道不受外界影响，只受参数的影响请遵守FP原则，设置为纯管道
})

export class PicturePathPipe implements PipeTransform {


    /**
     * 
     * @param src 路径
     * @param type 0表示获取全路径 1表示获取快照路径
     */
    transform(src: string, type: number = 0): string {

        var path = new PictureService().getPath(src, type);

        return path;
    }
}