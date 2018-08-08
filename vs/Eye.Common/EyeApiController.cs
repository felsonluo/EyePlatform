/****************************************************
版权所有:美记软件（上海）有限公司
创 建 人:小莫
创建时间:2018-08-08 15:00:01
CLR 版本:4.0.30319.42000
文件描述:
* **************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Eye.Common
{
    /// <summary>
    /// 创 建 者:小莫
    /// 创建日期:2018-08-08 15:00:01
    /// 描   述:功能描述
	///
    /// </summary>
    public class EyeApiController : ApiController
    {

        #region 全局变量		
        #endregion

        #region 构造方法		
        #endregion

        #region 公开方法		

        public HttpResponseMessage ToJson(object obj)
        {
            return ApiResponseHelper.ToJson(obj);
        }

        #endregion

        #region 私有方法
        #endregion

        #region 静态方法		
        #endregion
    }
}
