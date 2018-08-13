using Eye.DataModel.DataModel;
using Eye.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.BusinessService
{
    public class CategoryBusiness
    {
        private CategoryRepository _category = new CategoryRepository();
        /// <summary>
        /// 获取所有的分类
        /// </summary>
        /// <returns></returns>
        public List<CategoryModel> GetCategories()
        {
            return _category.FindAll();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool SaveCategorys(List<CategoryModel> categories)
        {
            return _category.InsertOrUpdateBatch(categories);
        }
    }
}
