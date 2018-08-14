/****************************************************
版权所有:美记软件（上海）有限公司
创 建 人:小莫
创建时间:2018-08-07 08:52:29
CLR 版本:4.0.30319.42000
文件描述:
* **************************************************/

using MetadataExtractor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eye.Common
{
    /// <summary>
    /// 创 建 者:小莫
    /// 创建日期:2018-08-07 08:52:29
    /// 描   述:功能描述
	///
    /// </summary>
    public class PictureHandler
    {

        public static bool ThumbnailCallback()
        {
            return false;
        }

        /// <summary>
        /// 按照固定宽度来缩放
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="targetFilePath"></param>
        /// <returns></returns>
        public static bool GetReducedImage(string sourceFilePath, int width, string targetFilePath)
        {
            try
            {

                var image = Image.FromFile(sourceFilePath);

                Image ReducedImage;

                var height = 0;

                if (image.Width > image.Height)
                {
                    height = Convert.ToInt32((image.Height * 1.0) / image.Width * width);
                }
                else
                {
                    height = width;
                    width = Convert.ToInt32(image.Width * 1.0 / image.Height * width);
                }

                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                ReducedImage = image.GetThumbnailImage(width, height, callb, IntPtr.Zero);

                ReducedImage.Save(@targetFilePath, ImageFormat.Jpeg);

                ReducedImage.Dispose();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>   
        /// 生成缩略图重载方法2，将缩略图文件保存到指定的路径   
        /// </summary>   
        /// <param name="width">缩略图的宽度</param>   
        /// <param name="height">缩略图的高度</param>   
        /// <param name="targetFilePath">缩略图保存的全文件名，(带路径)，参数格式：D:Images ilename.jpg</param>   
        /// <returns>成功返回true，否则返回false</returns>   
        public static bool GetReducedImage(string sourceFilePath, int width, int height, string targetFilePath)
        {
            try
            {

                var image = Image.FromFile(sourceFilePath);

                Image ReducedImage;

                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                ReducedImage = image.GetThumbnailImage(width, height, callb, IntPtr.Zero);
                ReducedImage.Save(@targetFilePath, ImageFormat.Jpeg);

                ReducedImage.Dispose();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>   
        /// 生成缩略图重载方法3，返回缩略图的Image对象   
        /// </summary>   
        /// <param name="Percent">缩略图的宽度百分比 如：需要百分之80，就填0.8</param>     
        /// <returns>缩略图的Image对象</returns>   
        public static Image GetReducedImage(string sourceFilePath, double Percent)
        {
            try
            {
                var image = Image.FromFile(sourceFilePath);

                Image ReducedImage;

                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                var width = Convert.ToInt32(image.Width * Percent);
                var height = Convert.ToInt32(image.Width * Percent);

                ReducedImage = image.GetThumbnailImage(width, height, callb, IntPtr.Zero);

                return ReducedImage;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>   
        /// 生成缩略图重载方法4，返回缩略图的Image对象   
        /// </summary>   
        /// <param name="Percent">缩略图的宽度百分比 如：需要百分之80，就填0.8</param>     
        /// <param name="targetFilePath">缩略图保存的全文件名，(带路径)，参数格式：D:Images ilename.jpg</param>   
        /// <returns>成功返回true,否则返回false</returns>   
        public static bool GetReducedImage(string sourceFilePath, double Percent, string targetFilePath)
        {
            try
            {
                var image = Image.FromFile(sourceFilePath);

                Image ReducedImage;

                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                var width = Convert.ToInt32(image.Width * Percent);
                var height = Convert.ToInt32(image.Width * Percent);

                ReducedImage = image.GetThumbnailImage(width, height, callb, IntPtr.Zero);

                ReducedImage.Save(@targetFilePath, ImageFormat.Jpeg);

                ReducedImage.Dispose();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 设置图片的信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetPictureInfo(int key, List<KeyValuePair<string, string>> pairs)
        {
            var count = 0;

            for (var i = 0; i < pairs.Count; i++)
            {
                var path = pairs[i].Key;
                var id = pairs[i].Value;

                var result = SetPictrueProperty(key, path, id);

                if (result) count++;
            }

            return count == pairs.Count;
        }

        private static void SetProperty(Image image, string value, int id, short type)
        {
            var content = Encoding.ASCII.GetBytes(value);
            PropertyItem pi = image.PropertyItems[0];
            pi.Id = id;
            pi.Type = type;
            pi.Value = content;
            pi.Len = pi.Value.Length;
            image.SetPropertyItem(pi);
        }


        /// <summary>
        /// 设置图片的Id 0x5034
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetPictrueProperty(int key, string path, string value)
        {
            try
            {
                var img = new Bitmap(path);

                SetProperty(img, value, PictruePropertyHexTable.Author, 2);


                //1.保存到另外一个文件
                var fileInfo = new FileInfo(path);
                var tempPath = fileInfo.DirectoryName + "\\" + GUIDHelper.GetGuid() + ".jpg";
                img.Save(tempPath);
                img.Dispose();

                //删除源文件
                fileInfo.Delete();

                File.Copy(tempPath, path, true);

                //将另外一个文件删除
                File.Delete(tempPath);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        /// <summary>
        /// 获取图片信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static PictureInnerInfo GetInnerInfo(string path)
        {

            try
            {
                var info = new PictureInnerInfo();

                var data = ImageMetadataReader.ReadMetadata(path);

                for (var i = 0; i < data.Count; i++)
                {
                    if (data[i].Tags == null || data[i].TagCount == 0) continue;

                    for (var j = 0; j < data[i].Tags.Count; j++)
                    {
                        var tag = data[i].Tags[j];

                        if (!tag.HasName) continue;

                        if (tag.Name == info.AuthorName)
                            info.Author = tag.Description?.Replace("\0x0001", "").Replace("\u0001", "").Trim().Substring(0, 32);
                        else if (tag.Name == info.Tag1Name)
                            info.Tag1 = tag.Description;
                        else if (tag.Name == info.Tag2Name)
                            info.Tag2 = tag.Description;
                        else if (tag.Name == info.DescriptionName)
                            info.Description = tag.Description;
                        else if (tag.Name == info.TakeTimeName)
                            info.TakeTime = tag.Description;
                    }
                }

                return info;
            }
            catch (Exception)
            {

            }

            return null;
        }


        public class PictureInnerInfo
        {
            public string AuthorName = "Artist";
            public string Tag1Name = "Windows XP Keywords";
            public string Tag2Name = "Windows XP Title";
            public string DescriptionName = "Windows XP Comment";
            public string HeightName = "Image Height";
            public string WidthName = "Image Width";
            public string ModifyTimeName = "File Modified Date";
            public string TakeTimeName = "Date/Time Original";

            public string Author { get; set; }
            public string Tag1 { get; set; }
            public string Tag2 { get; set; }
            public string Description { get; set; }
            public string Height { get; set; }
            public string Width { get; set; }
            public string ModifyTime { get; set; }
            public string TakeTime { get; set; }
        }

        /// <summary>
        ///图片属性对应的十六进制
        /// </summary>
        public class PictruePropertyHexTable
        {
            /// <summary>
            /// 作者
            /// </summary>
            public static readonly int Author = 0x13B;
        }

    }
}
