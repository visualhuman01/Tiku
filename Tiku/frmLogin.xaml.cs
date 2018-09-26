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
    public partial class frmLogin : Window
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (gPwd.Visibility == Visibility.Visible)
            {
                login(txtPhone.Text, txtPwd.Text, null, null);
            }
            else
            {
                login(txtPhone.Text, null, txtCode.Text, null);
            }
        }
        private void login(string phone, string pwd, string code, string token)
        {
            login_param lp = new login_param
            {
                phone = phone,
                password = pwd,
                code = code,
                token = token,
            };
            var re = HttpHelper.Post(Config.Server + "/login/login", lp);
            if (re != null && HttpHelper.IsOk(re) == true)
            {
                Config.Phone = lp.phone;
                Config.Token = re["data"]["token"].ToString();
                Config.Save();
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(re["msg"].ToString());
            }
        }

        private void btnPwdCode_Click(object sender, RoutedEventArgs e)
        {
            if (gPwd.Visibility == Visibility.Visible)
            {
                gPwd.Visibility = Visibility.Hidden;
                gCode.Visibility = Visibility.Visible;
            }
            else
            {
                gPwd.Visibility = Visibility.Visible;
                gCode.Visibility = Visibility.Hidden;
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var param = new { phone = txtPhone.Text };
            var re = HttpHelper.Post(Config.Server + "/index/sms", param);
            if (re != null && HttpHelper.IsOk(re) == true)
            {
                btnSend.IsEnabled = false;
                btnSend.Content = "60";
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
            }
            else
            {
                MessageBox.Show(re["msg"].ToString());
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
    }
}
