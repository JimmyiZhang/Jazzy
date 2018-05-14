using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text.RegularExpressions;

namespace Jazzy.Library.Utility
{
    public class HttpUtility
    {
        /// <summary>
        /// 获取本地IP地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetAddress(HttpContext context)
        {
            var request = context.Request;
            string forwarded = request.Headers["X-Forwarded-For"].FirstOrDefault();

            string result = string.Empty;
            if (forwarded.IsNotEmpty())
            {
                // 可能有代理 
                // 没有[.]肯定是非IPv4格式 
                if (result.IndexOf(".") == -1)
                    result = null;
                else
                {
                    if (result.IndexOf(",") != -1)
                    {
                        // 有[,]估计多个代理。取第一个不是内网的IP
                        result = result.Replace(" ", "").Replace("'", "");
                        string[] temparyip = result.Split(",;".ToCharArray());
                        for (int i = 0; i < temparyip.Length; i++)
                        {
                            // 找到不是内网的地址 
                            if (IsIPAddress(temparyip[i])
                                && temparyip[i].Substring(0, 3) != "10."
                                && temparyip[i].Substring(0, 7) != "192.168"
                                && temparyip[i].Substring(0, 7) != "172.16.")
                            {
                                return temparyip[i];
                            }
                        }
                    }
                    else if (IsIPAddress(result))
                        //代理即是IP格式 
                        return result;
                    else
                        //代理中的内容 非IP，取IP 
                        result = null;
                }
            }

            if (result.IsNullOrEmpty())
                result = request.Headers["REMOTE_ADDR"];

            if (result.IsNullOrEmpty())
                result = context.Connection.RemoteIpAddress.ToString();
            return result;
        }

        /// <summary>
        /// 判断是否是IP地址格式 0.0.0.0
        /// </summary>
        /// <param name="address">待判断的IP地址</param>
        /// <returns>true or false</returns>
        private static bool IsIPAddress(string address)
        {
            if (address == null || address == string.Empty || address.Length < 7 || address.Length > 15) return false;
            string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";
            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(address);
        }
    }
}
