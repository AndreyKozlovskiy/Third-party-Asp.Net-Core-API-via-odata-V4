using System.IO;
using System.Net;

namespace CRM_Core.Response
{
    public static class RequestCreation
    {
        public static HttpWebRequest CreateRequest(string url, string method, string contentType, bool isKeepAlive, string requestData, CookieContainer cookies)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (contentType != null)
                request.ContentType = contentType;
            request.Method = method;
            request.KeepAlive = isKeepAlive;
            if (!string.IsNullOrEmpty(requestData))
            {
                using (var requestStream = request.GetRequestStream())
                {
                    using (var writer = new StreamWriter(requestStream))
                    {
                        writer.Write(requestData);
                    }
                }
            }
            request.CookieContainer = cookies;
            return request;
        }
    }
}
