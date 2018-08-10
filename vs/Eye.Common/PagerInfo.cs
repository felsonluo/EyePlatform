/****************************************************
版权所有:美记软件（上海）有限公司
创 建 人:小莫
创建时间:2018-08-10 10:22:59
CLR 版本:4.0.30319.42000
文件描述:
* **************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eye.Common
{
    /// <summary>
    /// 创 建 者:小莫
    /// 创建日期:2018-08-10 10:22:59
    /// 描   述:功能描述
	///
    /// </summary>
    public class PagerInfo
    {

        #region 全局变量		
        /// <summary>
        /// 当前分页
        /// </summary>
        public int CurrentPageIndex { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页的条数
        /// </summary>
        public int RecordCount { get; set; }
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
