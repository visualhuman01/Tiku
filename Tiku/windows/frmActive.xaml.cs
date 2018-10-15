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
        public frmActive(string id)
        {
            InitializeComponent();
            _id = id;
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
    }
}
