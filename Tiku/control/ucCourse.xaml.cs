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
        public string Gid
        {
            get
            {
                return _gid;
            }
        }

        public ucCourse()
        {
            InitializeComponent();
        }
        public delegate void Activate_Delegate(object sender);
        public event Activate_Delegate Activate_Event;
        public delegate void Tryout_Delegate(object sender);
        public event Tryout_Delegate Tryout_Event;
        public ucCourse(string gid, string goods_name, string price, string sale)
        {
            InitializeComponent();
            _gid = gid;
            txtName.Text = goods_name;
            txtPrice.Text = price;
            txtSale.Text = sale;
        }

        private void btnActivate_Click(object sender, RoutedEventArgs e)
        {
            if (Activate_Event != null)
            {
                Activate_Event(this);
            }
        }

        private void btnTryout_Click(object sender, RoutedEventArgs e)
        {
            if (Tryout_Event != null)
            {
                Tryout_Event(this);
            }
        }
    }
}
