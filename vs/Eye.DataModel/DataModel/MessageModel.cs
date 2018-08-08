using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.DataModel.DataModel
{
    public class MessageModel
    {
        public string EId { get; set; }

        public string ESubject { get; set; }

        public string EBody { get; set; }

        public bool EMIsActive { get; set; }
    }
}
