﻿/****************************************************
版权所有:美记软件（上海）有限公司
创 建 人:小莫
创建时间:2018-08-06 14:30:57
CLR 版本:4.0.30319.42000
文件描述:
* **************************************************/

using Eye.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eye.DataModel.DataModel
{
    /// <summary>
    /// 创 建 者:小莫
    /// 创建日期:2018-08-06 14:30:57
    /// 描   述:功能描述
	///
    /// </summary>
    public class PersonModel : BaseModel
    {

        #region 全局变量

        /// <summary>
        /// 父Id
        /// </summary>
        public string EFatherId { get; set; }


        /// <summary>
        /// 母Id
        /// </summary>
        public string EMotherId { get; set; }


        /// <summary>
        /// 配偶Id
        /// </summary>
        public string ECoupleId { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int ESex { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime EBirthDay { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string EDescription { get; set; }
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
