using Eye.Common;
using Eye.DataModel.DataModel;
using Eye.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.BusinessService
{
    public class PictureBusiness
    {
        private readonly CategoryBusiness _category = new CategoryBusiness();
        private readonly ItemBusiness _item = new ItemBusiness();

        private readonly PictureRepository _dal = new PictureRepository();
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="pictures"></param>
        /// <returns></returns>
        public bool SavePictures(List<PictureModel> pictures)
        {

            //项目分类
            var categories = _category.GetCategories();
            //项目
            var items = _item.GetItems();
            //需要修改的照片
            var pictures2modify = new List<KeyValuePair<string, string>>();


            for (var i = 0; i < pictures.Count; i++)
            {
                //1.处理图片的Id
                if (string.IsNullOrWhiteSpace(pictures[i].EId))
                {
                    //新建一个Id
                    pictures[i].EId = GUIDHelper.GetGuid();

                    //处理分类
                    var catetoryName = pictures[i].ETakeTime.ToString("yyyy-MM");
                    var category = categories.FirstOrDefault(x => x.EName == catetoryName);
                    //如果不存在
                    if (category == null)
                    {

                        category = new CategoryModel()
                        {
                            EId = GUIDHelper.GetGuid(),
                            EName = catetoryName,
                            EIsNew = true
                        };

                        categories.Add(category);
                    }

                    //处理项目
                    var item = new ItemModel()
                    {
                        EId = GUIDHelper.GetGuid(),
                        ECategoryId = category.EId,
                        EIsNew = true
                    };
                    items.Add(item);


                    pictures[i].EItemId = item.EId;

                    pictures2modify.Add(new KeyValuePair<string, string>(pictures[i].EPath, pictures[i].EId));
                }
            }


            _item.SaveItems(items.Where(x => x.EIsNew).ToList());

            _category.SaveCategorys(categories.Where(x => x.EIsNew).ToList());

            _dal.InsertBatch(pictures);

            PictureHandler.SetPictureInfo(pictures2modify);

            return true;
        }
    }
}
