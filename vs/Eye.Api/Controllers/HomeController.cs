using Eye.BusinessService;
using Eye.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Eye.Api.Controllers
{
    public class HomeController : Controller
    {
        private ItemBusiness _item = new ItemBusiness();
        private PictureBusiness _picture = new PictureBusiness();
        private CategoryBusiness _category = new CategoryBusiness();


        public ActionResult GetItems()
        {
            var items = _item.GetItems();

            return Json(new { Data = items },JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCategories()
        {
            var categories = _category.GetCategories();

            return Json(new { Data = categories }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPicutres()
        {
            var pictures = _picture.GetPictures();

            return Json(new { Data = pictures }, JsonRequestBehavior.AllowGet);
        }
    }
}
