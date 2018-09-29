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
using Tiku.common;
using Tiku.model;

namespace Tiku.page
{
    /// <summary>
    /// pageWrong.xaml 的交互逻辑
    /// </summary>
    public partial class pageWrong : Page
    {
        private frmMain _main = null;
        public pageWrong(frmMain main)
        {
            _main = main;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
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
            var re = HttpHelper.Post(Config.Server + "/record/wrong", param);
            if (re != null && HttpHelper.IsOk(re) == true)
            {
                var data = re["data"];
                tbWrong.Data = data;
            }
            else if (re != null && HttpHelper.IsOk(re) == null)
            {
                frmMain.ShowLogin(callBack);
            }
            else
            {
                //frmMain.ShowLogin(callBack);
                MessageBox.Show(re["msg"].ToString());
            }
        }
        private void callBack(dynamic param)
        {
            init();
        }
        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            List<dynamic> data = new List<dynamic>();
            foreach (var d in tbWrong.Data)
            {
                data.Add(d);
            }
            _main.SwitchPage(E_Page_Type.WrongToPractice, data, E_Page_Type.Wrong);
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var items = tbWrong.SelectItems;
            if (items.Count == 0)
            {
                MessageBox.Show("请先进行选择");
                return;
            }
            List<dynamic> data = new List<dynamic>();
            foreach (var d in items)
            {
                data.Add(d.Data);
            }
            _main.SwitchPage(E_Page_Type.WrongToPractice, data, E_Page_Type.Wrong);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var items = tbWrong.SelectItems;
            if (items.Count == 0)
            {
                MessageBox.Show("请先进行选择");
                return;
            }
            List<string> ids = new List<string>();
            foreach (var s in items)
            {
                var data = s.Data;
                ids.Add(data["wid"].ToString());
            }
            string id = string.Join(",", ids);
            var param = new
            {
                token = Config.Token,
                phone = Config.Phone,
                id = id,
            };
            var re = HttpHelper.Post(Config.Server + "/record/delWrong", param);
            if (re != null && HttpHelper.IsOk(re) == true)
            {
                init();
                return;
            }
            else
            {
                MessageBox.Show(re["msg"].ToString());
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            var items = tbWrong.Items;
            List<string> ids = new List<string>();
            foreach (var s in items)
            {
                var data = s.Data;
                ids.Add(data["wid"].ToString());
            }
            string id = string.Join(",", ids);
            var param = new
            {
                token = Config.Token,
                phone = Config.Phone,
                id = id,
            };
            var re = HttpHelper.Post(Config.Server + "/record/delWrong", param);
            if (re != null && HttpHelper.IsOk(re) == true)
            {
                init();
                return;
            }
            else
            {
                MessageBox.Show(re["msg"].ToString());
            }
        }
    }
}
