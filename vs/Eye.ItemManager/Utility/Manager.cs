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
        public static int ReducePictures(List<Picture> pictures, string targetPath, int width)
        {
            var count = 0;

            if (pictures == null || !pictures.Any()) return count;

            for (var i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];

                var target = targetPath + "\\" + picture.Name;

                var success = PictureHandler.GetReducedImage(picture.Path, width, target);

                if (success)
                {
                    count++;
                    picture.SnapshotPath = target;
                }
            }

            return count;
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        /// <param name="picture"></param>
        public static void FillPictureInfo(Picture picture)
        {
            var info = PictureHandler.GetInnerInfo(picture.Path);

            picture.Tags1 = info.Tag1;
            picture.Tags2 = info.Tag2;
            picture.Description = info.Description;
            picture.Width = int.Parse(info.Width);
            picture.Height = int.Parse(info.Height);

            DateTime time;
            var s = DateTime.TryParse(info.TakeTime, out time);
            if (!s)
            {
                s = DateTime.TryParse(info.ModifyTime, out time);
            }
            picture.TakeTime = time;
        }

        /// <summary>
        /// 将图片转移
        /// </summary>
        /// <param name="pictures"></param>
        /// <returns></returns>
        public static int MovePictures(List<Picture> pictures, string path)
        {
            var count = 0;

            if (pictures == null || !pictures.Any()) return count;

            for (var i = 0; i < pictures.Count; i++)
            {
                var newPath = path + "\\" + pictures[i].Name;

                try
                {
                    //先删主体
                    if (File.Exists(pictures[i].Path))
                        File.Move(pictures[i].Path, newPath);
                    count++;
                }
                catch (Exception)
                {
                }

            }

            return count;
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="filePath"></param>
        public static int DeletePictures(List<Picture> pictures)
        {
            var count = 0;

            if (pictures == null || !pictures.Any()) return count;

            for (var i = 0; i < pictures.Count; i++)
            {
                try
                {
                    //先删主体
                    if (File.Exists(pictures[i].Path))
                        File.Delete(pictures[i].Path);

                    //再删快照
                    if (File.Exists(pictures[i].SnapshotPath))
                        File.Delete(pictures[i].SnapshotPath);

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
        public static List<Picture> GetPictureList(string directory)
        {
            var list = new List<Picture>();

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
        private static Picture GetPicture(FileInfo info)
        {

            var picture = new Picture();

            picture.Description = string.Empty;
            picture.Size = Math.Ceiling(info.Length / 1024.0);
            picture.Name = info.Name;
            picture.Path = info.FullName;
            picture.Id = GUIDHelper.GetGuid();

            FillPictureInfo(picture);

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
