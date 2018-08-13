/****************************************************
版权所有:美记软件（上海）有限公司
创 建 人:小莫
创建时间:2018-08-13 11:22:03
CLR 版本:4.0.30319.42000
文件描述:
* **************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhotoManager
{
    /// <summary>
    /// 创 建 者:小莫
    /// 创建日期:2018-08-13 11:22:03
    /// 描   述:功能描述
	///
    /// </summary>
    public class LoadFilter
    {

        #region 全局变量	
        /// <summary>
        /// 仅从文件夹
        /// </summary>
        public bool FromFolder { get; set; }
        /// <summary>
        /// 仅从数据库
        /// </summary>
        public bool FromDatabase { get; set; }
        /// <summary>
        /// 包含未入库
        /// </summary>
        public bool IncludeDraft { get; set; }
        /// <summary>
        /// 包含已入库
        /// </summary>
        public bool IncludeSaved { get; set; }

        /// <summary>
        /// 照片路径
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        /// 每页处理的数
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }
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
