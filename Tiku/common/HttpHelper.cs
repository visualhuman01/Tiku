using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tiku.common
{
    public class HttpHelper
    {
        public static dynamic Post(string url, dynamic param)
        {
            var json_str = JsonConvert.SerializeObject(param);
            var json_data = Encoding.ASCII.GetBytes(json_str);

            Uri myuri = new Uri(url);
            WebRequest myreq = WebRequest.Create(myuri);
            myreq.Method = "POST";
            myreq.ContentType = "application/json";
            myreq.ContentLength = json_data.Length;

            dynamic json;
            try
            {
                using (Stream requestStream = myreq.GetRequestStream())
                {
                    requestStream.Write(json_data, 0, json_data.Length);
                    requestStream.Close();
                }
                WebResponse myres = myreq.GetResponse();
                StreamReader streamReader = new StreamReader(myres.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                json_str = streamReader.ReadToEnd();
                json = JsonConvert.DeserializeObject(json_str, typeof(object));
                streamReader.Close();
                myreq.Abort();
                myres.Close();
            }
            catch (Exception ex)
            {
                json = null;
            }

            return json;
        }
        public static bool IsOk(dynamic res)
        {
            if (res["code"].ToString() == "1")
                return true;
            else
                return false;
        }
    }
}
