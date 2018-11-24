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
using System.Windows.Shapes;
using Tiku.common;
using Tiku.model;

namespace Tiku.windows
{
    /// <summary>
    /// frmActive.xaml 的交互逻辑
    /// </summary>
    public partial class frmActive : Window
    {
        private string _id;
        private string _pre;
        public frmActive(string id, string name)
        {
            InitializeComponent();
            _id = id;
            txtName.Text = "当前课程：" + name;
            init();
        }

        private void init()
        {
            var param = new
            {
                token = Config.Token,
                phone = Config.Phone,
            };
            var re = HttpHelper.Post(Config.Server + "/index/custom", param);
            var b = HttpHelper.IsOk(re);
            if (b == true)
            {
                var data = re["data"];
                _pre = data["pre"].ToString();
                labPre.Text = "支付后联系微信或者QQ：" + _pre + "领取激活码";
                string url = data["url"].ToString() + data["alipay"].ToString();
                imgZFB.Source = new BitmapImage(new Uri(url, UriKind.RelativeOrAbsolute));
                imgZFB.Stretch = Stretch.Fill;
                url = data["url"].ToString() + data["wechat"].ToString();
                imgWX.Source = new BitmapImage(new Uri(url, UriKind.RelativeOrAbsolute));
                imgWX.Stretch = Stretch.Fill;
            }
        }

        private void btnActive_Click(object sender, RoutedEventArgs e)
        {
            var param = new
            {
                phone = Config.Phone,
                token = Config.Token,
                id = _id,
                code = txtCode.Text,
            };
            var re = HttpHelper.Post(Config.Server + "/user/code", param);
            var b = HttpHelper.IsOk(re);
            if (b == true)
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void imgQQ_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string url = "http://wpa.qq.com/msgrd?v=3&uin=" + _pre + "&site=qq&menu=yes";
            System.Diagnostics.Process.Start(url);
        }
    }
}
