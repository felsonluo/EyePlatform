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

            return Json(new { Data = items }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取所有的分类，包括item 和 pictures
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCategories()
        {
            var categories = _category.GetCategories();
            var items = _item.GetItems();
            var pictures = _picture.GetPictures();

            for (var i = 0; i < items.Count; i++)
            {
                items[i].Pictures = pictures.Where(x => x.EItemId == items[i].EId).ToList();
            }

            for (var i = 0; i < categories.Count; i++)
            {
                categories[i].EItems = items.Where(x => x.ECategoryId == categories[i].EId).ToList();
            }

            //处理级别
            var firstLevelCategories = categories.Where(x => string.IsNullOrWhiteSpace(x.EParentId)).ToList();

            firstLevelCategories.ForEach(x =>
            {
                x.ESubCategories = categories.Where(y => y.EParentId == x.EId).ToList();
            });


            return Json(new { Data = firstLevelCategories }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPicutres()
        {
            var pictures = _picture.GetPictures();

            return Json(new { Data = pictures }, JsonRequestBehavior.AllowGet);
        }
    }
}
