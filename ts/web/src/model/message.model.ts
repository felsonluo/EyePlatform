//客户留言
export class MessageModel {

    //客户的Id，新客户则创建一个
    EId?: string;

    //留言主题
    ESubject?: string;

    //留言内容
    EBody?: string;

    //是否显示
    EIsActive?: boolean;
}