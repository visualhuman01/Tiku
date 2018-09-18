using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tiku.common;
using Tiku.model;

namespace Tiku.control
{
    /// <summary>
    /// ucStudy.xaml 的交互逻辑
    /// </summary>
    public partial class ucStudy : UserControl
    {
        public ucStudy()
        {
            InitializeComponent();
            init();
        }
        public void init()
        {
            var param = new
            {
                phone = Config.Phone,
                token = Config.Token,
            };
            var re = HttpHelper.Post(Config.Server + "/record/study", param);
            if (re != null && HttpHelper.IsOk(re))
            {
                var data = re["data"];
                tbStudy.Data = data;
            }
            re = HttpHelper.Post(Config.Server + "/record/practice", param);
            if (re != null && HttpHelper.IsOk(re))
            {
                var data = re["data"];
                txt_all.Text = data["all"];
                txt_wrong.Text = data["wrong"];
                txt_done.Text = data["done"];
                txt_do.Text = data["do"];
                txt_right.Text = data["right"];
                txt_all_pre.Text = data["all_pre"];
                txt_right_pre.Text = data["right_pre"];
            }
        }
    }
}
