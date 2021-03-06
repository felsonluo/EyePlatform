﻿using Eye.Common;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.DataModel.DataModel
{
    public class CategoryModel : BaseModel
    {
        //父属性id
        public string EParentId { get; set; }

        //展示排序
        public int EIndex { get; set; }

        //子类别
        [BsonIgnore]
        public List<CategoryModel> ESubCategories { get; set; }

        //对应的项目
        [BsonIgnore]
        public List<ItemModel> EItems { get; set; }
    }
}
