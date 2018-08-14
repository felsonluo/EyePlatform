import { KeyValuePairs } from "../entity/keyvaluepairs";
import { BaseModel } from "./base.model";

//商家
export class OwnerModel extends BaseModel {

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
}