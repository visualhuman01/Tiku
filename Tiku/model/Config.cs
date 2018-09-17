using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiku.model
{
    public class Config
    {
        public static string Phone
        {
            get
            {
                return _this._phone;
            }
            set
            {
                _this._phone = value;
            }
        }
        public static string Token
        {
            get
            {
                return _this._token;
            }
            set
            {
                _this._token = value;
            }
        }
        public static string Server
        {
            get
            {
                return _this._server;
            }
        }
        private string _phone;
        private string _token;
        private string _server;
        private static Config _this = new Config();
        public Config()
        {
            _phone = ConfigurationManager.AppSettings["phone"];
            _token = ConfigurationManager.AppSettings["token"];
            _server = ConfigurationManager.AppSettings["server"];
        }
        public static void Save()
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["phone"].Value = _this._phone;
            cfa.AppSettings.Settings["token"].Value = _this._token;//re["data"]["token"].ToString();
            cfa.Save();
        }
    }
}
