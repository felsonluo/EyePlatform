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

            return Json(items, JsonRequestBehavior.AllowGet);
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
                items[i].EPictures = pictures.Where(x => x.EItemId == items[i].EId).ToList();
            }

            for (var i = 0; i < categories.Count; i++)
            {
                categories[i].EItems = items.Where(x => x.ECategoryId == categories[i].EId).ToList();
            }

            //处理级别
            var firstLevelCategories = categories.Where(x => string.IsNullOrWhiteSpace(x.EParentId)).ToList();

            firstLevelCategories.ForEach(x =>
            {
                x.EName = GetYearName(x.EName);
                x.ESubCategories = categories.Where(y => y.EParentId == x.EId).ToList();
                x.ESubCategories.ForEach(m => m.EName = GetMonthName(m.EName));
            });


            return Json(firstLevelCategories, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取年份
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private string GetYearName(string year)
        {
            int y = int.Parse(year);

            switch (y)
            {
                case 2014: return year + "(" + "Horse" + ")";
                case 2015: return year + "(" + "Goat" + ")";
                case 2016: return year + "(" + "Monkey" + ")";
                case 2017: return year + "(" + "Rooster" + ")";
                case 2018: return year + "(" + "Dog" + ")";
                case 2019: return year + "(" + "Pig" + ")";
                case 2020: return year + "(" + "Rat" + ")";
                default: return year;
            }
        }

        /// <summary>
        /// 获取月份
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        private string GetMonthName(string month)
        {

            var m = month.Split('-')[1];

            switch (m)
            {
                case "01":
                    return  "Jan.(" + "apricornus" + ")";
                case "02":
                    return  "Feb.(" + "Aquarius" + ")";
                case "03":
                    return  "Mar.(" + "Pisces" + ")";
                case "04":
                    return  "Apr.(" + "Aries" + ")";
                case "05":
                    return  "May.(" + "Taurus" + ")";
                case "06":
                    return  "Jun.(" + "Gemini" + ")";
                case "07":
                    return  "Jul.(" + "Cancer" + ")";
                case "08":
                    return  "Aug.(" + "Leo" + ")";
                case "09":
                    return  "Sep.(" + "Virgo" + ")";
                case "10":
                    return  "Oct.(" + "Libra" + ")";
                case "11":
                    return  "Nov.(" + "Scorpio" + ")";
                case "12":
                    return  "Dec.(" + "Sagittarius" + ")";
                default: return m;
            }


        }

        public ActionResult GetPicutres()
        {
            var pictures = _picture.GetPictures();

            return Json(pictures, JsonRequestBehavior.AllowGet);
        }
    }
}
