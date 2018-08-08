/****************************************************
版权所有:美记软件（上海）有限公司
创 建 人:小莫
创建时间:2018-08-06 14:22:46
CLR 版本:4.0.30319.42000
文件描述:
* **************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eye.DataModel.DataModel
{
    /// <summary>
    /// 创 建 者:小莫
    /// 创建日期:2018-08-06 14:22:46
    /// 描   述:功能描述
	///
    /// </summary>
    public class Picture
    {

        #region 全局变量
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 压缩后图片的路径
        /// </summary>
        public string SnapshotPath { get; set; }

        /// <summary>
        /// 拍摄日期
        /// </summary>
        public DateTime TakeTime { get; set; }


        /// <summary>
        /// 拍摄者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 拍摄地点
        /// </summary>
        public string TakeLocation { get; set; }

        /// <summary>
        /// 图片大小
        /// </summary>
        public double Size { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; set; }


        /// <summary>
        /// 标签1（里面有哪些人物）
        /// </summary>
        public string Tags1 { get; set; }


        /// <summary>
        /// 标签2（属于哪个相册）
        /// </summary>
        public string Tags2 { get; set; }


        /// <summary>
        /// 照片描述
        /// </summary>
        public string Description { get; set; }


        public DataGridViewRow Row { get; set; }



        #endregion

        #region 构造方法		
        #endregion

        #region 公开方法		
        #endregion

        #region 私有方法
        #endregion

        #region 静态方法		
        #endregion
    }
}
