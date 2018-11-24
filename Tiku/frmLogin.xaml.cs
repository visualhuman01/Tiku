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
            Config.Token = "";
            Config.Save();
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
            var lp = new 
            {
                phone = phone,
                password = pwd,
                code = code,
                token = token,
            };
            var re = HttpHelper.Post(Config.Server + "/login/login", lp);
            var b = HttpHelper.IsOk(re);
            if (b == true)
            {
                Config.Phone = lp.phone;
                Config.Token = re["data"]["token"].ToString();
                Config.Save();
                this.DialogResult = true;
                this.Close();
            }
        }

        private void btnPwdCode_Click(object sender, RoutedEventArgs e)
        {
            if (gPwd.Visibility == Visibility.Visible)
            {
                this.Title = "手机验证码登录";
                btnPwdCode.Content = "账号密码登录";
                gPwd.Visibility = Visibility.Hidden;
                gCode.Visibility = Visibility.Visible;
                labPwd.Text = "验证码";
            }
            else
            {
                this.Title = "账号密码登录";
                btnPwdCode.Content = "手机验证码登录";
                gPwd.Visibility = Visibility.Visible;
                gCode.Visibility = Visibility.Hidden;
                labPwd.Text = "密码";
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
            this.Close();
            frmMain.ShowSetpass(1);
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmMain.ShowRegister();
        }
    }
}
