import { Item } from "./item.model";

export class Category {

    //类别ID
    Id?: string;

    //名称键
    CategoryName?: string;

    //父属性id
    ParentId?: string;

    //展示排序
    Index?: number;

    //是否显示
    IsActive?: boolean;

    //子类别
    SubCategories?: Category[];

    //对应的项目
    Items?: Item[];
}