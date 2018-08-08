import { KeyValuePairs } from "../entity/keyvaluepairs";

//商家
export class OwnerModel {

    //商品名称
    EName?: string;

    //id
    EId?: string;

    //网站样式
    ETheme?: string;

    //地址
    EAddress?: string;

    //邮箱
    EEmail?: string;

    //电话
    ETelephone?: string;

    //传真
    EFax?: string;

    //网址
    EWebsite?: string;

    //
    EWechatId?: string;

    //
    EQQ?: string;

    //
    EOpenHours?: KeyValuePairs[];

    //是否显示
    EIsActive?: boolean;
}