using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tiku.common
{
    public class HttpHelper
    {
        public static dynamic Post(string url, dynamic param)
        {
            var json_str = JsonConvert.SerializeObject(param);
            var json_data = Encoding.UTF8.GetBytes(json_str);

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
        public static bool? IsOk(dynamic res)
        {
            if(res == null)
            {
                MessageBox.Show("无法连接服务器");
                return false;
            }else
            {
                if (res["code"].ToString() == "1")
                    return true;
                else if (res["code"].ToString() == "-1")
                {
                    return null;
                }
                else
                {
                    MessageBox.Show(res["msg"].ToString());
                    return false;
                }
            }
        }
        public static bool CompareArr(string[] arr1, string[] arr2)

        {

            var q = from a in arr1 join b in arr2 on a equals b select a;

            bool flag = arr1.Length == arr2.Length && q.Count() == arr1.Length;

            return flag;//内容相同返回true,反之返回false。

        }
    }
}
