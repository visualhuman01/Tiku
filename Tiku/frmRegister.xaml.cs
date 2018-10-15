using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Tiku
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class frmRegister : Window
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            register(txtPhone.Text, txtPwd.Text, txtCode.Text);
        }
        private void register(string phone, string pwd, string code)
        {
            var lp = new 
            {
                phone = phone,
                password = pwd,
                code = code,
            };
            var re = HttpHelper.Post(Config.Server + "/login/register", lp);
            var b = HttpHelper.IsOk(re);
            if (b == true)
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var param = new { phone = txtPhone.Text };
            var re = HttpHelper.Post(Config.Server + "/index/sms", param);
            var b = HttpHelper.IsOk(re);
            if (b == true)
            {
                btnSend.IsEnabled = false;
                btnSend.Content = "60";
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
            }
        }
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.btnSend.Dispatcher.Invoke(new Action(delegate
            {
                int i = int.Parse(btnSend.Content.ToString());
                i--;
                btnSend.Content = i;
                if (i <= 0)
                {
                    btnSend.Content = "重新发送";
                    btnSend.IsEnabled = true;
                    timer.Stop();
                }
            }));
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSetPass_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
