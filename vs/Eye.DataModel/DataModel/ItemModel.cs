using Eye.Common;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.DataModel.DataModel
{
    public class ItemModel : BaseModel
    {

        //别名
        public string EDetailName { get; set; }

        //商品代码
        public string ECode { get; set; }

        //描述
        public string EDescription { get; set; }

        //是否显示在主页
        public bool EDashboard { get; set; }

        //特性
        public string EFeatures { get; set; }

        //是否显示
        public bool EShow { get; set; }

        //商品价格
        public decimal EPrice { get; set; }

        //折扣
        public decimal EDiscount { get; set; }

        //库存
        public decimal EStock { get; set; }

        //价格小数位
        public decimal EPrecise { get; set; }

        //备注
        public string EComments { get; set; }

        //是否作为有特征的产品
        public bool EFeatured { get; set; }

        //币别Id
        public string ECurrencyId { get; set; }

        //类别ID
        public string ECategoryId { get; set; }



        //价格币别
        [BsonIgnore]
        public CurrencyModel ECurrency { get; set; }

        //对应的图片
        [BsonIgnore]
        public IList<PictureModel> Pictures { get; set; }

        //对应的文档
        [BsonIgnore]
        public IList<DocumentModel> EDocuments { get; set; }
    }
}
