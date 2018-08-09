﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.DataModel.DataModel
{
    public class ItemModel
    {
        //id
        public string EId { get; set; }

        //商品名称
        public string EName { get; set; }

        //别名
        public string EDetailName { get; set; }

        //商品代码
        public string ECode { get; set; }

        //描述
        public string EDescription
        { get; set; }

        //特性
        public string EFeatures { get; set; }

        //是否是新品
        public bool EIsNew { get; set; }

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

        //是否显示
        public bool EActive { get; set; }



        //价格币别
        public CurrencyModel ECurrency { get; set; }

        //类别
        public CategoryModel ECategories { get; set; }

        //对应的图片
        public PictureModel[] Pictures { get; set; }

        //对应的文档
        public DocumentModel[] EDocuments { get; set; }
    }
}