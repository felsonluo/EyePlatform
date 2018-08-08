/****************************************************
版权所有:美记软件（上海）有限公司
创 建 人:小莫
创建时间:2018-08-06 15:06:58
CLR 版本:4.0.30319.42000
文件描述:
* **************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eye.PhotoManager.Utility
{
    /// <summary>
    /// 创 建 者:小莫
    /// 创建日期:2018-08-06 15:06:58
    /// 描   述:功能描述
	///
    /// </summary>
    public class GUIDHelper
    {

        #region 全局变量	
        #endregion

        #region 构造方法		
        #endregion

        #region 公开方法		



        /// <summary>
        /// 获取guid
        /// </summary>
        /// <returns></returns>
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Replace("{", "").Replace("}", "");
        }

        #endregion

        #region 私有方法
        #endregion

        #region 静态方法		
        #endregion
    }
}
