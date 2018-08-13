using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.Common
{
    public class BaseModel
    {
        public ObjectId _id { get; set; }

        public string EId { get; set; }

        public string EName { get; set; }

        public bool EIsNew { get; set; }

        public bool EIsActive { get; set; }

    }
}
