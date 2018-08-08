/****************************************************
版权所有:美记软件（上海）有限公司
创 建 人:小莫
创建时间:2018-08-06 14:11:18
CLR 版本:4.0.30319.42000
文件描述:
* **************************************************/

using Eye.PhotoManager.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Drawing;
using MetadataExtractor;
using Eye.DataModel.DataModel;
using Eye.Common;

namespace Eye.PhotoManager.Utility
{
    /// <summary>
    /// 创 建 者:小莫
    /// 创建日期:2018-08-06 14:11:18
    /// 描   述:功能描述
	///
    /// </summary>
    public class Manager
    {

        #region 全局变量	
        private readonly static string[] IncludeFiles = new string[] { ".jpg", ".jpeg", ".png" };


        public static List<string> Tags1
        {
            get
            {
                var setting = ConfigurationManager.AppSettings["tags1"];
                return string.IsNullOrWhiteSpace(setting) ? new List<string>() : setting.Split(',').ToList();
            }
        }

        public static List<string> Tags2
        {
            get
            {
                var setting = ConfigurationManager.AppSettings["tags2"];
                return string.IsNullOrWhiteSpace(setting) ? new List<string>() : setting.Split(',').ToList();
            }
        }
        #endregion

        #region 构造方法		
        #endregion

        #region 公开方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pictures"></param>
        /// <returns></returns>
        public static int ReducePictures(List<PictureModel> pictures, string targetPath, int width)
        {
            var count = 0;

            if (pictures == null || !pictures.Any()) return count;

            for (var i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];

                var target = targetPath + "\\" + picture.EName;

                var success = PictureHandler.GetReducedImage(picture.EPath, width, target);

                if (success)
                {
                    count++;
                    picture.ESnapshotPath = target;
                }
            }

            return count;
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        /// <param name="picture"></param>
        public static void FillPictureInfo(PictureModel picture)
        {
            var info = PictureHandler.GetInnerInfo(picture.EPath);

            picture.ETags1 = info.Tag1;
            picture.ETags2 = info.Tag2;
            picture.EDescription = info.Description;
            picture.EWidth = int.Parse(info.Width);
            picture.EHeight = int.Parse(info.Height);

            DateTime time;
            var s = DateTime.TryParseExact(info.TakeTime,
                    "yyyy:MM:dd HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out time);

            picture.ETakeTime = time;
        }

        /// <summary>
        /// 将图片转移
        /// </summary>
        /// <param name="pictures"></param>
        /// <returns></returns>
        public static int MovePictures(List<PictureModel> pictures, string path)
        {
            var count = 0;

            if (pictures == null || !pictures.Any()) return count;

            for (var i = 0; i < pictures.Count; i++)
            {
                var dirPath = CreateCategoryFolder(path, pictures[i].ETakeTime);

                var newPath = dirPath + "\\" + pictures[i].EName;

                try
                {
                    //
                    if (File.Exists(pictures[i].EPath))
                        File.Move(pictures[i].EPath, newPath);
                    count++;
                }
                catch (Exception)
                {
                }

            }

            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static string CreateCategoryFolder(string path, DateTime date)
        {
            date = date.IsValid() ? date : DateTime.Now;

            var yearPath = path + "\\" + date.Year;
            var monthPath = yearPath + "\\" + date.ToString("MM");

            if (!System.IO.Directory.Exists(yearPath))
            {
                System.IO.Directory.CreateDirectory(yearPath);
            }

            if (!System.IO.Directory.Exists(monthPath))
            {
                System.IO.Directory.CreateDirectory(monthPath);
            }

            return monthPath;
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="filePath"></param>
        public static int DeletePictures(List<PictureModel> pictures)
        {
            var count = 0;

            if (pictures == null || !pictures.Any()) return count;

            for (var i = 0; i < pictures.Count; i++)
            {
                try
                {
                    //先删主体
                    if (File.Exists(pictures[i].EPath))
                        File.Delete(pictures[i].EPath);

                    //再删快照
                    if (File.Exists(pictures[i].ESnapshotPath))
                        File.Delete(pictures[i].ESnapshotPath);

                    count++;
                }
                catch (Exception)
                {
                }

            }

            return count;
        }

        /// <summary>
        /// 获取所有的图片信息
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static List<PictureModel> GetPictureList(string directory)
        {
            var list = new List<PictureModel>();

            var files = GetFiles(directory);

            for (var i = 0; i < files.Count; i++)
            {
                var picture = GetPicture(files[i]);

                list.Add(picture);
            }

            return list;

        }

        /// <summary>
        /// 获取图片信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private static PictureModel GetPicture(FileInfo info)
        {

            var picture = new PictureModel();

            picture.EDescription = string.Empty;
            picture.ESize = Math.Ceiling(info.Length / 1024.0);
            picture.EName = info.Name;
            picture.EPath = info.FullName;
            picture.EId = GUIDHelper.GetGuid();

            FillPictureInfo(picture);

            picture.ETakeTime = !picture.ETakeTime.IsValid() ? info.LastWriteTime : picture.ETakeTime;

            return picture;
        }

        /// <summary>
        /// 日期格式转化
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private static DateTime ParseDatetime(string time)
        {
            return DateTime.ParseExact(time.Replace("\0", ""), "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 获取所有的文件
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        private static List<FileInfo> GetFiles(string directory, List<FileInfo> list = null)
        {
            list = list ?? new List<FileInfo>();

            var dirs = System.IO.Directory.GetDirectories(directory).ToList();
            var dirInfo = new DirectoryInfo(directory);
            var files = dirInfo.GetFiles();

            if (files.Length == 0 && dirs.Count == 0) return list;

            list.AddRange(files.Where(x => IncludeFiles.Contains(x.Extension.ToLower())));

            dirs.ForEach(x => GetFiles(x, list));

            return list;
        }

        #endregion

        #region 私有方法
        #endregion

        #region 静态方法		
        #endregion
    }
}
