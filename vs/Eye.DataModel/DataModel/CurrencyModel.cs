using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.DataModel.DataModel
{
    public class CurrencyModel
    {
        //名称
        public string ECurrencyName { get; set; }

        //id
        public string EId { get; set; }

        //符号
        public string ESymbol { get; set; }

        //是否显示
        public bool EIsActive { get; set; }
    }
}
