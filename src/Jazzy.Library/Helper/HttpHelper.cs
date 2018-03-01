using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Text.RegularExpressions;

namespace Jazzy.Library
{
    /// <summary>
    /// Http帮助类
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// 获得http请求数据
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="method">请求方式</param>
        /// <param name="postData">发送数据</param>
        /// <param name="encoding">编码</param>
        /// <param name="timeout">超时值</param>
        /// <returns></returns>
        public static string GetRequestData(string url, string postData, Encoding encoding = null, string method = "GET", int timeout = 3600)
        {
            System.Net.ServicePointManager.Expect100Continue = false;

            if (!url.StartsWith("http://") && !url.StartsWith("https://")) url = "http://" + url;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "text/html,application/xhtml+xml,application/xm,*/*";
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            request.KeepAlive = true;
            request.Timeout = timeout;
            request.Method = string.IsNullOrEmpty(method) ? "GET" : method.ToUpper();
            // request.AllowAutoRedirect = true;
            // request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            request.ContentType = request.Method == "POST" ? "application/x-www-form-urlencoded" : "text/html";

            try
            {
                if (!string.IsNullOrEmpty(postData) && request.Method == "POST")
                {
                    Encoding reqEncoding = (encoding == null ? Encoding.Default : encoding);
                    byte[] buffer = reqEncoding.GetBytes(postData);
                    request.ContentLength = buffer.Length;

                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                    request.GetRequestStream().Flush();
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response == null || response.StatusCode != HttpStatusCode.OK) return string.Empty;
                    if (encoding == null)
                    {
                        string cType = response.ContentType.ToLower();
                        Match charSetMatch = Regex.Match(cType, "(?<=charset=)([^<]*)*", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                        string webCharSet = charSetMatch.ToString();
                        encoding = string.IsNullOrEmpty(webCharSet) ? Encoding.Default :
                            Encoding.GetEncoding(webCharSet);
                    }

                    StreamReader reader = null;
                    if (response.ContentEncoding != null && response.ContentEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase))
                    {
                        using (reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), encoding))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                    else
                    {
                        using (reader = new StreamReader(response.GetResponseStream(), encoding))
                        {
                            try
                            {
                                return reader.ReadToEnd();
                            }
                            catch
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得http请求状态
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="method">请求方式</param>
        /// <param name="postData">发送数据</param>
        /// <param name="encoding">编码</param>
        /// <param name="timeout">超时值</param>
        /// <returns></returns>
        public static HttpStatusCode GetRequestStatus(string url, string postData, Encoding encoding = null, string method = "GET", int timeout = 3600)
        {
            if (!url.StartsWith("http://") && !url.StartsWith("https://")) url = "http://" + url;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "text/html, application/xhtml+xml, */*,zh-CN";
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            request.KeepAlive = true;
            request.AllowAutoRedirect = true;
            request.Timeout = timeout;
            request.Method = string.IsNullOrEmpty(method) ? "GET" : method.ToUpper();
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            request.ContentType = request.Method == "POST" ? "application/x-www-form-urlencoded" : "text/html";

            try
            {
                if (!string.IsNullOrEmpty(postData) && request.Method == "POST")
                {
                    Encoding reqEncoding = encoding == null ? Encoding.Default : encoding;
                    byte[] buffer = reqEncoding.GetBytes(postData);
                    request.ContentLength = buffer.Length;
                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response == null) return HttpStatusCode.BadRequest;
                    return response.StatusCode;
                }
            }
            catch
            {
                return HttpStatusCode.BadRequest;
            }
        }
    }
}
