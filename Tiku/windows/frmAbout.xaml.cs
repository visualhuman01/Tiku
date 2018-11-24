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
    /// frmAbout.xaml 的交互逻辑
    /// </summary>
    public partial class frmAbout : Window
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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
                btn_pre.Content = data["pre"].ToString();
                btn_pre.Tag = "http://wpa.qq.com/msgrd?v=3&uin="+ data["pre"].ToString() + "&site=qq&menu=yes";
                btn_after.Content = data["after"].ToString();
                btn_after.Tag = "http://wpa.qq.com/msgrd?v=3&uin=" + data["pre"].ToString() + "&site=qq&menu=yes";
                txt_record.Text = data["record"].ToString();
                txtTel.Text = data["tel"].ToString();
                //btn_tel.Tag = "http://wpa.qq.com/msgrd?v=3&uin=" + data["pre"].ToString() + "&site=qq&menu=yes";
                btnAndroid.Tag = data["android"].ToString();
                btnIOS.Tag = data["ios"].ToString();
                btnWeb.Tag = data["url"].ToString();
            }
            else if (b == null)
            {
                frmMain.ShowLogin(callBack);
            }
        }
        private void callBack(dynamic param)
        {
            init();
        }
        private void Link_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string url = btn.Tag.ToString();
            System.Diagnostics.Process.Start(url);
        }

        private void btn_pre_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string url = btn.Tag.ToString();
            System.Diagnostics.Process.Start(url);
        }

        private void btn_after_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string url = btn.Tag.ToString();
            System.Diagnostics.Process.Start(url);
        }

        private void btn_tel_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string url = btn.Tag.ToString();
            System.Diagnostics.Process.Start(url);
        }
    }
}
