import { Category } from "./category.model";
import { Currency } from "./currency.model";
import { Document } from "./document.model";

//具体商品
export class Item {

    //商品名称
    ItemName?: string;

    //别名
    ItemAliasName?: string;

    //商品代码
    Code?: string;

    //id
    Id?: string;

    //描述
    Description?: string;

    //是否是新品
    IsNew?: boolean;

    //是否显示
    Show?: boolean;

    //商品价格
    Price?: number;

    //图片路径
    Path?: string[];

    //备注
    Comments?: string;

    //是否作为有特征的产品
    Featured?: boolean;

    //折扣
    Discount?: number;

    //库存
    Stock?: number;

    //价格小数位
    Precise?: number;

    //特性
    Features?: string;

    //币别Id
    CurrencyId?: string;

    //类别ID
    CategoryId?: string;

    //是否显示
    Active?: boolean;

    //价格币别
    Currency?: Currency;

    //类别
    Category?: Category;

    
    Documents?: Document[];
}