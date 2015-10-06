using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FlipdishPosPollApi.Entities;
using Newtonsoft.Json;

namespace FlipdishPosPollApi
{
    public static class HttpHelper
    {
        public static string HttpGet(string uri, int timeoutInMs = 6000)
        {
            WebRequest req = WebRequest.Create(uri);
            req.Timeout = timeoutInMs;

            //ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;

            WebResponse resp = req.GetResponse();
            var sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        public static string HttpPost(string uri, Dictionary<string, string> parameters, List<KeyValuePair<string, string>> sensitiveStrings = null)
        {
            var asList = parameters.ToList();

            return HttpPost(uri, asList, sensitiveStrings);
        }

        public static string HttpPost(string uri, List<KeyValuePair<string, string>> parameters, List<KeyValuePair<string, string>> sensitiveStrings = null)
        {
            var sb = new StringBuilder();

            foreach (var kvp in parameters)
            {
                sb.Append(string.Format("{0}={1}&", kvp.Key, kvp.Value));
            }

            string s = sb.ToString().Trim().TrimEnd('&');

            string result = HttpPost(uri, s);

            return result;
        }

        public static ApiResult HttpPostApiResult(string uri, string parameters)
        {
            string s = HttpPost(uri, parameters);
            ApiResult apiResult;
            try
            {
                apiResult = JsonConvert.DeserializeObject<ApiResult>(s);
            }
            catch (Exception ex)
            {
                apiResult = new ApiResult { Success = false, StackTrace = ex.ToString() };
            }

            return apiResult;
        }

        public static string HttpPost(string uri, string parameters)
        {
            WebRequest req = WebRequest.Create(uri);

            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;

            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(parameters);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();

            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            var sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        public static Dictionary<string, string> ParseAmpersandSeparatedPairsToLowerCaseKeys(string ampersandSeparatedPairs)
        {
            var result = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(ampersandSeparatedPairs))
            {
                string[] splitByAmpersand = ampersandSeparatedPairs.Split('&');

                if (splitByAmpersand.Length > 0)
                {
                    foreach (var pairString in splitByAmpersand)
                    {
                        var indexOfEqualsSign = pairString.IndexOf('=');

                        if (indexOfEqualsSign == -1) continue;

                        var key = pairString.Substring(0, indexOfEqualsSign);
                        var val = pairString.Substring(indexOfEqualsSign + 1);
                        result[key.ToLower().Trim()] = val.Trim();
                    }

                }
            }

            return result;
        }

        private static bool ValidateRemoteCertificate(
                object sender,
                X509Certificate certificate,
                X509Chain chain,
                SslPolicyErrors policyErrors)
        {
            return true;
        }

    }
}
