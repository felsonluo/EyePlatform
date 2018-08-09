using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.DataModel.DataModel
{
    public class OwnerModel
    {
        //商品名称
        public string EName { get; set; }

        //id
        public string EId { get; set; }

        //网站样式
        public string ETheme { get; set; }

        //地址
        public string EAddress { get; set; }

        //邮箱
        public string EEmail { get; set; }

        //电话
        public string ETelephone { get; set; }

        //传真
        public string EFax { get; set; }

        //网址
        public string EWebsite { get; set; }

        //
        public string EWechatId { get; set; }

        //
        public string EQQ { get; set; }

        //
        public List<KeyValuePair<string, DateTime>> EOpenHours { get; set; }

        //是否显示
        public bool EIsActive { get; set; }
    }
}
