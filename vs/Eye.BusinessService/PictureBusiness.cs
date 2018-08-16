using Eye.Common;
using Eye.DataModel.DataModel;
using Eye.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Eye.Common.PictureHandler;

namespace Eye.BusinessService
{
    public class PictureBusiness
    {
        private readonly CategoryBusiness _category = new CategoryBusiness();
        private readonly ItemBusiness _item = new ItemBusiness();

        private readonly PictureRepository _dal = new PictureRepository();

        /// <summary>
        /// 获取所有图片
        /// </summary>
        /// <returns></returns>
        public List<PictureModel> GetPictures()
        {
            var pictures = _dal.FindAll();

            return pictures;
        }
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="pictures"></param>
        /// <returns></returns>
        public bool SavePicture(PictureModel picture)
        {

            //项目分类
            var categories = _category.GetCategories();
            //项目
            var items = _item.GetItems();

            var picturesInDatabase = GetPictures();
            //需要修改的照片
            var pictures2modify = new List<KeyValuePair<string, string>>();

            //1.处理图片的Id
            if (string.IsNullOrWhiteSpace(picture.EId) || !picturesInDatabase.Exists(x => x.EId == picture.EId))
            {
                //新建一个Id
                picture.EId = GUIDHelper.GetGuid();
                picture.EIsNew = true;
                //处理分类
                var catetoryName = picture.ETakeTime.ToString("yyyy-MM");
                var category = categories.FirstOrDefault(x => x.EName == catetoryName);

                var parentCategoryName = picture.ETakeTime.ToString("yyyy");
                var parentCategory = categories.FirstOrDefault(x => x.EName == parentCategoryName);

                if (parentCategory == null)
                {
                    parentCategory = new CategoryModel()
                    {
                        EId = GUIDHelper.GetGuid(),
                        EName = parentCategoryName,
                        EIsNew = true
                    };

                    categories.Add(parentCategory);
                }
                //如果不存在
                if (category == null)
                {

                    category = new CategoryModel()
                    {
                        EId = GUIDHelper.GetGuid(),
                        EName = catetoryName,
                        EParentId = parentCategory.EId,
                        EIsNew = true
                    };

                    categories.Add(category);
                }

                //处理项目
                var item = new ItemModel()
                {
                    EId = GUIDHelper.GetGuid(),
                    ECategoryId = category.EId,
                    EIsNew = true,
                    EName = picture.ETakeTime.ToString("yyyy-MM-dd"),
                    EDetailName = picture.EName,
                    EDateTime = picture.ETakeTime
                };
                items.Add(item);


                picture.EItemId = item.EId;

                pictures2modify.Add(new KeyValuePair<string, string>(picture.EPath, picture.EId));
            }


            PictureHandler.SetPictureInfo(PictruePropertyHexTable.Author, pictures2modify);

            _item.SaveItems(items);

            _category.SaveCategorys(categories);

            SavePictures(new List<PictureModel>() { picture });

            return true;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="pictures"></param>
        /// <returns></returns>
        public bool SavePictures(List<PictureModel> pictures)
        {
            var result = _dal.InsertOrUpdateBatch(pictures);

            return result;
        }


    }
}
