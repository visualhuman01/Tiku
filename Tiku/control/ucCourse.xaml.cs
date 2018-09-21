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
        public delegate void Click_Delegate(object sender);
        public event Click_Delegate Click_Event;
        private bool _is_sale = false;
        private bool _is_act = false;
        public ucCourse(string gid, string goods_name, string price, string sale, bool is_sale, bool is_act)
        {
            InitializeComponent();
            _is_act = is_act;
            _is_sale = is_sale;
            _gid = gid;
            txtName.Text = goods_name;
            txtPrice.Text = "原价：￥" + price;
            if (_is_sale)
            {
                txtSale.Text = "优惠价：￥" + sale;
            }
            else
            {
                txtSale.Visibility = Visibility.Hidden;
            }
            if (_is_act)
            {
                btnActivate.Content = "已激活";
                btnActivate.IsEnabled = false;
                btnTryout.Visibility = Visibility.Hidden;
            }
            else
            {
                btnActivate.Content = "激活";
                btnActivate.IsEnabled = true;
                btnTryout.Visibility = Visibility.Visible;
            }
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

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Click_Event != null)
            {
                Click_Event(this);
            }
        }
    }
}
