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

namespace Tiku.control
{
    /// <summary>
    /// ucCourse.xaml 的交互逻辑
    /// </summary>
    public partial class ucCourse : UserControl
    {
        private string _gid;

        public ucCourse()
        {
            InitializeComponent();
        }
        public ucCourse(string gid, string goods_name,string price,string sale)
        {
            InitializeComponent();
            _gid = gid;
            txtName.Text = goods_name;
            txtPrice.Text = price;
            txtSale.Text = sale;
        }
    }
}
