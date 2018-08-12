using Eye.Common;
using Eye.DataModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.DataRepository
{
    public class PictureRepository : BaseDAL<PictureModel>
    {
        private readonly ItemRepository _item = new ItemRepository();

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="pictures"></param>
        /// <returns></returns>
        
    }
}
