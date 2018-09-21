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
    /// ucActive.xaml 的交互逻辑
    /// </summary>
    public partial class pageActive : Page
    {
        private int _current_page = 1;
        private bool _hasNext = true;
        public pageActive()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Reload();
        }
        private void Reload()
        {
            if (_current_page < 1)
                _current_page = 1;
            var param = new
            {
                token = Config.Token,
                phone = Config.Phone,
                page = _current_page,
            };
            var re = HttpHelper.Post(Config.Server + "/user/active", param);
            if(re != null && HttpHelper.IsOk(re))
            {
                var data = re["data"]["data"];
                _hasNext = re["data"]["hasNext"];
                table.Data = data;
            }else
            {
                frmMain.ShowLogin(callBack);
            }
            setBtnEnabled();
        }
        private void callBack(dynamic param)
        {
            Reload();
        }
        private void setBtnEnabled()
        {
            if (_current_page <= 1)
            {
                btnLast.IsEnabled = false;
            }
            else
            {
                btnLast.IsEnabled = true;
            }
            if (_hasNext)
            {
                btnNext.IsEnabled = true;
            }
            else
            {
                btnNext.IsEnabled = false;
            }
        }
        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            _current_page--;
            Reload();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            _current_page++;
            Reload();
        }

        private void ActType_FieldFormat_Event(string value, out string new_value)
        {
            if(value == "1")
            {
                new_value = "永久";
            }else
            {
                new_value = "1年";
            }
        }
    }
}
