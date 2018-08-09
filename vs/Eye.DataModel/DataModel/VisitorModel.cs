using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.DataModel.DataModel
{
    public class VisitorModel
    {
        public string EId { get; set; }

        public string EName { get; set; }

        public string EEmail { get; set; }

        public string ETelephone { get; set; }

        public string EWechatId { get; set; }

        public string EQQ { get; set; }

        public string EIP { get; set; }

        //是否显示
        public bool EIsActive { get; set; }
    }
}
