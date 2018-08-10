import { ItemModel } from "./item.model";
import { BaseModel } from "src/model/base.model";

export class CategoryModel extends BaseModel {

    //名称键
    ECategoryName?: string;

    //父属性id
    EParentId?: string;

    //展示排序
    EIndex?: number;

    //子类别
    ESubCategories?: CategoryModel[];

    //对应的项目
    EItems?: ItemModel[];
}