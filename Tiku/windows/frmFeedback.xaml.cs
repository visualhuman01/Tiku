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
    /// frmFeedback.xaml 的交互逻辑
    /// </summary>
    public partial class frmFeedback : Window
    {
        public frmFeedback()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var param = new
            {
                phone = Config.Phone,
                token = Config.Token,
                tel = txtTel.Text,
                content = txtContent.Text,
                type = "option",
            };
            var re = HttpHelper.Post(Config.Server + "/user/opinion", param);
            if(re!=null)
            {
                var data = re["msg"];
                MessageBox.Show(data.ToString());
                if (HttpHelper.IsOk(re))
                {
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
