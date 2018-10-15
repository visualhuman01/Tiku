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
                txt_pre.Text = data["pre"].ToString();
                txt_after.Text = data["after"].ToString();
                txt_record.Text = data["record"].ToString();
                txt_tel.Text = data["tel"].ToString();
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
    }
}
