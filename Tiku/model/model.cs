using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiku.model
{
    public class login_param
    {
        public string phone { get; set; }
        public string code { get; set; }
        public string password { get; set; }
        public string token { get; set; }
    }
    public class login_res
    {
        public string token { get; set; }
    }
}
