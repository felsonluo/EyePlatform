import { Pipe, PipeTransform } from '@angular/core';
import { ImageService } from '../service/image.service';
import { Size } from '../model/size.model';

@Pipe({
    name: 'imageMeasure',
    pure: true // 如果你的管道不受外界影响，只受参数的影响请遵守FP原则，设置为纯管道
})

export class ImageSizePipe implements PipeTransform {

    transform(src: string, max: number): Size {

        return new ImageService().getSize(src, max);
    }
}