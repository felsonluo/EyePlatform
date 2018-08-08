using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Eye.Common
{
    public class ApiResponseHelper
    {
        /// <summary>
        /// 转换为json对象
        /// </summary>
        /// <param name="obj">需要转换的对象</param>
        /// <param name="success">是否成功</param>
        /// <param name="message">需要返回的消息提示，成功不返回</param>
        /// <param name="encode">返回的json字符串是否编码</param>
        /// <returns></returns>
        public static HttpResponseMessage ToJson(Object obj)
        {
            
            var str = JsonConvert.SerializeObject(obj);

            var result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }
    }
}
