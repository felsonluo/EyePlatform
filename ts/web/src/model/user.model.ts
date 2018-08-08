import { KeyValuePairs } from "../entity/keyvaluepairs";

//商家
export class User {

    //商品名称
    name?: string;

    //id
    id?: string;

    //网站样式
    theme?: string;

    //地址
    address?: string;

    //邮箱
    email?: string;

    //电话
    telephone?: string;

    //传真
    fax?: string;

    //网址
    website?: string;

    //
    wechatId?: string;

    //
    qq?: string;

    //
    openHours?: KeyValuePairs[];

    //是否显示
    active?: boolean;
}