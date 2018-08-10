import { BaseModel } from "src/model/base.model";

export class PictureModel extends BaseModel {


    /// <summary>
    /// 是否选中
    /// </summary>
    EChecked?: boolean;

    /// <summary>
    /// 图片路径
    /// </summary>
    EPath?: string;

    /// <summary>
    /// 压缩后图片的路径
    /// </summary>
    ESnapshotPath?: string;

    /// <summary>
    /// 拍摄日期
    /// </summary>
    ETakeTime?: Date;


    /// <summary>
    /// 拍摄者
    /// </summary>
    EAuthor?: string;

    /// <summary>
    /// 拍摄地点
    /// </summary>
    ETakeLocation?: string;

    /// <summary>
    /// 图片大小
    /// </summary>
    ESize?: number;

    /// <summary>
    /// 宽度
    /// </summary>
    EWidth?: number;

    /// <summary>
    /// 高度
    /// </summary>
    EHeight?: number;


    /// <summary>
    /// 标签1（里面有哪些人物）
    /// </summary>
    ETags1?: string;


    /// <summary>
    /// 标签2（属于哪个相册）
    /// </summary>
    ETags2?: string;


    /// <summary>
    /// 照片描述
    /// </summary>
    EDescription?: string;
}