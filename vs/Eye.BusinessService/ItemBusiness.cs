using Eye.DataModel.DataModel;
using Eye.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.BusinessService
{
    public class ItemBusiness
    {
        private readonly ItemRepository _item = new ItemRepository();

        /// <summary>
        /// 获取所有项目
        /// </summary>
        /// <returns></returns>
        public List<ItemModel> GetItems()
        {
            var items = _item.FindAll();

            return items;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool SaveItems(List<ItemModel> items)
        {
            return _item.InsertBatch(items);
        }
    }
}
