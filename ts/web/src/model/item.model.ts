import { CategoryModel } from "./category.model";
import { CurrencyModel } from "./currency.model";
import { DocumentModel } from "./document.model";
import { PictureModel } from "./picture.model";

//具体商品
export class ItemModel {

    //id
    EId?: string;

    //商品名称
    EName?: string;

    //别名
    EDetailName?: string;

    //商品代码
    ECode?: string;

    //描述
    EDescription?: string;

    //特性
    EFeatures?: string;

    //是否是新品
    EIsNew?: boolean;

    //是否显示
    EShow?: boolean;

    //商品价格
    EPrice?: number;

    //折扣
    EDiscount?: number;

    //库存
    EStock?: number;

    //价格小数位
    EPrecise?: number;

    //备注
    EComments?: string;

    //是否作为有特征的产品
    EFeatured?: boolean;

    //币别Id
    ECurrencyId?: string;

    //类别ID
    ECategoryId?: string;

    //是否显示
    EActive?: boolean;



    //价格币别
    ECurrency?: CurrencyModel;

    //类别
    ECategory?: CategoryModel;

    //对应的图片
    EPictures?: PictureModel[];

    //对应的文档
    EDocuments?: DocumentModel[];
}