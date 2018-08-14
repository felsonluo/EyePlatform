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
using Eye.BusinessService;
using System.Collections;
using PhotoManager;

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


        private static bool DeleteAfterCopy
        {
            get
            {
                var setting = ConfigurationManager.AppSettings["deleteAfterCopy"];

                return string.IsNullOrWhiteSpace(setting) ? false : bool.Parse(setting);
            }
        }


        public static int BatchCount
        {
            get
            {
                var setting = ConfigurationManager.AppSettings["BatchCount"];

                return string.IsNullOrWhiteSpace(setting) ? 200 : int.Parse(setting);
            }
        }


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


        /// <summary>
        /// 用一个hash表来记录已经处理的记录
        /// </summary>
        public static Hashtable Cache = Hashtable.Synchronized(new Hashtable());
        #endregion

        #region 构造方法		
        #endregion

        #region 公开方法

        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="pictures"></param>
        /// <returns></returns>
        public static int ReducePictures(List<PictureModel> pictures, int width)
        {
            var count = 0;

            if (pictures == null || !pictures.Any()) return count;

            for (var i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];

                var targetPath = new FileInfo(picture.EPath).DirectoryName + "\\snapshot";

                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                var target = targetPath + "\\" + "snapshot_" + picture.EName;

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
        public static bool FillPictureInfo(PictureModel picture)
        {
            var info = PictureHandler.GetInnerInfo(picture.EPath);

            if (info == null) return false;

            picture.ETags1 = info.Tag1;
            picture.ETags2 = info.Tag2;
            picture.EDescription = info.Description;
            picture.EId = info.Author;

            var img = Image.FromFile(picture.EPath);
            picture.EWidth = img.Width;
            picture.EHeight = img.Height;
            img.Dispose();

            DateTime time;
            var s = DateTime.TryParseExact(info.TakeTime,
                    "yyyy:MM:dd HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out time);

            picture.ETakeTime = time;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool MovePicture(PictureModel picture, string path)
        {

            var dirPath = CreateCategoryFolder(path, picture.ETakeTime);

            var newPath = dirPath + "\\" + picture.EName;

            try
            {
                if (File.Exists(picture.EPath))
                {
                    if (!File.Exists(newPath))
                    {
                        File.Copy(picture.EPath, newPath, false);
                    }

                    if (DeleteAfterCopy)
                    {
                        if (File.GetAttributes(picture.EPath).ToString().IndexOf("ReadOnly") != -1)
                        {
                            File.SetAttributes(picture.EPath, FileAttributes.Normal);
                        }
                        File.Delete(picture.EPath);
                    }


                    picture.EPath = newPath;

                    picture.ERow.Cells[nameof(picture.EPath)].Value = newPath;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
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
                var result = MovePicture(pictures[i], path);

                if (result) count++;
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
        public static List<PictureModel> GetPictureList(LoadFilter filter)
        {
            var result = new List<PictureModel>();

            //先获取所有的
            var items = new ItemBusiness().GetItems();
            //获取所有的分类
            var categories = new CategoryBusiness().GetCategories();

            //获取所有的图片
            var picturesInDatabase = new PictureBusiness().GetPictures();
            //文件夹里面的
            var picturesInFolder = filter.FromFolder ? GetPictureFromFolder(filter) : new List<PictureModel>();

            //已入库的
            var picturesSaved = new List<PictureModel>();
            //未入库的
            var picturesDraft = new List<PictureModel>();
            //分别处理
            picturesInFolder.ForEach(x => { if (picturesInDatabase.Exists(y => y.EId == x.EId)) { picturesSaved.Add(x); } else { picturesDraft.Add(x); } });

            //包含文件夹
            if (filter.FromFolder)
            {
                if (filter.IncludeSaved)
                    result.AddRange(picturesSaved);
                if (filter.IncludeDraft)
                    result.AddRange(picturesDraft);
            }
            //包含数据库
            if (filter.FromDatabase)
            {
                picturesInDatabase.ForEach(x => { if (!result.Exists(y => y.EId == x.EId)) { result.Add(x); } });
            }

            return result;
        }

        /// <summary>
        /// 从文件夹获取照片
        /// </summary>
        /// <returns></returns>
        private static List<PictureModel> GetPictureFromFolder(LoadFilter filter)
        {
            var list = new List<PictureModel>();

            var files = GetFiles(filter.Folder);

            for (var i = 0; i < files.Count; i++)
            {
                var picture = GetPicture(files[i]);

                list.Add(picture);

                if (list.Count == filter.Page) return list;
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

            var result = FillPictureInfo(picture);

            if (!result) File.Delete(info.FullName);

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

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="pictures"></param>
        /// <returns></returns>
        public static bool SavePictures(List<PictureModel> pictures)
        {
            var noSnapshotPictures = pictures.Where(x => string.IsNullOrWhiteSpace(x.ESnapshotPath)).ToList();

            if (noSnapshotPictures.Any())
            {
                //给没有创建快照的图片创建快照
                Manager.ReducePictures(noSnapshotPictures, 160);
            }

            var result = new PictureBusiness().SetPictures(pictures);

            return result;
        }

        #endregion

        #region 私有方法
        #endregion

        #region 静态方法		
        #endregion
    }
}
