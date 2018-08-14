import { BaseModel } from "./base.model";

//客户留言
export class MessageModel  extends BaseModel{

    //留言主题
    ESubject?: string;

    //留言内容
    EBody?: string;
}