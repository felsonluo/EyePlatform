using Eye.DataModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager
{
    public class GridPictures
    {
        public List<PictureModel> PicturesInDatabase { get; set; }

        public List<PictureModel> PicturesInFolder { get; set; }

        public List<PictureModel> PicturesDraft { get; set; }

        public List<PictureModel> PicturesSaved { get; set; }
    }
}
