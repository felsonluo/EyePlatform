//客户留言
export class Message {

    //客户的Id，新客户则创建一个
    Id?: string;

    //留言主题
    Subject?: string;

    //留言内容
    Body?: string;
    
    //是否显示
    Active?: boolean;
}