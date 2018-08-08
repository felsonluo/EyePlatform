import { ItemModel } from "./item.model";

export class CategoryModel {

    //类别ID
    EId?: string;

    //名称键
    ECategoryName?: string;

    //父属性id
    EParentId?: string;

    //展示排序
    EIndex?: number;

    //是否显示
    EIsActive?: boolean;

    //子类别
    ESubCategories?: CategoryModel[];

    //对应的项目
    EItems?: ItemModel[];
}